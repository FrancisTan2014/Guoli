using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;

namespace Guoli.Admin.Utilities
{
    /// <summary>
    /// 搜索帮助类，提供对上传文档进行搜索的方法
    /// </summary>
    public static class SearchHelper
    {
        private static bool _isTaskRunning = false;
        //private static readonly HttpContext Context = HttpContext.Current;
        //private static readonly string ExtractPath = Context.Server.MapPath("/_searchTemp"); // 临时解压路径
        // @FrancisTan 20170208
        private static readonly string ExtractPath = PathExtension.MapPath("/_searchTemp"); // 临时解压路径

        /// <summary>
        /// 待执行的搜索队列，其中：
        ///     key=1 表示新增文件，需要针对此文件搜索所有关键字，此时值表示新增文件Id
        ///     key=2 表示新增关键字，需要针对此关键字搜索所有文件，此时值表示新增关键字Id
        /// </summary>
        private static readonly Queue<KeyValuePair<int, int>> SearchQueue = new Queue<KeyValuePair<int, int>>();

        /// <summary>
        /// 添加搜索任务
        /// </summary>
        /// <param name="taskType">任务类型（1 新增文件； 2 新增关键字）</param>
        /// <param name="targetId">新增数据Id</param>
        public static void AddSearchTask(int taskType, int targetId)
        {
            SearchQueue.Enqueue(new KeyValuePair<int, int>(taskType, targetId));
            if (!_isTaskRunning)
            {
                StartTask();
                _isTaskRunning = true;
            }
        }

