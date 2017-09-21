using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Guoli.Bll;
using Guoli.DbProvider;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;

namespace Guoli.MSSqlToSqlite
{
    public sealed class MsSqlToSqlite
    {
        /// <summary>
        /// 获取程序生成的 sqlite 数据库文件的绝对路径
        /// </summary>
        public string SqliteDbPath => PathExtension.MapPath("/Railroad.db");

        /// <summary>
        /// 获取将作为整个拷贝程序基础的 sqlite 数据库表创建脚本的文件(*.xml)路径
        /// 可以通过此路径改变数据库创建脚本文件
        /// </summary>
        public string ScriptFilePath => PathExtension.MapPath("/db.xml");

        // 创建 sqlite 表的脚本字典：key 为表名，键为脚本
        private readonly Dictionary<string, string> _tableScripts = new Dictionary<string, string>();
        // sqlite 表名为键，其列名集合为值的字典集
        private readonly Dictionary<string, List<string>> _tableFields = new Dictionary<string, List<string>>();

        private readonly string _msSqlConnStr;
        private readonly string _sqliteConnStr;

        private SqlHelper MsSqlserver => new SqlHelper();
        private SqliteHelper Sqlite => new SqliteHelper();

        public MsSqlToSqlite()
        {
            var c = ConfigurationManager.ConnectionStrings;
            _msSqlConnStr = c["MainDb"].ConnectionString;
            _sqliteConnStr = $"Data Source={SqliteDbPath}";

            if (_msSqlConnStr.IsNullOrEmpty())
            {
                throw new InvalidOperationException("Connection string cannot be empty.");
            }
        }

        /// <summary>
        /// 从 db.xml 中加载创建 sqlite 表的脚本
        /// </summary>
        private void LoadSqliteTableScripts()
        {
            if (File.Exists(ScriptFilePath))
            {
                var root = XElement.Load(ScriptFilePath);
                root.Elements()
                    .FirstOrDefault(node =>
                        node.Name == "array" &&
                        node.Attribute("name")?.Value == "CREATE_TABLE_SQL"
                    )?
                    .Elements()
                    .ToList()
                    .ForEach(node =>
                    {
                        var needToGetFields = node.Attribute("exclude")?.Value != "true";
                        GetTableInfo(node.Value, needToGetFields);
                    });
            }
        }

        private void GetTableInfo(string script, bool needToGetFields)
        {
            var match = Regex.Match(script,
                @"((?i)create(?-i)\s+(?i)table(?-i)\s+.*?(\w+)\s*\(([^\)]+)\))|((?i)create(?-i)\s+(?i)view(?-i)\s+([\w_]+)\s+)");
            if (match.Success)
            {
                var tableName = match.Groups[2].Value;
                if (!tableName.IsNullOrEmpty())
                {
                    _tableScripts.Add(tableName, script);
                    if (needToGetFields)
                    {
                        var fields = GetFieldsFromScript(match.Groups[3].Value);
                        _tableFields.Add(tableName, fields);
                    }
                }
                else
                {
                    tableName = match.Groups[5].Value;
                    _tableScripts.Add(tableName, script);
                }
            }
        }

        private List<string> GetFieldsFromScript(string script)
        {
            return script?.Split(',')
                       .Select(s => s.Trim().Split(' ')[0])
                       .ToList()
                   ?? new List<string>();
        }

        /// <summary>
        /// 获取 sqlite 数据库文件流（将从 sqlserver 数据库拷贝）
        /// </summary>
        /// <returns></returns>
        public Stream GetSqliteDb()
        {
            LoadSqliteTableScripts();

            #region 已注释：需要考虑数据库更新的逻辑
            //if (File.Exists(_sqliteDbPath))
            //{
            //    UpdateFromSourceDb();
            //}
            //else
            //{
            //    SQLiteConnection.CreateFile(_sqliteDbPath);
            //    CreateSqliteTables();
            //    CopyFromSourceDb();
            //} 
            #endregion

            // 以下是每次都拷贝最新数据库的逻辑

            if (File.Exists(SqliteDbPath))
            {
                File.Delete(SqliteDbPath);
            }

            SQLiteConnection.CreateFile(SqliteDbPath);
            CreateSqliteTables();
            CopyFromSourceDb();

            return new FileStream(SqliteDbPath, FileMode.Open, FileAccess.Read);
        }

        /// <summary>
        /// 将从源数据库中获取到的数据转换为与 sqlite 数据库表格式一致的 Datatable 
        /// </summary>
        /// <param name="fields">sqlite 表字段集合</param>
        /// <param name="list">从源数据库中获取到的数据集合</param>
        /// <returns>与 sqlite 数据库表格式一致的<see cref="DataTable"/>类型的对象</returns>
        private DataTable GetDataTable(List<string> fields, IEnumerable list)
        {
            var table = new DataTable();
            var iterator = list.GetEnumerator();

            #region 为 table 设置列名及其数据类型
            if (iterator.MoveNext() && iterator.Current != null)
            {
                var type = iterator.Current.GetType();
                fields.ForEach(f =>
                {
                    var prop = type.GetProperty(f);
                    if (prop != null)
                    {
                        table.Columns.Add(f, prop.PropertyType);
                    }
                });
            }
            iterator.Reset();
            #endregion

            while (iterator.MoveNext())
            {
                if (iterator.Current != null)
                {
                    var type = iterator.Current.GetType();
                    var row = table.NewRow();
                    fields.ForEach(item =>
                    {
                        var prop = type.GetProperty(item);
                        if (prop != null)
                        {
                            row[item] = prop.GetValue(iterator.Current);
                        }
                    });

                    table.Rows.Add(row);
                }
            }

            return table;
        }

        /// <summary>
        /// 将源数据库中需要拷贝到 sqlite 数据库中的所有表的所有数据拷贝入 sqlite 数据库
        /// </summary>
        private void CopyFromSourceDb()
        {
            foreach (var pair in _tableFields)
            {
                // 根据表名获取对应的 bll 对象
                var bll = BllFactory.GetBllInstance(pair.Key);

                var list = ReflectorHelper.InvokeMethod(bll, "QueryAll") as IEnumerable;
                var table = GetDataTable(pair.Value, list);

                Sqlite.BulkInsert(_sqliteConnStr, pair.Key, table);
            }
        }

        private void CreateSqliteTables()
        {
            foreach (var group in _tableScripts)
            {
                if (!TableExists(group.Key))
                {
                    Sqlite.ExecuteNonQuery(_sqliteConnStr, CommandType.Text, group.Value);
                }
            }
        }

        private bool TableExists(string table)
        {
            var sql = table.ToLower().StartsWith("view")
                ? $"SELECT name FROM sqlite_master WHERE type='view' AND name='{table}';"
                : $"SELECT name FROM sqlite_master WHERE type='table' AND name='{table}';";

            var res = Sqlite.ExecuteScalar(_sqliteConnStr, CommandType.Text, sql);

            return table == res?.ToString();
        }

        /// <summary>
        /// 将源数据库中更新的数据同步到 sqlite 数据库中
        /// </summary>
        private void UpdateFromSourceDb()
        {
            throw new NotImplementedException();
        }
    }
}
