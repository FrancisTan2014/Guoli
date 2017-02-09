using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Guoli.Utilities.Extensions
{
    /// <summary>
    /// 对Path类的扩展
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-15</since>
    public static class PathExtension
    {
        /// <summary>
        /// 获取给定相对路径在磁盘上的映射地址（绝对路径）
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        /// <returns>返回给定路径所对应的绝对路径</returns>
        public static string MapPath(string relativePath)
        {
            string result;

            var server = HttpContext.Current?.Server;
            if (server == null)
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory;
                var path = relativePath;
                if (!path.StartsWith("/") && !path.StartsWith("\\"))
                {
                    path = $"\\{relativePath}";
                }

                result = dir + path;
            }
            else
            {
                result = server.MapPath(relativePath);
            }

            return result;
        }
    }
}
