using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

namespace Guoli.WebTest.HtmlParser
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var path = @"C:\Users\lenovo\Desktop\test.html";
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                using (var reader = new StreamReader(fs))
                {
                    var html = reader.ReadToEnd();
                    var match = Regex.Match(html, "<body>([\\s\\S]*)</body>");
                    if (match.Success)
                    {
                        var body = match.Groups[1].Value;
                        var newBody = Regex.Replace(body, "<[^/>]+>", m =>
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
                        using (var writer = new StreamWriter(fs))
                        {
                            fs.Seek(0, SeekOrigin.Begin);
                            writer.WriteLine(html);
                        }
                    }
                }
            }
        }
    }
}