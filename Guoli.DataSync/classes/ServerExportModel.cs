using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guoli.Model;

namespace Guoli.DataSync
{
    public class ServerExportModel
    {
        public Dictionary<string, object> Data { get; set; }

        /// <summary>
        /// 需要拷贝的文件路径集合
        /// </summary>
        public List<string> PathList { get; set; }

        public bool NewDataFlag { get; set; }
    }
}
