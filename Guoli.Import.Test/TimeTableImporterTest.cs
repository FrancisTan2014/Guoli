using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;

namespace Guoli.Import.Test
{
    class TestSuite
    {
        /// <summary>
        /// 读取上行表格
        /// </summary>
        public static ISheet GetSheet()
        {
            var path = PathExtension.MapPath("test-upward.xlsx"); // 上行

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var workBook = new XSSFWorkbook(fs);
                return workBook.GetSheetAt(0);
            }
        }

        /// <summary>
        /// 读取下行表格
        /// </summary>
        public static ISheet GetDownwardSheet()
        {
            var path = PathExtension.MapPath("test-downward.xlsx"); // 下行

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var workBook = new XSSFWorkbook(fs);
                return workBook.GetSheetAt(0);
            }
        }

        /// <summary>
        /// 读取货车车次表格
        /// </summary>
        /// <returns></returns>
        public static ISheet GetHuocheSheet()
        {
            var path = PathExtension.MapPath("test-huoche.xls"); // 下行

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var workBook = new HSSFWorkbook(fs);
                return workBook.GetSheetAt(0);
            }
        }

        public static IRow GetRow(int index)
        {
            var sheet = GetSheet();
            return sheet.GetRow(index);
        }
    }

    [TestClass]
    public class TimeTableImporterTest
    {
        [TestMethod]
        public void TestIsUpward()
        {
            var trainNo = "Z180";
            var isUpward = (bool) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "IsUpward", trainNo);
            isUpward.Should().Be(true, "Z180车次尾号是偶数，根据规定，此类车次为上行方向");
        }

        [TestMethod]
        public void TestGetTrainNo()
        {
            var sheet = TestSuite.GetSheet();
            var row = sheet.GetRow(4);
            var trainNo = (TrainNo) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "GetTrainNo", row);
            trainNo.Should().NotBe(null, "测试表格中第五行包含车次信息");
            trainNo.Code.Should().Be("K");
            trainNo.Direction.Should().Be("上行");
            trainNo.FirstStation.Should().Be("呼和浩特");
            trainNo.FullName.Should().Be("K2014");
            trainNo.LastStation.Should().Be("集宁南");
            trainNo.Number.Should().Be("2014");
            trainNo.RunType.Should().Be(1);
        }

        [TestMethod]
        public void TestGetLine()
        {
            var sheet = TestSuite.GetSheet();
            var row = sheet.GetRow(4);
            var line = (BaseLine) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "GetLine", row);
            line.Should().NotBe(null, "测试表格中第五行包含线路信息");
            line.FirstStation.Should().Be("呼和浩特");
            line.LastStation.Should().Be("集宁南");
            line.LineName.Should().Be("呼和浩特-集宁南");
        }

        [TestMethod]
        public void TestIsStyleOne()
        {
            var sheet = TestSuite.GetSheet();
            var isValid = (bool) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "IsStyleOne", sheet);
            isValid.Should().Be(true, "测试表格完全符合TimeTableImporter类所要求的格式");
        }

        [TestMethod]
        public void TestIsStyleTwo()
        {
            var sheet = TestSuite.GetHuocheSheet();
            var isValid = (bool)ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "IsStyleTwo", sheet);
            isValid.Should().Be(true, "测试表格符合第二种格式要求");
        }

        [TestMethod]
        public void TestIsEmptyRow()
        {
            var sheet = TestSuite.GetSheet();
            var row = sheet.GetRow(sheet.LastRowNum);
            var isEmpty = (bool) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "IsEmptyRow", row);
            isEmpty.Should().Be(true, "测试表格最后一行为空");
        }

        [TestMethod]
        public void TestGetStation()
        {
            var row = TestSuite.GetRow(6);
            var station = (BaseStation) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "GetStation", row);
            station.Should().NotBe(null, "给定数据源中有车站名称");
            station.Spell.Should().Be("zjkn", "车站名称为张家口南");
            station.StationName.Should().Be("张家口南");
        }

        [TestMethod]
        public void TestGetTrainMoment()
        {
            var row1 = TestSuite.GetRow(24);
            var row2 = TestSuite.GetRow(25);
            var moment =
                (TrainMoment) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "GetTrainMoment", row1, row2);
            moment.Should().NotBe(null);
            moment.ArriveTime.Should().Be("17:43:00");
            moment.DepartTime.Should().Be("18:05:00");
            moment.IntervalKms.Should().Be(8);
            moment.StopMinutes.Should().Be(22);
            moment.SuggestSpeed.Should().Be(48);
        }

        [TestMethod]
        public void TestGetTime()
        {
            var sheet = TestSuite.GetDownwardSheet();
            var row = sheet.GetRow(48);
            var cell = row.GetCell(5);
            var time = (string) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "GetTime", cell);
            time.Should().Be("18:54:00");

            cell = row.GetCell(6);
            time = (string) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "GetTime", cell);
            time.Should().Be("19:05:00");
        }

        [TestMethod]
        public void TestTimeFormatter()
        {
            var res = (string)ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "TimeFormatter", "48");
            res.Should().Be("48");

            res = (string)ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "TimeFormatter", "4830");
            res.Should().Be("48");

            res = (string)ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "TimeFormatter", "23:30");
            res.Should().Be("23:30");

            res = (string)ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "TimeFormatter", "23:1530");
            res.Should().Be("23:15");
        }

        /// <summary>
        /// 上行表格导入测试
        /// </summary>
        [TestMethod]
        public void TestGetTimeTableUpward()
        {
            var sheet = TestSuite.GetSheet();
            var timeTable =
                (TimeTable) ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "GetTimeTableOfStyleOne", sheet);

            timeTable.Should().NotBe(null);

            timeTable.Line.Should().NotBe(null);
            timeTable.Line.FirstStation.Should().Be("呼和浩特");
            timeTable.Line.LastStation.Should().Be("集宁南");
            timeTable.Line.LineName.Should().Be("呼和浩特-集宁南");

            timeTable.TrainNo.Should().NotBe(null);
            timeTable.TrainNo.Code.Should().Be("K");
            timeTable.TrainNo.Direction.Should().Be("上行");
            timeTable.TrainNo.FirstStation.Should().Be("呼和浩特");
            timeTable.TrainNo.FullName.Should().Be("K2014");
            timeTable.TrainNo.LastStation.Should().Be("集宁南");
            timeTable.TrainNo.Number.Should().Be("2014");
            timeTable.TrainNo.RunType.Should().Be(1);

            timeTable.Stations.Count.Should().Be(8);
            timeTable.Stations.First().StationName.Should().Be("呼和浩特");
            timeTable.Stations.Last().StationName.Should().Be("集宁南");

            timeTable.Moments.Count.Should().Be(8);
            timeTable.Moments.First().ArriveTime.Should().Be("");
            timeTable.Moments.First().DepartTime.Should().Be("16:10:00");
            timeTable.Moments.Last().ArriveTime.Should().Be("17:43:00");
            timeTable.Moments.Last().DepartTime.Should().Be("18:05:00");
        }

        /// <summary>
        /// 下行表格导入测试
        /// </summary>
        [TestMethod]
        public void TestGetTimeTableDownward()
        {
            var sheet = TestSuite.GetDownwardSheet();
            var timeTable =
                (TimeTable)ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "GetTimeTableOfStyleOne", sheet);

            timeTable.Should().NotBe(null);

            timeTable.Line.Should().NotBe(null);
            timeTable.Line.FirstStation.Should().Be("大同");
            timeTable.Line.LastStation.Should().Be("包头");
            timeTable.Line.LineName.Should().Be("大同-包头");

            timeTable.TrainNo.Should().NotBe(null);
            timeTable.TrainNo.Code.Should().Be("K");
            timeTable.TrainNo.Direction.Should().Be("下行");
            timeTable.TrainNo.FirstStation.Should().Be("大同");
            timeTable.TrainNo.FullName.Should().Be("K1277");
            timeTable.TrainNo.LastStation.Should().Be("包头");
            timeTable.TrainNo.Number.Should().Be("1277");
            timeTable.TrainNo.RunType.Should().Be(1);

            timeTable.Stations.Count.Should().Be(27);
            timeTable.Stations.First().StationName.Should().Be("大同");
            timeTable.Stations.Last().StationName.Should().Be("包头");
            timeTable.Stations[6].StationName.Should().Be("新安庄");

            timeTable.Moments.Count.Should().Be(27);
            timeTable.Moments.First().ArriveTime.Should().Be("13:55:00");
            timeTable.Moments.First().DepartTime.Should().Be("14:11:00");
            timeTable.Moments.Last().ArriveTime.Should().Be("20:30:00");
            timeTable.Moments.Last().DepartTime.Should().Be("");
        }

        /// <summary>
        /// 货车表格导入测试
        /// </summary>
        [TestMethod]
        public void TestGetTimeTableOfStyleTwo()
        {
            var sheet = TestSuite.GetHuocheSheet();
            var tables = (List<TimeTable>)ReflectorHelper.InvokeStaticMethod(typeof(TimeTableImporter), "GetTimeTableOfStyleTwo", sheet);

            tables.Should().NotBeNull();
            tables.Count.Should().Be(12);

            var first = tables[0];
            first.Line.FirstStation.Should().Be("古店");
            first.Line.LastStation.Should().Be("集宁南");
            first.Line.LineName.Should().Be("古店-集宁南");
            first.TrainNo.FullName.Should().Be("22001");
            first.Stations.Count.Should().Be(10);
            first.Stations.First().StationName.Should().Be("古店");
            first.Stations.First().Spell.Should().Be("gd");
            first.Stations.Last().StationName.Should().Be("集宁南");
            first.Stations.Last().Spell.Should().Be("jnn");
            first.Moments.Count.Should().Be(10);
            first.Moments.First().ArriveTime.Should().Be(""); //??
            first.Moments.First().DepartTime.Should().Be("21:30");
            first.Moments.Last().ArriveTime.Should().Be("23:16"); //??
            first.Moments.Last().DepartTime.Should().Be("0:02");

            var eighth = tables[7];
            eighth.Line.FirstStation.Should().Be("古店");
            eighth.Line.LastStation.Should().Be("集宁");
            eighth.Line.LineName.Should().Be("古店-集宁");
            eighth.TrainNo.FullName.Should().Be("72601");
            eighth.Stations.Count.Should().Be(11);
            eighth.Stations.First().StationName.Should().Be("古店");
            eighth.Stations.First().Spell.Should().Be("gd");
            eighth.Stations.Last().StationName.Should().Be("集宁");
            eighth.Stations.Last().Spell.Should().Be("jn");
            eighth.Moments.Count.Should().Be(11);
            eighth.Moments.First().ArriveTime.Should().Be(""); //??
            eighth.Moments.First().DepartTime.Should().Be("19:56");
            eighth.Moments.Last().ArriveTime.Should().Be("23:47"); //??
            eighth.Moments.Last().DepartTime.Should().Be("0:18");
        }

        [TestMethod]
        public void TestClearSql()
        {
            var tables = new List<string> { "TrainMoment", "TrainNoLine", "LineStations", "BaseStation", "BaseLine", "TrainNo" };
            var truncate = $"TRUNCATE TABLE {string.Join("; TRUNCATE TABLE ", tables)};";
            var delete = $"DELETE FROM DbUpdateLog WHERE DELETE FROM DbUpdateLog WHERE TableName IN( {string.Join(", ", tables.Select(s => $"'{s}'"))} );";

            truncate.Should()
                .Be(
                    "TRUNCATE TABLE TrainMoment; TRUNCATE TABLE TrainNoLine; TRUNCATE TABLE LineStations; TRUNCATE TABLE BaseStation; TRUNCATE TABLE BaseLine; TRUNCATE TABLE TrainNo;");
            delete.Should().Be("DELETE FROM DbUpdateLog WHERE DELETE FROM DbUpdateLog WHERE TableName IN( 'TrainMoment', 'TrainNoLine', 'LineStations', 'BaseStation', 'BaseLine', 'TrainNo' );");
        }
    }
}
