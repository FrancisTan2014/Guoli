using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guoli.Model;

namespace Guoli.DataSync
{
    public class ServerExportModel
    {
        /// <summary>
        /// 数据库更新日志
        /// </summary>
        public List<DbUpdateLog> DbLog { get; set; }

        /// <summary>
        /// 各表更新的数据
        /// </summary>
        public List<List<object>> Data { get; set; }

        /// <summary>
        /// 需要拷贝的文件路径集合
        /// </summary>
        public List<string> PathList { get; set; }
    }
}
