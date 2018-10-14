using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Guoli.DataSync
{
    public class ClientSync : ISync
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
            // 这里只是需要一个 bll 对象用于执行事务
            // 因此随便选择一个 bll 对象即可
            var transactionBll = new TraficFilesBll();

            var delegates = CreateDelegates(data);

            // 执行事务，插入数据（若执行失败，则重复五次，直到成功）
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

        private List<Func<bool>> CreateDelegates(Dictionary<string, object> data)
        {
            var delegates = new List<Func<bool>>();
            var dataArr = DistinguishData(data);

            //delegates.AddRange(CreateDbupadwLogDelegates(data));
            delegates.AddRange(CreateInsertDelegates(dataArr[0]));
            delegates.AddRange(CreateUpdateDelegates(dataArr[1]));
            delegates.AddRange(CreateDeleteDelegates(dataArr[2]));
            return delegates;
        }

        private List<Func<bool>> CreateDbupadwLogDelegates(Dictionary<string, object> data)
        {
            var delegates = new List<Func<bool>>();
            foreach (var couple in data)
            {
                var t = couple.Key;
                if (t.Equals("DbUpdateLog"))
                {
                    var json = JsonHelper.Serialize(couple.Value);
                    delegates.Add(() =>
                    {
                        var bllInstance = BllFactory.GetBllInstance(t) as IBll;
                        var format = "SET IDENTITY_INSERT [dbo].[{0}] {1};";
                        var setOnSql = string.Format(format, t, "ON");
                        bllInstance.ExecuteSql(setOnSql);

                        bllInstance.BulkInsert(json);

                        var setOffSql = string.Format(format, t, "OFF");
                        bllInstance.ExecuteSql(setOffSql);

                        return true;
                    });
                }
            }
            return delegates;
        }

            private List<Func<bool>> CreateInsertDelegates(Dictionary<string, object> data)
        {
            var delegates = new List<Func<bool>>();
            foreach (var couple in data)
            {
                var t = couple.Key;
                var json = JsonHelper.Serialize(couple.Value);

                // 1. 打开主键插入开关 SET IDENTITY_INSERT [dbo].[ExamType] ON 
                // 2. 插入数据
                // 3. 关闭主键插入开关 SET IDENTITY_INSERT [dbo].[ExamType] OFF
                delegates.Add(() =>
                {
                    var bllInstance = BllFactory.GetBllInstance(t) as IBll;

                    var format = "SET IDENTITY_INSERT [dbo].[{0}] {1};";
                    var setOnSql = string.Format(format, t, "ON");
                    bllInstance.ExecuteSql(setOnSql);

                    bllInstance.BulkInsert(json);

                    var setOffSql = string.Format(format, t, "OFF");
                    bllInstance.ExecuteSql(setOffSql);

                    return true;
                });
            }

            return delegates;
        }

        private List<Func<bool>> CreateUpdateDelegates(Dictionary<string, object> data)
        {
            var delegates = new List<Func<bool>>();
            foreach (var couple in data)
            {
                var t = couple.Key;
                var list = couple.Value as List<object>;
                var bllInstance = BllFactory.GetBllInstance(t) as IBll;
                foreach (var o in list)
                {
                    delegates.Add(() => bllInstance.Update(o));
                }
            }

            return delegates;
        }

        private List<Func<bool>> CreateDeleteDelegates(Dictionary<string, object> data)
        {
            var delegates = new List<Func<bool>>();
            var logs = data[nameof(DbUpdateLog)] as List<DbUpdateLog>;
            var groups = logs.GroupBy(item => item.TableName);
            foreach (var g in groups)
            {
                var table = g.Key;
                var list = g.ToList();
                if (list.Any())
                {
                    var bll = BllFactory.GetBllInstance(table) as IBll;
                    var ids = list.Select(o => o.TargetId);
                    var sql = $"DELETE FROM {table} WHERE Id IN({string.Join(",", ids)})";
                    delegates.Add(() => bll.ExecuteSql(sql) > 0);
                }
            }
            return delegates;
        }

        /// <summary>
        /// 根据 DbUpdateLog 将数据分为插入、更新和删除三类
        /// 返回值中：
        /// [0] 是需要插入的数据
        /// [1] 是需要更新的数据
        /// [2] 是需要删除的数据（DbUpdateLog日志）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Dictionary<string, object>[] DistinguishData(Dictionary<string, object> data)
        {
            var logs = data[nameof(DbUpdateLog)];
            var dbLog = JsonHelper.Deserialize<List<DbUpdateLog>>(JsonHelper.Serialize(logs));
            var groups = dbLog.GroupBy(d => d.UpdateType);
            var result = new Dictionary<string, object>[3] {
                new Dictionary<string, object>{ { nameof(DbUpdateLog), dbLog } },
                new Dictionary<string, object>(),
                new Dictionary<string, object>{ { nameof(DbUpdateLog), new List<DbUpdateLog>() } }
            };

            foreach (var g in groups)
            {
                var type = g.Key;
                var list = Distinct(g.ToList());
                if (type == 3)
                {
                    result[2] = new Dictionary<string, object> { { nameof(DbUpdateLog), list } };
                }
                else
                {
                    foreach (var log in list)
                    {
                        var dict = (type == 2) ? result[1] : result[0];
                        if (!dict.ContainsKey(log.TableName))
                        {
                            dict[log.TableName] = new List<object>();
                        }

                        var obj = FindConcrete(data, log.TableName, log.TargetId);
                        var container = (List<object>)dict[log.TableName];
                        container.Add(obj);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 将对同一表的同一 Id 的数据操作去重，按时间取最近一次操作记录
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        private List<DbUpdateLog> Distinct(IEnumerable<DbUpdateLog> logs)
        {
            var res = new List<DbUpdateLog>();
            var groups = from d in logs
                         group d by new { d.TableName, d.TargetId };
            foreach (var g in groups)
            {
                var latest = g.OrderByDescending(d => d.UpdateTime).First();
                res.Add(latest);
            }
            return res;
        }

        private object FindConcrete(Dictionary<string, object> dict, string tableName, int id)
        {
            var data = dict[tableName]?.ToString();
            var list = JsonHelper.Deserialize<List<object>>(data);
            if (list != null)
            {
                var assemblyName = "Guoli.Model";
                var assembly = Assembly.Load(assemblyName);
                foreach (var o in list)
                {
                    var type = assembly.GetType($"{assemblyName}.{tableName}");
                    dynamic obj = JsonHelper.Deserialize(o.ToString(), type);
                    //if ((int)ReflectorHelper.GetPropertyValue(obj, "Id") == id)
                    if (obj.Id == id)
                    {
                        return obj;
                    }
                }
            }

            return null;
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
                var maxId = (int)bllInstance.GetMaxId();
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
               // MessageBox.Show("数据同步过...");
                

            }
            return startsDict;
        }
    }
}
