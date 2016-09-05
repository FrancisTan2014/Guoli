using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guoli.WebTest.PathGenerate
{
    public partial class path_generate : System.Web.UI.Page
    {
        private string url = "http://192.168.0.110:8080/";

        protected void Page_Load(object sender, EventArgs e)
        {
            var dic = @"E:\工作\国力时代\WebPublish\Guoli.Admin\FileData";
            var directoryInfo = new DirectoryInfo(dic);
            var list = GetPaths(directoryInfo);
            var value = "{" + string.Join(",", list)  +"}";
            var text = string.Format("public String[] fileUrlArray = {0};", value);

            Response.Write(text);
        }

        public List<string> GetPaths(DirectoryInfo dir)
        {
            var list = new List<string>();

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var filePath = file.FullName;
                var relatePath = filePath.Substring(filePath.IndexOf("FileData"));
                var fullUrl = Path.Combine(url, relatePath).Replace('\\', '/');
                list.Add(string.Format("\"{0}\"", fullUrl));
            }

            var directories = dir.GetDirectories();
            foreach (var item in directories)
            {
                var subList = GetPaths(item);
                list.AddRange(subList);
            }

            return list;
        }
    }
}