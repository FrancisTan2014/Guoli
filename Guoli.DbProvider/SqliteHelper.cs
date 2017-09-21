using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Guoli.DbProvider
{
    public class SqliteHelper : DbHelper
    {
        public SqliteHelper() : base(DatabaseType.Sqlite)
        {

        }

        public override void BulkInsert(string connectionString, string tableName, DataTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (table.Rows.Count == 0)
            {
                return;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            PrepareCommond(cmd, row, tableName);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
        }

        private readonly List<string> _paramNames = new List<string>();
        private readonly List<SQLiteParameter> _parameters = new List<SQLiteParameter>();
        private void PrepareCommond(SQLiteCommand command, DataRow row, string tableName)
        {
            _parameters.Clear();
            _paramNames.Clear();
            foreach (DataColumn col in row.Table.Columns)
            {
                _paramNames.Add(col.ColumnName);
                _parameters.Add(new SQLiteParameter($"@{col.ColumnName}"));
            }

            _parameters.ForEach(p =>
            {
                p.Value = row[p.ParameterName.Substring(1)];
            });

            command.CommandText = $"INSERT INTO {tableName}({string.Join(",", _paramNames)}) VALUES({string.Join(",", _paramNames.Select(s => "@" + s))})";

            command.Parameters.Clear();
            command.Parameters.AddRange(_parameters.ToArray());
        }

        public override void BulkInsert<T>(string connectionString, string tableName, IEnumerable<T> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            BulkInsert(connectionString, tableName, data.ToDataTable());
        }
    }
}
