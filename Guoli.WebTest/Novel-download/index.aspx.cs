using Guoli.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guoli.WebTest.Novel_download
{
    internal class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string NextChapter { get; set; }
    }

    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var url = Request["novelUrl"];
            if (!string.IsNullOrEmpty(url))
            {
                var webClient = new WebClient { Encoding = Encoding.GetEncoding("UTF-8") };
                var sourceCode = webClient.DownloadString(url);
                var pageEncoding = GetEncoding(sourceCode);
                if (pageEncoding.EncodingName.ToUpper() != "UTF-8")
                {
                    webClient.Encoding = pageEncoding;
                    sourceCode = webClient.DownloadString(url);
                }

                var contentPattern = "(<h1>[\\s\\S]+?</h1>)[\\s\\S]+?(<div\\sid=\"content\">[\\s\\S]+?</div>)";
                var nextPagePattern = "<a\\s*href=\"([^\"]+)\">下一章</a>";

                var contentRegex = new Regex(contentPattern);
                var contentMatch = contentRegex.Match(sourceCode);

                var nextRegex = new Regex(nextPagePattern);
                var nextPageMath = nextRegex.Match(sourceCode);

                var article = new Article();
                if (contentMatch.Groups.Count > 2)
                {
                    article.Title = contentMatch.Groups[1].Value;
                    article.Content = contentMatch.Groups[2].Value;
                }

                if (nextPageMath.Groups.Count > 1)
                {
                    var nextUrl = nextPageMath.Groups[1].Value;

                    article.NextChapter = nextUrl;
                }

                var json = JsonHelper.Serialize(article);
                Response.ContentType = "json";
                Response.Write(json);
                Response.End();
            }
        }

        private Encoding GetEncoding(string html)
        {
            var pattern = "<meta\\s+http-equiv=\"Content-Type\"\\s+content=\"text/html;\\s+charset=([^\"]+)\\s*\"\\s*/>";
            var match = Regex.Match(html, pattern);
            if (match.Success)
            {
                return Encoding.GetEncoding(match.Groups[1].Value);
            }
            else
            {
                return Encoding.UTF8;
            }
        }
    }
}