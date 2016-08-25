using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guoli.WebTest.code_generate
{
    public partial class android_entity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dic = @"E:\工作\国力时代\Documents\android entity class";
            var directories = Directory.GetFiles(dic);

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < directories.Length; i++)
            {
                var filePath = directories[i];
                var name = Path.GetFileNameWithoutExtension(filePath);
                var variableName = name + "NameList";

                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        var text = streamReader.ReadToEnd();
                        var pattern = @"\s+private\s+[a-zA-Z]+\s+([a-zA-Z]+);";
                        var regex = new Regex(pattern);
                        var matches = regex.Matches(text);

                        var fieldList = new List<string>();
                        foreach (Match match in matches)
                        {
                            var field = match.Groups[1].Value;
                            fieldList.Add(string.Format("\"{0}\"", field));
                        }

                        var value = "{" + string.Join(",", fieldList) + "}";
                        stringBuilder.AppendFormat("public static String[] {0} = {1};<br/>", variableName, value);
                    }
                }
            }

            Response.Write(stringBuilder);
        }
    }
}