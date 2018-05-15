using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Helpers;

namespace Guoli.DataSync
{
    public class ServerSync
    {
        /// <summary>
        /// 从服务端的数据库中获取
        /// 相对于指定客户端数据库
        /// 较新的数据
        /// </summary>
        /// <param name="dbUniqueId">
        ///     指定的数据库唯一标识（用于确定其上次同步的状态）
        /// </param>
        /// <returns></returns>
        public ServerExportModel GetNewData(string dbUniqueId)
        {
            // 根据客户端标识确定上次更新的位置
            var p = GetLastPosition(dbUniqueId);

            // 导出 DbUpdateLog 中此位置后的数据更新日志
            var dbLog = GetDbLog(p);

            // 根据日志导出相关表的数据
            List<List<object>> data = GetTableData(dbLog);

            // 根据日志确定需要拷贝的文件
            var files = data.Find(list => list?[0] is TraficFiles);
            List<string> pathList = null;
            if (files != null)
            {
                pathList =
                    files.Select(
                        o => ReflectorHelper.GetPropertyValue(o, nameof(TraficFiles.FilePath))
                    ) as List<string>;
            }

            return new ServerExportModel
            {
                DbLog = dbLog,
                Data = data,
                PathList = pathList
            };
        }

        public int GetLastPosition(string dbUniqueId)
        {
            var bll = new DbSyncStatusBll();
            var status = bll.QuerySingle($"{nameof(DbSyncStatus.DbIdentity)}='{dbUniqueId}'",
                new[] { nameof(DbSyncStatus.Position) });
            return status?.Position ?? 0;
        }

        public List<DbUpdateLog> GetDbLog(int start)
        {
            var logBll = new DbUpdateLogBll();
            return logBll.QueryList($"Id>${start}") as List<DbUpdateLog>;
        }

        public List<List<object>> GetTableData(List<DbUpdateLog> dbLog)
        {
            var results = new List<List<object>>();

            var groups = dbLog.GroupBy(o => o.TableName);
            foreach (var g in groups)
            {
                var name = g.Key;
                var log = g.ToList();
                var idList = log.Select(o => o.TargetId);
                var condition = $" Id IN ({string.Join(",", idList)})";
                var bll = ReflectorHelper.GetInstance("Guoli.Bll", $"Guoli.Bll.{name}Bll") as IBll;
                var data = bll.QueryList(condition).ToList();
                results.Add(data);
            }

            return results;
        }

        public void CopyNewFiles(List<string> relativePathList, string sourcePath, string targetPath)
        {
            var dir = Utils.MakeSyncDir(targetPath);
            var list = relativePathList;
            list.ForEach(p =>
            {
                var destName = Path.Combine(dir, p); // 新的文件绝对路径
                var destDir = Path.GetDirectoryName(destName); // 新的目录绝对路径
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                var sourceName = Path.Combine(sourcePath, p);
                File.Move(sourceName, destName);
            });
        }
    }
}
