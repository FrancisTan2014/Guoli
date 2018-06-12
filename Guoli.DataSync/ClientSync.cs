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
    public class ClientSync
    {
        public Dictionary<string, object> GetNewData()
        {
            var tables = Utils.GetClient2ServerTables();
            var statusBll = new DbSyncStatusBll();
            var dict = new Dictionary<string, object>();
            tables.ForEach(table =>
            {
                var cols = statusBll.QuerySingleColumn($"{nameof(DbSyncStatus.TableName)}='{table}'", nameof(DbSyncStatus.Position)).ToList();
                var maxId = cols.Count == 0 ? 0 : (int)cols[0];

                var assembly = "Guoli.Bll";
                var bllInstance = ReflectorHelper.GetInstance(assembly, $"{assembly}.{table}") as IBll;
                var list = bllInstance.QueryList($"Id>{maxId}");
                if (list.Any())
                {
                    dict.Add(table, list);
                }
            });

            return dict;
        }

        public bool AddNewData(string data)
        {
            var tables = Utils.GetServer2ClientTables();

            var jsonObj = JObject.Parse(data);
            JToken dataDict;
            if (jsonObj.TryGetValue("Data", out dataDict))
            {
                // 这里只是需要一个 bll 对象用于执行事务
                // 因此随便选择一个 bll 对象即可
                var transactionBll = new TraficFilesBll();

                var delegates = GetDelegates(tables, dataDict);

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
            }

            return false;
        }

        private List<Func<bool>> GetDelegates(List<string> tables, JToken data)
        {
            var delegates = new List<Func<bool>>();
            tables.ForEach(t =>
            {
                var json = data[t]?.ToString();
                if (!json.IsNullOrEmpty())
                {
                    delegates.Add(() =>
                    {
                        var assembly = "Guoli.Bll";
                        var bllInstance = ReflectorHelper.GetInstance(assembly, $"{assembly}.{t}") as IBll;
                        bllInstance.BulkInsert(json);
                        return true;
                    });
                }
            });

            return delegates;
        }

        private string GetIdentityInsertSwitchSql(List<string> tables, string onOrOff)
        {
            var list = tables.Select(t => $"SET IDENTITY_INSERT [dbo].[{t}] {onOrOff};");
            return string.Join(" ", list);
        }
    } 
}
