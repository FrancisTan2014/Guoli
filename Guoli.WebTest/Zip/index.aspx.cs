using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Guoli.Utilities.Helpers;
using ICSharpCode.SharpZipLib.Zip;

namespace Guoli.WebTest.Zip
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 列出压缩文件中所有文件名称
            //using (var zipFile = new ZipFile(zipPath))
            //{
            //    foreach (ZipEntry entry in zipFile)
            //    {
            //        Response.Write($"{entry.Name}<br/>");
            //    }
            //} 
            #endregion

            var zipPath = @"C:\Users\lenovo\Desktop\ef77194e-a5ae-4b71-99d2-bd99dd46886c.zip";
            var extractPath = @"C:\Users\lenovo\Desktop\Temp\";
            var keywords = "调车作业计划";

            var result = SearchHtmlInZip(zipPath, extractPath, keywords);

            File.Delete(zipPath);
            FileHelper.Zip(zipPath, extractPath);
            Directory.Delete(extractPath, true);
        }

        /// <summary>
        /// 从包含htm/html的zip包中提取出html文件
        /// 为此html文件中的body下所有元素添加id属性（guid）
        /// 从body下的文本中搜索所有包含指定关键字的内容
        /// 将新的Html文本写入原文件中
        /// 返回包含关键字的元素的id及此元素文本（关键字高亮后）所组成的字典集
        /// </summary>
        /// <param name="zipPath">压缩包绝对路径</param>
        /// <param name="extractPath">解压路径</param>
        /// <param name="keywords">待搜索的关键字</param>
        /// <returns>搜索结果</returns>
        public Dictionary<string, string> SearchHtmlInZip(string zipPath, string extractPath, string keywords)
        {
            FileHelper.ExtractZip(zipPath, extractPath);

            var fileNames = Directory.GetFiles(extractPath);
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
        public void AddIdForHtmlTag(string filePath, Action<string> afterComplete)
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

                        html = html.Replace("</body>",
                            "<script>; (function (window, document) {window.getQueryString = function (name) {var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', \"i\");var r = window.location.search.substr(1).match(reg);if (r != null) return decodeURIComponent(r[2]);return '';};window.onload = function () {var id = getQueryString('id');var keywords = getQueryString('keywords');var dom = document.getElementById(id);var content = dom.innerText.replace(keywords, '<font style=\"background: yellow;\">' + keywords + '</font>');dom.innerHTML = content;window.scrollTo(0, dom.offsetTop-20);};})(window, document);</script></body>");
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
        public void SearchFromHtml(string keywords, string html, Dictionary<string, string> result)
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
        public string HighLight(string content)
        {
            return $"<font style=\"background: yellow;\">{content}</font>";
        }
    }
}
