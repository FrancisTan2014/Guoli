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
            var isUpward = (bool) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "IsUpward", trainNo);
            isUpward.Should().Be(true, "Z180车次尾号是偶数，根据规定，此类车次为上行方向");
        }

        [TestMethod]
        public void TestGetTrainNo()
        {
            var sheet = TestSuite.GetSheet();
            var row = sheet.GetRow(4);
            var trainNo = (TrainNo) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "GetTrainNo", row);
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
            var line = (BaseLine) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "GetLine", row);
            line.Should().NotBe(null, "测试表格中第五行包含线路信息");
            line.FirstStation.Should().Be("呼和浩特");
            line.LastStation.Should().Be("集宁南");
            line.LineName.Should().Be("呼和浩特-集宁南");
        }

        [TestMethod]
        public void TestIsValid()
        {
            var sheet = TestSuite.GetSheet();
            var isValid = (bool) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "IsValid", sheet);
            isValid.Should().Be(true, "测试表格完全符合TimeTableImporter类所要求的格式");
        }

        [TestMethod]
        public void TestIsEmptyRow()
        {
            var sheet = TestSuite.GetSheet();
            var row = sheet.GetRow(sheet.LastRowNum);
            var isEmpty = (bool) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "IsEmptyRow", row);
            isEmpty.Should().Be(true, "测试表格最后一行为空");
        }

        [TestMethod]
        public void TestGetStation()
        {
            var row = TestSuite.GetRow(6);
            var station = (BaseStation) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "GetStation", row);
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
                (TrainMoment) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "GetTrainMoment", row1, row2);
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
            var time = (string) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "GetTime", cell);
            time.Should().Be("18:54:00");

            cell = row.GetCell(6);
            time = (string) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "GetTime", cell);
            time.Should().Be("19:05:00");
        }

        /// <summary>
        /// 上行表格导入测试
        /// </summary>
        [TestMethod]
        public void TestGetTimeTableUpward()
        {
            var sheet = TestSuite.GetSheet();
            var timeTable =
                (TimeTable) ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "GetTimeTable", sheet);

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
        /// 下午表格导入测试
        /// </summary>
        [TestMethod]
        public void TestGetTimeTableDownward()
        {
            var sheet = TestSuite.GetDownwardSheet();
            var timeTable =
                (TimeTable)ReflectorHelper.RunStaticMethod(typeof(TimeTableImporter), "GetTimeTable", sheet);

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
    }
}