        /// <summary>
        /// 开启搜索任务
        /// </summary>
        private static void StartTask()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (SearchQueue.Count > 0)
                    {
                        try
                        {
                            var keyPair = SearchQueue.Dequeue();
                            var type = keyPair.Key;
                            var targetId = keyPair.Value;
                            if (type == 1)
                            {
                                SearchForNewFile(targetId);
                            }
                            else
                            {
                                SearchForNewKeywords(targetId);
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogBll.ExceptionPersistence("SearchHelper.cs", "SearchHelper", ex);
                        }
                    }
                    else
                    {
                        _isTaskRunning = false;
                        break;
                    }
                }
            });
        }

        /// <summary>
        /// 针对新增文件搜索所有关键字
        /// </summary>
        /// <param name="fileId"></param>
        private static void SearchForNewFile(int fileId)
        {
            var fileBll = new TraficFilesBll();
            var file = fileBll.QuerySingle(fileId);
            if (file != null && file.FileExtension.ToLower() == ".zip")
            {
                var keywordsBll = new TraficKeywordsBll();
                var keywordsList = keywordsBll.QueryAll();

                //var zipPath = Context.Server.MapPath(file.FilePath);
                // @FrancisTan 20170208
                var zipPath = PathExtension.MapPath(file.FilePath);

                FileHelper.ExtractZip(zipPath, ExtractPath);

                foreach (var keywords in keywordsList)
                {
                    var searchResult = SearchHtmlInZip(ExtractPath, keywords.Keywords);
                    
                    InsertToDb(searchResult, fileId, keywords.Id);
                }

                File.Delete(zipPath);
                FileHelper.Zip(zipPath, ExtractPath);
                Directory.Delete(ExtractPath, true);
            }
        }

        /// <summary>
        /// 针对新增关键字搜索所有文件
        /// </summary>
        /// <param name="keywordsId"></param>
        private static void SearchForNewKeywords(int keywordsId)
        {
            var keywordsBll = new TraficKeywordsBll();
            var keywords = keywordsBll.QuerySingle(keywordsId);
            if (keywords != null)
            {
                var fileBll = new TraficFilesBll();
                var fileList = fileBll.QueryList("IsDelete=0", new[] { "Id", "FilePath", "FileExtension" });
                foreach (var file in fileList)
                {
                    //var zipPath = Context.Server.MapPath(file.FilePath);
                    // @FrancisTan 20170208
                    var zipPath = PathExtension.MapPath(file.FilePath);

                    FileHelper.ExtractZip(zipPath, ExtractPath);

                    var searchResult = SearchHtmlInZip(ExtractPath, keywords.Keywords);

                    File.Delete(zipPath);
                    FileHelper.Zip(zipPath, ExtractPath);
                    Directory.Delete(ExtractPath, true);

                    InsertToDb(searchResult, file.Id, keywordsId);
                }
            }
        }

        /// <summary>
        /// 将搜索结果插入数据库
        /// </summary>
        /// <param name="searchResult"></param>
        /// <param name="fileId"></param>
        /// <param name="keywordsId"></param>
        private static void InsertToDb(Dictionary<string, string> searchResult, int fileId, int keywordsId)
        {
            var resultBll = new TraficSearchResultBll();
            var maxId = resultBll.GetMaxId();

            var list = searchResult.Select(keyPair => new TraficSearchResult
            {
                KeywordsId = keywordsId,
                TraficFileId = fileId,
                SearchResult = keyPair.Value,
                Position = keyPair.Key
            });

            resultBll.BulkInsert(list);
            DataUpdateLog.BulkUpdate(typeof(TraficSearchResult).Name, (int)maxId);
        }

        /// <summary>
        /// 从包含htm/html的zip包中提取出html文件
        /// 为此html文件中的body下所有元素添加id属性（guid）
        /// 从body下的文本中搜索所有包含指定关键字的内容
        /// 将新的Html文本写入原文件中
        /// 返回包含关键字的元素的id及此元素文本（关键字高亮后）所组成的字典集
        /// </summary>
        /// <param name="filePath">待搜索文件所在路径</param>
        /// <param name="keywords">待搜索的关键字</param>
        /// <returns>搜索结果</returns>
        public static Dictionary<string, string> SearchHtmlInZip(string filePath, string keywords)
        {
            var fileNames = Directory.GetFiles(filePath);
            var htmlFileName = fileNames.FirstOrDefault(f => f.EndsWith(".htm") || f.EndsWith(".html"));

            var result = new Dictionary<string, string>();
            if (htmlFileName != null)
            {
                AddIdForHtmlTag(htmlFileName, html => { SearchFromHtml(keywords, html, result); });
            }
            return result;
        }

        /// <summary>
        /// 读取html文件，为所有body下没有id的元素添加唯一标识，之后将新文本写入原文件
        /// </summary>
        /// <param name="filePath">html文件路径</param>
        /// <param name="afterComplete">添加唯一标识完成后执行的方法</param>
        public static void AddIdForHtmlTag(string filePath, Action<string> afterComplete)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                var encoding = FileHelper.GetEncoding(fs);
                using (var reader = new StreamReader(fs, encoding))
                {
                    var html = reader.ReadToEnd();
                    var match = Regex.Match(html, "<body[^>]*>([\\s\\S]*)</body>");
                    if (match.Success)
                    {
                        var body = match.Groups[1].Value;
                        var newBody = Regex.Replace(body, "<[^/>\\[\\]]+>", m =>
                        {
                            var tag = m.Groups[0].Value;
                            if (!tag.Contains("id="))
                            {
                                var guid = Guid.NewGuid().ToString();
                                tag = tag.Replace(">", $" id=\"{guid}\">");
                            }

                            return tag;
                        });

                        html = html.Replace(body, newBody);
                        afterComplete?.Invoke(html);

                        if (!html.Contains("FrancisTan201609191127"))
                        {
                            html = html.Replace("</body>",
                            "<script>; (function(window, document) {var author='FrancisTan201609191127';window.getQueryString = function(name) {var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', \"i\");var r = window.location.search.substr(1).match(reg);if (r != null) return decodeURIComponent(r[2]); return '';};window.jump = function(id, keywords) {var dom = document.getElementById(id);var content = dom.innerText.replace(keywords, '<font style=\"background: yellow;\">' + keywords + '</font>');dom.innerHTML = content;window.scrollTo(0, dom.offsetTop - 20);};window.onload = function() {var id = getQueryString('id');var keywords = getQueryString('keywords');jump(id, keywords);};})(window, document);</script></body>");
                        }
                        using (var writer = new StreamWriter(fs, encoding))
                        {
                            fs.Seek(0, SeekOrigin.Begin);
                            writer.WriteLine(html);
                        }
                    }
                }

            } // end FileStream

        }// end method

        /// <summary>
        /// 从html的body中探索指定关键字，将搜索结果存储到给定字典集中（键-关键字所在DOM元素Id 值-将关键字高亮后的文本）
        /// </summary>
        /// <param name="keywords">待搜索的关键字</param>
        /// <param name="html">待搜索的html源代码</param>
        /// <param name="result">搜索结果</param>
        public static void SearchFromHtml(string keywords, string html, Dictionary<string, string> result)
        {
            if (string.IsNullOrEmpty(keywords))
            {
                throw new ArgumentNullException(nameof(keywords));
            }
            if (string.IsNullOrEmpty(html))
            {
                throw new ArgumentNullException(nameof(html));
            }
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            var pattern = $"<[^>]+id=\"([^\"]+)\"[^>]*>[^>]*{keywords}[\\s\\S]*?</[^>]+>";
            var matches = Regex.Matches(html, pattern);
            foreach (Match match in matches)
            {
                var id = match.Groups[1].Value;
                var highLightKeywords = HighLight(keywords);
                var content = match.Groups[0].Value.Replace(keywords, highLightKeywords);

                result.Add(id, content);
            }
        }

        /// <summary>
        /// 在给定文本外嵌套带背景颜色的html标签（达到高亮此文本的效果）后返回
        /// </summary>
        /// <param name="content">指定文本</param>
        /// <returns>原始文本的高亮版本</returns>
        public static string HighLight(string content)
        {
            return $"<font style=\"background: yellow;\">{content}</font>";
        }
    }
}