using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using Newtonsoft.Json.Linq;

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
            if (dbUniqueId.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(dbUniqueId));
            }

            // 根据客户端标识确定上次更新的位置
            var p = GetLastPosition(dbUniqueId);

            // 导出 DbUpdateLog 中此位置后的数据更新日志
            var dbLog = GetDbLog(p);

            // 根据日志导出相关表的数据
            var data = GetTableData(dbLog);
            data.Add(nameof(DbUpdateLog), dbLog);

            // 根据日志确定需要拷贝的文件
            var pathList = GetFileData(dbLog);

            return new ServerExportModel
            {
                Data = data,
                PathList = pathList
            };
        }

        private int GetLastPosition(string dbUniqueId)
        {
            var bll = new DbSyncStatusBll();
            var status = bll.QuerySingle($"{nameof(DbSyncStatus.DbIdentity)}='{dbUniqueId}'",
                new[] { nameof(DbSyncStatus.Position) });
            return status?.Position ?? 0;
        }

        private List<DbUpdateLog> GetDbLog(int start)
        {
            var logBll = new DbUpdateLogBll();
            return logBll.QueryList($"Id>${start}") as List<DbUpdateLog>;
        }

        private Dictionary<string, object> GetTableData(List<DbUpdateLog> dbLog)
        {
            var results = new Dictionary<string, object>();

            var groups = dbLog.GroupBy(o => o.TableName);
            foreach (var g in groups)
            {
                var name = g.Key;
                var log = g.ToList();
                var idList = log.Select(o => o.TargetId);
                var condition = $" Id IN ({string.Join(",", idList)})";
                var bll = ReflectorHelper.GetInstance("Guoli.Bll", $"Guoli.Bll.{name}Bll") as IBll;
                var data = bll.QueryList(condition);
                if (data.Any())
                {
                    results.Add(name, data);
                }
            }

            return results;
        }

        public List<string> GetFileData(List<DbUpdateLog> dbLog)
        {
            var groups = dbLog.GroupBy(o => o.TableName);
            var fileLog = groups.SingleOrDefault(g => g.Key == nameof(TraficFiles));
            if (fileLog != null)
            {
                var idList = fileLog.Select(o => o.TargetId);
                var condition = $" Id IN ({string.Join(",", idList)})";
                var bll = new TraficFilesBll();
                var data = bll.QueryList(condition);
                return data.Select(d => d.FilePath).ToList();
            }

            return new List<string>();
        }

        public void CopyNewFiles(List<string> relativePathList, string sourcePath, string targetPath)
        {
            if (sourcePath.IsNullOrEmpty())
            {
                throw new ArgumentNullException("源路径不能为空");
            }
            if (targetPath.IsNullOrEmpty())
            {
                throw new ArgumentNullException("目标路径不能为空");
            }
            if (!Directory.Exists(sourcePath))
            {
                throw new ArgumentException("源路径不存在");
            }
            if (!Directory.Exists(targetPath))
            {
                throw new ArgumentException("目标路径不存在");
            }

            if (relativePathList == null || relativePathList.Count == 0)
            {
                return;
            }

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
                if (File.Exists(sourceName))
                {
                    File.Move(sourceName, destName);
                }
            });
        }

        /// <summary>
        /// 向服务端数据库添加客户端新产生的数据
        /// </summary>
        /// <param name="data">从客户端导出的 json 格式的数据集</param>
        public bool AddNewData(string data)
        {
            var tables = Utils.GetClient2ServerTables();
            var obj = JObject.Parse(data);

            var delegates = new List<Func<bool>>();
            var assembly = "Guoli.Bll";
            tables.ForEach(table =>
            {
                JToken token;
                if (obj.TryGetValue(table, out token))
                {
                    delegates.Add(() =>
                    {
                        var bllInstance = ReflectorHelper.GetInstance(assembly, $"{assembly}.{table}") as IBll;
                        var arrJson = token.ToString();
                        bllInstance.BulkInsert(arrJson);
                        return true;
                    });
                }
            });

            if (delegates.Any())
            {
                var bll = new TraficFilesBll();
                return bll.ExecuteTransation(delegates.ToArray());
            }

            return true;
        }
    }
}
