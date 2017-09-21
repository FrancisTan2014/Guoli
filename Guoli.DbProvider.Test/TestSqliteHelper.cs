using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Threading;
using FluentAssertions;
using Guoli.Utilities.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.DbProvider.Test
{
    [TestClass]
    public class TestSqliteHelper
    {
        [TestMethod]
        public void TestBulkInsert()
        {
            TestSuit.RemoveDb();
            TestSuit.CreateDb();

            var connStr = $"Data Source={TestSuit.FilePath}";
            var helper = new SqliteHelper();

            var createTableSql = "CREATE TABLE `TestDb` (`Id` INTEGER, `Name` TEXT);";
            helper.ExecuteNonQuery(connStr, CommandType.Text, createTableSql);

            // 测试1000000条数据插入需要长时间
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));

            var count = 1000000;
            for (int i = 0; i < count; i++)
            {
                table.Rows.Add(i, $"Test{i}");
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            helper.BulkInsert(connStr, "TestDb", table);

            stopWatch.Stop();

            Console.WriteLine(stopWatch.Elapsed.TotalSeconds);

            var id = helper.ExecuteScalar(connStr, CommandType.Text, "SELECT Id FROM TestDb ORDER BY Id DESC");
            id.Should().Equals(count - 1);

            helper = null;
            GC.Collect();
            Thread.Sleep(1000);
            TestSuit.RemoveDb();
        }
    }

    static class TestSuit
    {
        public static readonly string FilePath = PathExtension.MapPath("test.db");

        public static void CreateDb()
        {
            if (!File.Exists(FilePath))
            {
                SQLiteConnection.CreateFile(FilePath);
            }
        }

        public static void RemoveDb()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }
    }
}
