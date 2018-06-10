using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using Guoli.Utilities.Extensions;

namespace Guoli.DataSync
{
    internal class Utils
    {
        public static List<string> GetClient2ServerTables()
        {
            var config = ConfigurationManager.AppSettings["Client2ServerTables"];
            if (config.IsNullOrEmpty())
            {
                throw new ConfigurationErrorsException("没有找到客户端向服务器端同步的表名这一项配置");
            }

            return config.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static string MakeSyncDir(string origin)
        {
            return Path.Combine(origin, "__sync");
        }
    }
}
