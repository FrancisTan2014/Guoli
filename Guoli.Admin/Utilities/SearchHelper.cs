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
using HtmlAgilityPack;
using System.Text;
using System.Collections.Concurrent;

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
        private static readonly string ZipTempPath = PathExtension.MapPath("/_zipTemp"); // 临时压缩包路径

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
                        using (var fs = new FileStream("D:\\finish.txt", FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            using (var writer = new StreamWriter(fs))
                            {
                                writer.Write("finished");
                            }
                        }
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
                var zipFileName = PathExtension.MapPath(file.FilePath);

                var zipTempFileName = Path.Combine(ZipTempPath, Path.GetFileName(file.FilePath));
                if (!Directory.Exists(ZipTempPath))
                {
                    Directory.CreateDirectory(ZipTempPath);
                }

                if (File.Exists(zipFileName))
                {
                    FileHelper.ExtractZip(zipFileName, ExtractPath);
                    var html = GetHtmlStr(ExtractPath, out string htmlFileName, out Encoding encoding);
                    html = AddIdForHtmlDom(html);
                    var tasks = new List<Task>();
                    foreach (var keywords in keywordsList)
                    {
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            try
                            {
                                var searchResult = SearchFromHtml(keywords.Keywords, html);
                                SearchResultEnqueue(searchResult, fileId, keywords);
                            }
                            catch (Exception ex)
                            {
                                ExceptionLogBll.ExceptionPersistence(nameof(SearchHelper), nameof(SearchHelper), ex);
                            }
                        }));
                    }

                    Task.WaitAll(tasks.ToArray());
                    ClearSearchResultQueue();
                    FileHelper.Write(htmlFileName, html, encoding);
                    SearchCompleted(zipTempFileName, zipFileName, ExtractPath);
                    tasks = null;
                    GC.Collect();
                }
            }
        }

        /// <summary>
        /// 搜索过程执行完毕之后
        /// 删除原文件，将新压缩后的文件复制到原文件所在文件夹
        /// 删除临时解压文件夹
        /// </summary>
        /// <param name="tempFileName"></param>
        /// <param name="originFileName"></param>
        /// <param name="deleteDir"></param>
        private static void SearchCompleted(string tempFileName, string originFileName, string deleteDir)
        {
            // 压缩异常时，保持原文件不变
            try
            {
                FileHelper.Zip(tempFileName, ExtractPath);
                File.Delete(originFileName);
                File.Move(tempFileName, originFileName);
            }
            catch (Exception ex)
            {

            }

            // 异常：目录不是空的
            try
            {
                Directory.Delete(ExtractPath, true);
            }
            catch (Exception ex)
            {

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
                var fileList = fileBll.QueryList("IsDelete=0", new[] { "Id", "FilePath", "FileExtension" }).Where(t => t.FileExtension.ToLower() == ".zip");
                foreach (var file in fileList)
                {
                    var zipFileName = PathExtension.MapPath(file.FilePath);
                    if (File.Exists(zipFileName))
                    {
                        FileHelper.ExtractZip(zipFileName, ExtractPath);

                        var html = GetHtmlStr(ExtractPath, out string htmlFileName, out Encoding encoding);
                        html = AddIdForHtmlDom(html);

                        var searchResult = SearchFromHtml(keywords.Keywords, html);
                        FileHelper.Write(htmlFileName, html, encoding);

                        var zipTempFileName = Path.Combine(ZipTempPath, Path.GetFileName(file.FilePath));
                        if (!Directory.Exists(ZipTempPath))
                        {
                            Directory.CreateDirectory(ZipTempPath);
                        }

                        SearchResultEnqueue(searchResult, file.Id, keywords);
                        SearchCompleted(zipTempFileName, zipFileName, ExtractPath);
                    }
                }

                ClearSearchResultQueue();
            }
        }

        private static object _lockObj = new object();
        private static Queue<TraficSearchResult> searchResultQueue = new Queue<TraficSearchResult>();
        /// <summary>
        /// 将搜索结果插入数据库
        /// </summary>
        private static void SearchResultEnqueue(Dictionary<string, string> searchResult, int fileId, TraficKeywords keywords)
        {
            lock (_lockObj)
            {
                var results = new List<TraficSearchResult>();
                foreach (var pair in searchResult)
                {
                    var res = new TraficSearchResult
                    {
                        KeywordsId = keywords.Id,
                        TraficFileId = fileId,
                        SearchResult = pair.Value,
                        Position = pair.Key
                    };
                    results.Add(res);
                    searchResultQueue.Enqueue(res);
                }
                UpdateTraficKeywordsSearchResult(keywords, results);
            }
        }

        private static void UpdateTraficKeywordsSearchResult(TraficKeywords keywords, IEnumerable<TraficSearchResult> results)
        {
            EnsureSearchResultFileExists(keywords);
        }

        private static void EnsureSearchResultFileExists(TraficKeywords keywords)
        {
            var filename = keywords.ResultPath;
            if (filename.IsNullOrEmpty())
            {
                var d = DateTime.Now;
                var relativePath = $"{AppSettings.SearchResults}/{d.ToString("yyyy-MM-dd")}";
                var absolutePath = PathExtension.MapPath(relativePath);
                if (!Directory.Exists(absolutePath))
                {
                    Directory.CreateDirectory(absolutePath);
                }

                keywords.ResultPath = $"{relativePath}/{Guid.NewGuid()}";
            }

            var relativeFilename = PathExtension.MapPath(filename);
        }

        private static void ClearSearchResultQueue()
        {
            var resultBll = new TraficSearchResultBll();
            var maxId = resultBll.GetMaxId();
            var resultList = searchResultQueue.ToList();
            resultBll.BulkInsert(resultList);
            DataUpdateLog.BulkUpdate(typeof(TraficSearchResult).Name, (int)maxId);
            searchResultQueue.Clear();
        }

        public static string GetHtmlStr(string filePath, out string htmlFileName, out Encoding encoding)
        {
            var fileNames = Directory.GetFiles(filePath);
            htmlFileName = fileNames.FirstOrDefault(f => f.EndsWith(".htm") || f.EndsWith(".html"));

            encoding = Encoding.Default;
            if (htmlFileName != null)
            {
                return FileHelper.ReadText(htmlFileName, out encoding);
            }

            return "";
        }

        private static string AddIdForHtmlDom(string html)
        {
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

                if (!html.Contains("FrancisTan201609191127"))
                {
                    html = html.Replace("</body>",
                    "<script>; (function(window, document) {var author='FrancisTan201609191127';window.getQueryString = function(name) {var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', \"i\");var r = window.location.search.substr(1).match(reg);if (r != null) return decodeURIComponent(r[2]); return '';};window.jump = function(id, keywords) {var dom = document.getElementById(id);var content = dom.innerText.replace(keywords, '<font style=\"background: yellow;\">' + keywords + '</font>');dom.innerHTML = content;window.scrollTo(0, dom.offsetTop - 20);};window.onload = function() {var id = getQueryString('id');var keywords = getQueryString('keywords');jump(id, keywords);};})(window, document);</script></body>");
                }
            }

            return html;
        }

        /// <summary>
        /// 从html的body中探索指定关键字，将搜索结果存储到给定字典集中（键-关键字所在DOM元素Id 值-将关键字高亮后的文本）
        /// </summary>
        /// <param name="keywords">待搜索的关键字</param>
        /// <param name="html">待搜索的html源代码</param>
        /// <param name="result">搜索结果</param>
        public static Dictionary<string, string> SearchFromHtml(string keywords, string html)
        {
            var result = new Dictionary<string, string>();

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

            return result;
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