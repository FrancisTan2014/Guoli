using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using FluentAssertions;
using Guoli.DbProvider;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Guoli.MSSqlToSqlite;

namespace Guoli.MSSqlToSqlite.Test
{
    [TestClass]
    public class MSSqlToSqliteTest
    {
        private string _connStr = "Data Source=Railroad.db";
        private SqliteHelper _sqliteHelper = new SqliteHelper();

        [TestMethod]
        public void TestRegularExp()
        {
            var p1 = @"^(?i)create(?-i)\s+((?i)table(?-i)|(?i)view(?-i))";
            var str11 = "create view as select";
            var str12 = "CREATE VIEW as select";
            var str13 = "create table aaaa()";
            Regex.IsMatch(str11, p1).Should().Be(true);
            Regex.IsMatch(str12, p1).Should().Be(true);
            Regex.IsMatch(str13, p1).Should().Be(true);

            // 测试从脚本中提取表名或者视图名称的正则表达式是否正确
            var p2 =
                @"((?i)create(?-i)\s+(?i)table(?-i)\s+.*?(\w+)\s*\(([^\)]+)\))|((?i)create(?-i)\s+(?i)view(?-i)\s+([\w_]+)\s+)";
            var str21 = @"create table if not exists BaseStation(
                          Id INTEGER,
                          StationName text,
                          SN integer,
                          Spell text,
                          UpdateTime text,
                          IsDelete text not null DEFAULT 0,
                          TableNamessss text)";
            var str22 = @"create view View_Station as SELECT Id, SN, StationName, Spell, UpdateTime, FileCount,
                          ZdCount, CzCount, ZcCount FROM (SELECT S.Id, S.SN, S.StationName, S.Spell, S.UpdateTime,
                          (SELECT COUNT(1) AS Expr1 FROM StationFiles WHERE (StationId = S.Id) AND (IsDelete = 0))
                          AS FileCount, (SELECT COUNT(1) AS Expr1 FROM StationFiles WHERE (StationId = S.Id) AND
                          (IsDelete = 0) AND (FileType = 1)) AS ZdCount, (SELECT COUNT(1) AS Expr1 FROM
                          StationFiles WHERE (StationId = S.Id) AND (IsDelete = 0) AND (FileType = 2)) AS CzCount,
                          (SELECT COUNT(1) AS Expr1 FROM StationFiles WHERE (StationId = S.Id) AND (IsDelete = 0)
                          AND (FileType = 3)) AS ZcCount FROM BaseStation AS S LEFT OUTER JOIN StationFiles AS F
                          ON S.Id = F.StationId WHERE (S.IsDelete = 0)) AS T GROUP BY Id, SN, StationName, Spell,
                          UpdateTime, FileCount, ZdCount, ZcCount, CzCount;";
            var str23 = @"create table AppOperateLog (
                          Id INTEGER PRIMARY KEY AUTOINCREMENT,
                          LogType integer,
                          LogContent text,
                          OperatorId integer,
                          DeviceId integer,
                          AddTime text,
                          IsUploaded text not null DEFAULT 0)";
            var match21 = Regex.Match(str21, p2);
            match21.Groups.Count.Should().Be(6);
            match21.Groups[2].Value.Should().Be("BaseStation");
            var fields = match21.Groups[3].Value.Trim();
            fields.StartsWith("Id").Should().Be(true);
            fields.EndsWith("text").Should().Be(true);

            var match22 = Regex.Match(str22, p2);
            match22.Groups.Count.Should().Be(6);
            match22.Groups[5].Value.Should().Be("View_Station");

            var match23 = Regex.Match(str23, p2);
            match23.Groups.Count.Should().Be(6);
            match23.Groups[2].Value.Should().Be("AppOperateLog");
            fields = match23.Groups[3].Value.Trim();
            fields.StartsWith("Id").Should().Be(true);
            fields.EndsWith("0").Should().Be(true);
        }

        [TestMethod]
        public void TestLoadSqliteTableScripts()
        {
            var instance = new MsSqlToSqlite();

            var scripts = (Dictionary<string, string>)instance.GetType()
                .GetField("_tableScripts", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(instance);
            scripts.Should().NotBeNull();
            scripts?.Count.Should().Be(71);
            scripts?.ContainsKey("AnnounceCommands").Should().Be(true);
            scripts?.ContainsKey("DriveRecords").Should().Be(true);
            scripts?.ContainsKey("InstructorAnalysis").Should().Be(true);
            scripts?.ContainsKey("MobileDevice").Should().Be(true);
            scripts?.ContainsKey("ViewDriveRecord").Should().Be(true);

            var fields = (Dictionary<string, List<string>>)instance.GetType()
                .GetField("_tableFields", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(instance);
            fields.Should().NotBeNull();
            fields?.Count.Should().Be(28);
            fields?.ContainsKey("AnnounceCommands").Should().Be(true);
            fields?["AnnounceCommands"].Count.Should().Be(11);
            fields?["AnnounceCommands"][0].Should().Be("Id");
            fields?["AnnounceCommands"][10].Should().Be("TableNamessss");
            fields?.ContainsKey("TrainNoLine").Should().Be(true);
            fields?["TrainNoLine"].Count.Should().Be(7);
            fields?["TrainNoLine"][0].Should().Be("Id");
            fields?["TrainNoLine"][6].Should().Be("TableNamessss");
        }

        [TestMethod]
        public void TestCreateSqliteTables()
        {
            var instance = new MsSqlToSqlite();
            ReflectorHelper.InvokeMethod(instance, "CreateSqliteTables");

            var sql = "SELECT name FROM sqlite_master WHERE type='table' AND name='TrainNoLine';";
            var res = _sqliteHelper.ExecuteScalar(_connStr, CommandType.Text, sql);
            res.Should().NotBeNull();
            res?.ToString().Should().Be("TrainNoLine");
        }

        [TestMethod]
        public void TestGetDataTable()
        {
            var fields = new List<string> {"Name", "Age", "Birth", "Unknown"};
            var list = new List<Person>
            {
                new Person { Name = "Test1", Age = 1, Birth = new DateTime(1999, 6, 10) },
                new Person { Name = "Test2", Age = 2, Birth = new DateTime(2000, 8, 15) }
            };

            var table = ReflectorHelper.InvokeMethod(new MsSqlToSqlite(), "GetDataTable", fields, list) as DataTable;
            table.Should().NotBeNull();
            table?.Columns.Count.Should().Be(3);
            table?.Columns[0].ColumnName.Should().Be("Name");
            table?.Columns[1].ColumnName.Should().Be("Age");
            table?.Columns[2].ColumnName.Should().Be("Birth");
            table?.Rows.Count.Should().Be(2);
            table?.Rows[0][0].Should().Be("Test1");
            table?.Rows[0][1].Should().Be(1);
            table?.Rows[0][2].Should().Be(list[0].Birth);
            table?.Rows[1][0].Should().Be("Test2");
            table?.Rows[1][1].Should().Be(2);
            table?.Rows[1][2].Should().Be(list[1].Birth);
        }

        [TestMethod]
        public void TestCopyFull()
        {
            ReflectorHelper.InvokeMethod(new MsSqlToSqlite(), "CopyFull");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birth { get; set; }
        public char Sex { get; set; }
    }
}
