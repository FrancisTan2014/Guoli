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
    public class ServerSync: ISync
    {
        /// <summary>
        /// 从服务端的数据库中获取
        /// 相对于指定客户端数据库
        /// 较新的数据
        /// </summary>
        /// <returns></returns>
        public ServerExportModel GetNewData(int dbUniqueMaxId)
        {
            // 根据客户端标识确定上次更新的位置
            var p = dbUniqueMaxId;

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

        /// <summary>
        /// 向服务端数据库添加客户端新产生的数据
        /// </summary>
        /// <param name="data">从客户端导出的 json 格式的数据集</param>
        public bool AddNewData(Dictionary<string, object> data)
        {
            var delegates = new List<Func<bool>>();
            foreach (var couple in data)
            {
                var table = couple.Key;
                var json = JsonHelper.Serialize(couple.Value);
                delegates.Add(() =>
                {
                    var bllInstance = BllFactory.GetBllInstance(table) as IBll;
                    bllInstance.BulkInsert(json);
                    return true;
                });
            }

            if (delegates.Any())
            {
                var bll = new TraficFilesBll();
                return bll.ExecuteTransation(delegates.ToArray());
            }

            return true;
        }

        public SyncInfo Import(SyncInfo syncInfo)
        {
            if (!syncInfo.ClientNewDataFlag || syncInfo.ServerWriteSuccess)
            {
                syncInfo.ServerWriteSuccess = true;
                return syncInfo;
            }

            var success = AddNewData(syncInfo.ClientData);
            syncInfo.ServerWriteSuccess = success;
            return syncInfo;
        }

        public SyncInfo Export(SyncInfo syncInfo)
        {
            var dbLogMaxId = syncInfo.DbUpdateLogMaxId;
            var bll = new DbSyncStatusBll();
            var status = bll.QuerySingle($"[DbIdentity]='{syncInfo.DbIdentity}'");
            if (syncInfo.ClientWriteSuccess)
            {
                status.Position = dbLogMaxId;
                status.LastTime = DateTime.Now;
                bll.Update(status);
            }
            else
            {
                dbLogMaxId = status.Position;
            }

            var newData = GetNewData(dbLogMaxId);
            syncInfo.ServerData = newData.Data;
            syncInfo.PathList = newData.PathList;
            syncInfo.ClientWriteSuccess = false;
            syncInfo.ServerNewDataFlag = newData.Data.Any();
            syncInfo.DbUpdateLogMaxId = (int)bll.GetMaxId();

            return syncInfo;
        }
    }
}
