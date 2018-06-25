using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.DataSync
{
    public class ClientSync: ISync
    {
        public Dictionary<string, object> GetNewData(Dictionary<string, int> startsDict)
        {
            var tables = Utils.GetClient2ServerTables();
            var dict = new Dictionary<string, object>();
            tables.ForEach(table =>
            {
                var maxId = 0;
                if (startsDict.ContainsKey(table))
                {
                    maxId = startsDict[table];
                }
                
                var bllInstance = BllFactory.GetBllInstance(table) as IBll;
                var list = bllInstance.QueryList($"Id>{maxId}");
                if (list.Any())
                {
                    dict.Add(table, list);
                }
            });

            return dict;
        }

        private bool AddNewData(Dictionary<string, object> data)
        {
                var tables = data.Keys.ToList();

                // 这里只是需要一个 bll 对象用于执行事务
                // 因此随便选择一个 bll 对象即可
                var transactionBll = new TraficFilesBll();

                var delegates = GetDelegates(data);

                var switchOnSql = GetIdentityInsertSwitchSql(tables, "ON");
                var switchOffSql = GetIdentityInsertSwitchSql(tables, "OFF");
                delegates.Insert(0, () => {
                    transactionBll.ExecuteSql(switchOnSql);
                    return true;
                });
                delegates.Add(() =>
                {
                    transactionBll.ExecuteSql(switchOffSql);
                    return true;
                });

                // 执行事务，插入数据（若执行失败，则重复五次，直到成功）
                // 1. 打开主键插入开关 SET IDENTITY_INSERT [dbo].[ExamType] ON 
                // 2. 插入数据
                // 3. 关闭主键插入开关 SET IDENTITY_INSERT [dbo].[ExamType] OFF
                for (var i = 0; i < 5; i++)
                {
                    var success = transactionBll.ExecuteTransation(delegates.ToArray());
                    if (success)
                    {
                        return true;
                    }
                }

            return false;
        }

        private List<Func<bool>> GetDelegates(Dictionary<string, object> data)
        {
            var delegates = new List<Func<bool>>();
            foreach (var couple in data)
            {
                var t = couple.Key;
                var json = JsonHelper.Serialize(couple.Value);
                delegates.Add(() =>
                {
                    var bllInstance = BllFactory.GetBllInstance(t) as IBll;
                    bllInstance.BulkInsert(json);
                    return true;
                });
            }

            return delegates;
        }

        private string GetIdentityInsertSwitchSql(List<string> tables, string onOrOff)
        {
            var list = tables.Select(t => $"SET IDENTITY_INSERT [dbo].[{t}] {onOrOff};");
            return string.Join(" ", list);
        }

        public SyncInfo Import(SyncInfo syncInfo)
        {
            if (!syncInfo.ServerNewDataFlag || syncInfo.ClientWriteSuccess)
            {
                syncInfo.ClientWriteSuccess = true;
                return syncInfo;
            }

            var success = AddNewData(syncInfo.ServerData);
            syncInfo.ClientWriteSuccess = success;
            return syncInfo;
        }

        public SyncInfo Export(SyncInfo syncInfo)
        {
            var startsDict = GetLastMaxIdDict(syncInfo);
            var newData = GetNewData(startsDict);
            syncInfo.ClientData = newData;
            syncInfo.ClientNewDataFlag = newData.Any();
            syncInfo.ServerWriteSuccess = false;

            var newStartsDict = GetNewStartsDict();
            syncInfo.ExportMaxIdDict = newStartsDict;

            return syncInfo;
        }

        private static Dictionary<string, int> GetNewStartsDict()
        {
            var tables = Utils.GetClient2ServerTables();
            var newStartsDict = new Dictionary<string, int>();
            tables.ForEach(t =>
            {
                var bllInstance = BllFactory.GetBllInstance(t) as IBll;
                var maxId = (int) bllInstance.GetMaxId();
                newStartsDict.Add(t, maxId);
            });
            return newStartsDict;
        }

        private Dictionary<string, int> GetLastMaxIdDict(SyncInfo syncInfo)
        {
            var bll = new DbSyncStatusBll();
            var startsDict = syncInfo.ExportMaxIdDict;
            if (syncInfo.ServerWriteSuccess)
            {
                // 由于上次导入的数据已成功同步至服务端
                // 因此，将上将导出数据的最大 Id 写入数据库
                // 以作为下次导出数据的依据
                var models = startsDict.Select(couple => new DbSyncStatus
                {
                    DbIdentity = string.Empty,
                    TableName = couple.Key,
                    Position = couple.Value,
                    LastTime = DateTime.Now
                });
                bll.BulkInsert(models);
            }
            else
            {
                startsDict = new Dictionary<string, int>();
                var list = bll.QueryAll();
                foreach (var o in list)
                {
                    startsDict.Add(o.TableName, o.Position);
                }
            }
            return startsDict;
        }
    } 
}
