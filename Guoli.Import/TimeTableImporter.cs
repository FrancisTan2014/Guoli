﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Guoli.Import
{
    /// <summary>
    /// 此类表示从一个列车时刻表中提取出来的各类信息
    /// 它们整体表示一个区段的完整的列车时刻表
    /// 包含：
    ///     一个<see cref="TrainNo"/>对象
    ///     一个<see cref="BaseLine"/>对象
    ///     一个<see cref="TrainNoLine"/>对象     
    ///     一个<see cref="BaseStation"/>对象集合
    ///     一个<see cref="TrainMoment"/>对象集合
    ///     一个<see cref="LineStations"/>对象集合
    /// </summary>
    public sealed class TimeTable
    {
        /// <summary>
        /// 车次
        /// </summary>
        public TrainNo TrainNo { get; set; }
        /// <summary>
        /// 线路（区段）
        /// </summary>
        public BaseLine Line { get; set; }
        /// <summary>
        /// 车次与线路关系
        /// </summary>
        public TrainNoLine TrainNoLineRelation { get; set; }
        /// <summary>
        /// 车站信息
        /// </summary>
        public List<BaseStation> Stations { get; set; }
        /// <summary>
        /// 列车时刻
        /// </summary>
        public List<TrainMoment> Moments { get; set; }
        /// <summary>
        /// 线路与车站关系
        /// </summary>
        public List<LineStations> LineStationRelation { get; set; }

        public TimeTable()
        {
            Stations = new List<BaseStation>();
            Moments = new List<TrainMoment>();
            LineStationRelation = new List<LineStations>();
        }
    }

    /// <summary>
    /// 列车时刻数据导入工具类
    /// 其中：
    ///    格式一：参考文件'/Templates/客车时刻表.xls'
    ///    格式二：参考文件'/Templates/货车时刻表.xls'
    /// </summary>
    public static class TimeTableImporter
    {
        /// <summary>
        /// excel表格正文开始行的索引
        /// </summary>
        private const int STARTINDEX = 6;

        // 各信息（如车站名称、列车时刻）所在单元格索引
        private static int _stationNameCellIndex = 3;
        private static int _leaveTimeCellIndex = 6;
        private static int _arriveTimeCellIndex = 5;
        private static int _stopTimeCellIndex = 7;
        private static int _distanceCellIndex = 4;
        private static int _speedCellIndex = 2;

        private static List<BaseStation> _stationCaches;
        private static List<TrainNo> _trainNoCaches;

        private static void LoadCaches()
        {
            var stationBll = new BaseStationBll();
            var trainNoBll = new TrainNoBll();
            _stationCaches = stationBll.QueryList("IsDelete=0").ToList();
            _trainNoCaches = trainNoBll.QueryList("IsDelete=0").ToList();
        }
        /// <summary>
        /// 读取指定路径的列表时刻表
        /// 分解为车站-线路-车次等基础数据
        /// 写入系统数据库
        /// 此方法极度依赖excel表的格式：
        ///     1. 第五行（表头上一行）必须有车次、区段信息，且格式必须为：车次：XXX  区段：XXX-XXX
        ///     2. 区段中的开始站名及结束站名必须与表格中的一一对应，因为它们将作为筛选条件，否则将会读取到非本段担当的车站信息
        ///     3. 表格从第七行开始必须是一行车站（第4单元格）、列车时刻信息（6、7单元格）、站停时间（8单元格）
        ///        一行是区间运行时间（2单元格）、区间速度（3单元格）、区间公里（5单元格），并以这种格式交错排列
        /// </summary>
        /// <param name="filePath">列车时刻表文件绝对路径</param>
        public static void Execute(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workBook;
                try
                {
                    // excel 2003 及以下版本
                    workBook = new HSSFWorkbook(fs);
                }
                catch
                {
                    // excel 2007 及以上版本
                    workBook = new XSSFWorkbook(fs);
                }

                // 加载缓存，避免频繁查询数据库
                LoadCaches();

                foreach (ISheet sheet in workBook)
                {
                    try
                    {
                        var style = GetSheetStyle(sheet);
                        switch (style)
                        {
                            case 1:
                                var timeTable = GetTimeTableOfStyleOne(sheet);
                                AddTimeTable(timeTable);
                                break;

                            case 2:
                                var tables = GetTimeTableOfStyleTwo(sheet);
                                AddTimeTable(tables.ToArray());
                                break;

                            case -1:
                            default:
                                continue;
                        }
                    }
                    catch (Exception e)
                    {
                        // Ignore
                    }
                }
            }
        }

        /// <summary>
        /// 获取表格的格式编号
        ///    1：与'/Templates/客车时刻表.xls'一致
        ///    2：与'/Templates/货车车时刻表.xls'一致
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static int GetSheetStyle(ISheet sheet)
        {
            if (IsStyleOne(sheet))
            {
                return 1;
            }

            if (IsStyleTwo(sheet))
            {
                return 2;
            }

            return -1;
        }

        /// <summary>
        /// 验证表格格式是否符合第一种格式要求
        /// 表格行数必须大于7行
        /// 每行单元格数必须大于7
        /// 第五行应该包含车次、区段等信息
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static bool IsStyleOne(ISheet sheet)
        {
            if (sheet.LastRowNum < 6)
            {
                return false;
            }

            var fifthRow = sheet.GetRow(4);
            if (fifthRow.LastCellNum < 6)
            {
                return false;
            }

            var txt = fifthRow.Cells[0].StringCellValue.Trim();
            if (!txt.Contains("车次") && !txt.Contains("区段"))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 验证表格格式是否符合第二种格式要求
        /// 表格行数必须大于9行
        /// 每行单元格数必须大于1个
        /// 第四行第一个或者第三个单元格的值应该是“始发站”
        /// 第六行第一个或者第三个单元格的值应该是“列车种类”
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static bool IsStyleTwo(ISheet sheet)
        {
            if (sheet.LastRowNum < 8)
            {
                return false;
            }

            var fourthRow = sheet.GetRow(3);
            if (fourthRow.LastCellNum < 2)
            {
                return false;
            }

            if (!fourthRow.Cells.Exists(cell => cell.ToString().Trim() == "始发站"))
            {
                return false;
            }

            var sixthRow = sheet.GetRow(5);
            if (!sixthRow.Cells.Exists(cell => cell.ToString().Trim() == "列车种类"))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 按照"格式一"从指定的<see cref="ISheet"/>对象中提取信息
        /// 并创建<see cref="TimeTable"/>对象返回
        /// </summary>
        /// <param name="sheet">将作为数据源的<see cref="ISheet"/>对象</param>
        /// <returns><see cref="TimeTable"/>对象</returns>
        private static TimeTable GetTimeTableOfStyleOne(ISheet sheet)
        {
            var timeTable = new TimeTable();

            // 从第五行第一个单元格中提取车次、线路信息
            var fifthRow = sheet.GetRow(4);
            timeTable.TrainNo = GetTrainNo(fifthRow);
            timeTable.Line = GetLine(fifthRow);

            // 判断是否是动车时刻表，若是，则将所有单元格索引+1
            InitialCellIndexs(timeTable.TrainNo.Code);

            // 判断车次方向，若是上行，则将表格从后往前循环
            // 反之，则从前往后循环（从索引6开始）
            var isUpword = IsUpward(timeTable.TrainNo.FullName);
            var start = isUpword ? sheet.LastRowNum : STARTINDEX;
            var end = isUpword ? STARTINDEX : sheet.LastRowNum;

            // 循环表格，提取信息到timeTable对象中
            // 每次循环读取两行数据，index相应的加/减2
            // 循环结束条件为：当前读取到的车站名称与区段结束车站名称相同
            Func<int, int> getNextIndex = i => isUpword ? i - 1 : i + 1; // 此方法用于处理索引的递增或者递减
            var loopIsEnd = false;
            var index = start;
            while (!loopIsEnd)
            {
                var stationRow = sheet.GetRow(index);
                index = getNextIndex(index);

                // 若读取到的是空行，则跳过继续读取下一行
                if (!IsEmptyRow(stationRow))
                {
                    var speedRow = sheet.GetRow(index);
                    index = getNextIndex(index);

                    // 将读取两行数据：
                    //  第一行数据中包含车站名称、发车时间以及到达时间
                    //  第二行数据中包含区间运行时间， 区间平均速度以及区间停车时间
                    var moment = GetTrainMoment(stationRow, speedRow);
                    if (moment != null)
                    {
                        var station = GetStation(stationRow);
                        timeTable.Stations.Add(station);
                        timeTable.Moments.Add(moment);

                        if (station.StationName == timeTable.TrainNo.LastStation)
                        {
                            loopIsEnd = true; // 循环结束
                        }
                    }
                }

                // 防止死循环的情况发生
                if (stationRow == null)
                {
                    loopIsEnd = true; // 循环结束
                }
            }

            return timeTable;
        }

        /// <summary>
        /// 按照"格式二"从指定的<see cref="ISheet"/>对象中提取信息
        /// 并创建<see cref="TimeTable"/>对象集合返回
        /// </summary>
        /// <param name="sheet">将作为数据源的<see cref="ISheet"/>对象</param>
        /// <returns><see cref="TimeTable"/>对象集合</returns>
        private static List<TimeTable> GetTimeTableOfStyleTwo(ISheet sheet)
        {
            // 从第二行中获取列车运行方向
            var row = sheet.GetRow(1);
            var title = row.Cells[0].ToString();
            // 从字符串"古店-集宁间上行列车时刻表"中提取"上行"
            var direction = title.Substring(title.IndexOf("行列车时刻表") - 1, 2);

            // 从第八行和第九行中提取所有车次
            row = sheet.GetRow(7);
            var row9 = sheet.GetRow(8);
            var stationColNum = Regex.Replace(row.Cells[0].ToString(), @"\s", "") == "区间公里" ? 2 : 0; // 车站所在列的索引
            var trainNos = new List<string>();
            for (var i = stationColNum + 1; i < row.Cells.Count; i++)
            {
                // 车次列索引从车站后一列开始
                var value = row.Cells[i].ToString().Trim();
                var value1 = row9.Cells[i].ToString().Trim(); // 有的车次占了第八和第九两行
                if (!string.IsNullOrEmpty(value))
                {
                    trainNos.Add(value + value1);
                }
            }

            // 从第一或者第三列中提取所有车站（有的表格车站在第三列，而有的在第一列）
            // 从第十行开始循环
            var stations = new List<BaseStation>();
            for (var i = 9; i < sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);
                var txt = row.Cells[stationColNum].ToString();
                if (!string.IsNullOrEmpty(txt))
                {
                    var name = txt.Trim();
                    var pinyin = PinyinHelper.GetInitials(name).ToLower();
                    stations.Add(new BaseStation { Spell = pinyin, StationName = name });
                }
            }

            // 循环车次列表，生成列车时刻表集合
            var startColNum = stationColNum + 1;
            var timeTables = new List<TimeTable>();
            for (var trainNoIndex = 0; trainNoIndex < trainNos.Count; trainNoIndex++)
            {
                var timeTable = new TimeTable();

                // 从第二或者第四列开始，逐列获取列车时刻表
                var sort = 1;
                var stationIndex = 0; // 通过此索引从车站列表中获取与时刻表对应的车站
                var colIndex = startColNum + trainNoIndex; // 随着车次索引的增加，相应的改变获取时刻表的单元格索引
                for (var rowIndex = 9; rowIndex < sheet.LastRowNum; rowIndex++)
                {
                    row = sheet.GetRow(rowIndex);
                    var arrive = row.Cells[colIndex].ToString().Trim().Replace("...", "");

                    rowIndex++;
                    row = sheet.GetRow(rowIndex);
                    var start = row.Cells[colIndex].ToString().Trim().Replace("...", "");

                    // 出发或者到达时间任意一个不为空
                    // 则表明本车次将经过stationIndex所对应的车站
                    // 否则表示本车次不经过此车站，则不将此车站添加到
                    // 本车次对应的车站列表中
                    if (!string.IsNullOrEmpty(arrive) || !string.IsNullOrEmpty(start))
                    {
                        arrive = TimeFormatter(arrive);
                        start = TimeFormatter(start);
                        timeTable.Stations.Add(stations[stationIndex]);
                        timeTable.Moments.Add(new TrainMoment { ArriveTime = arrive, DepartTime = start, Sort = sort++ });
                    }

                    stationIndex++;
                    // 如果stationIndex已经超出了车站数量，则结束循环
                    if (stationIndex >= stations.Count)
                    {
                        break;
                    }
                }

                // 重置索引和排序
                stationIndex = 0;
                sort = 1;

                // 如果是上行车次，需要将车站及列车时刻反转
                if (direction == "上行")
                {
                    timeTable.Stations.Reverse();
                    timeTable.Moments.Reverse();

                    // 改变序号，并将出发及到达时间互换
                    sort = 1;
                    timeTable.Moments.ForEach(item =>
                    {
                        var temp = item.ArriveTime;
                        item.ArriveTime = item.DepartTime;
                        item.DepartTime = temp;
                        item.Sort = sort++;
                    });
                }

                // 创建车次及线路对象
                var firstStation = timeTable.Stations.First().StationName;
                var lastStation = timeTable.Stations.Last().StationName;
                timeTable.TrainNo = new TrainNo { Direction = direction, FullName = trainNos[trainNoIndex], FirstStation = firstStation, LastStation = lastStation, RunType = 2 };
                timeTable.Line = new BaseLine { FirstStation = firstStation, LastStation = lastStation, LineName = $"{firstStation}-{lastStation}" };

                timeTables.Add(timeTable);
            }

            return timeTables;
        }

        /// <summary>
        /// 将从excel表格中提取出的<see cref="TimeTable"/>对象写入数据库
        /// </summary>
        /// <param name="table">待处理的列表时刻表</param>
        /// <param name="trainNoExists">告知调用者车次是否已存在并需要更新</param>
        private static void AddTimeTable(params TimeTable[] tables)
        {
            foreach (var table in tables)
            {
                // 查询车次是否已存在
                var trainNoExists = _trainNoCaches.Exists(item => item.FullName == table.TrainNo.FullName);

                if (!trainNoExists)
                {
                    // 将车次、车站、线路信息写入数据库
                    table.Stations = WriteStations(table.Stations);
                    WriteTrainNo(table);
                    WriteLine(table);

                    // 构造线路-车站关系并写入数据库
                    WriteLineStaionRelation(table);

                    // 构造车次-线路关系并写入数据库
                    table.TrainNoLineRelation = WriteTrainNoLineRelation(table.TrainNo, table.Line);

                    // 为列车时刻表中的车站Id、车次线路表Id赋值，并写入数据库
                    WriteTrainMoments(table);
                }
                else
                {
                    // 车次若已存在，则将当前列车时刻表信息存储下来
                    // 并提示操作者，若操作者需要更新此车次信息，再读取此列车时刻表
                }
            }
        }

        /// <summary>
        /// 构造线路-车站关系并写入数据库
        /// </summary>
        /// <param name="table"></param>
        private static void WriteLineStaionRelation(TimeTable table)
        {
            // 构造线路-车站关系并写入数据库
            var lineStationRelation = new List<LineStations>();
            for (var i = 0; i < table.Stations.Count; i++)
            {
                lineStationRelation.Add(new LineStations
                {
                    LineId = table.Line.Id,
                    Sort = i,
                    StationId = table.Stations[i].Id,
                    StationName = table.Stations[i].StationName
                });
            }
            var lineStationsBll = new LineStationsBll();

            var startId = (int)lineStationsBll.GetMaxId(); // 记录插入之前的最大ID
            lineStationsBll.BulkInsert(lineStationRelation);
            DataUpdateLog.BulkUpdate(nameof(LineStations), startId); // 将数据更新记录同步到DbUpdataLog表中
        }

        /// <summary>
        /// 将线路信息写入数据库
        /// </summary>
        /// <param name="table"></param>
        private static void WriteLine(TimeTable table)
        {
            var lineBll = new BaseLineBll();
            table.Line.FirstStationId = _stationCaches.Find(item => item.StationName == table.Line.FirstStation).Id;
            table.Line.LastStationId = _stationCaches.Find(item => item.StationName == table.Line.LastStation).Id;
            table.Line = lineBll.Insert(table.Line);

            DataUpdateLog.SingleUpdate(nameof(BaseLine), table.Line.Id, DataUpdateType.Insert); // 将数据更新记录同步到DbUpdataLog表中
        }

        /// <summary>
        /// 将车次信息写入数据库
        /// </summary>
        /// <param name="table"></param>
        private static void WriteTrainNo(TimeTable table)
        {
            var trainNoBll = new TrainNoBll();
            table.TrainNo = trainNoBll.Insert(table.TrainNo);

            DataUpdateLog.SingleUpdate(nameof(TrainNo), table.TrainNo.Id, DataUpdateType.Insert); // 将数据更新记录同步到DbUpdataLog表中

            _trainNoCaches.Add(table.TrainNo);
        }

        /// <summary>
        /// 为列车时刻表中的车站Id、车次线路表Id赋值，并写入数据库
        /// </summary>
        private static void WriteTrainMoments(TimeTable table)
        {
            for (var i = 0; i < table.Moments.Count; i++)
            {
                table.Moments[i].Sort = i;
                table.Moments[i].TrainStationId = table.Stations[i].Id;
                table.Moments[i].TrainNoLineId = table.TrainNoLineRelation.Id;
            }

            var bll = new TrainMomentBll();

            var maxId = (int)bll.GetMaxId();
            bll.BulkInsert(table.Moments);
            DataUpdateLog.BulkUpdate(nameof(TrainMoment), maxId);
        }

        /// <summary>
        /// 构造车次-线路关系并写入数据库
        /// </summary>
        private static TrainNoLine WriteTrainNoLineRelation(TrainNo trainNo, BaseLine line)
        {
            var trainNoLineRelation = new TrainNoLine
            {
                LineId = line.Id,
                Sort = 0,
                TrainNoId = trainNo.Id,
                UpdateTime = DateTime.Now
            };
            new TrainNoLineBll().Insert(trainNoLineRelation);

            DataUpdateLog.SingleUpdate(nameof(TrainNoLine), trainNoLineRelation.Id, DataUpdateType.Insert);

            return trainNoLineRelation;
        }
        /// <summary>
        /// 将指定集合中的车站信息写入数据库，并确保数据库中不会存在同名的车站
        /// 对于已经存在的车站则查询数据库，将新值存入返回的集合中
        /// 对于新的车站则插入数据库，将插入后的新值存入返回的集合中
        /// 最终返回的集合中所有的车站均带有唯一主键
        /// </summary>
        /// <param name="stations">待写稿的车站信息集合</param>
        /// <returns><see cref="List{BaseStation}"/>对象</returns>
        private static List<BaseStation> WriteStations(List<BaseStation> stations)
        {
            var stationBll = new BaseStationBll();
            var newStations = new List<BaseStation>();

            stations.ForEach(s =>
            {
                var temp = _stationCaches.Find(item => item.StationName == s.StationName);
                if (temp != null)
                {
                    newStations.Add(temp);
                }
                else
                {
                    stationBll.Insert(s);
                    DataUpdateLog.SingleUpdate(nameof(BaseStation), s.Id, DataUpdateType.Insert);

                    newStations.Add(s);
                    _stationCaches.Add(s);
                }
            });

            return newStations;
        }

        /// <summary>
        /// 根据车次头字母初始化提取各类信息的单元格索引（动车与其他车不一样）
        /// </summary>
        /// <param name="code"></param>
        private static void InitialCellIndexs(string code)
        {
            if (code.ToUpper() == "D")
            {
                _stationNameCellIndex = 4;
                _leaveTimeCellIndex = 7;
                _arriveTimeCellIndex = 6;
                _stopTimeCellIndex = 8;
                _distanceCellIndex = 5;
                _speedCellIndex = 3;
            }
            else
            {
                _stationNameCellIndex = 3;
                _leaveTimeCellIndex = 6;
                _arriveTimeCellIndex = 5;
                _stopTimeCellIndex = 7;
                _distanceCellIndex = 4;
                _speedCellIndex = 2;
            }

        }

        /// <summary>
        /// 判断指定车次火车是否是上行线（车次尾号是偶数）
        /// 若指定车次为上行线则返回<c>true</c>，否则返回<c>false</c>
        /// </summary>
        /// <param name="trainCode">待判断的车次</param>
        /// <returns>表示是否上行线的布尔值</returns>
        private static bool IsUpward(string trainCode)
        {
            var s = Regex.Replace(trainCode, "\\D+", "");
            var code = s.ToInt32();
            return code % 2 == 0;
        }

        /// <summary>
        /// 从给给定行中第一个单元格提取出车次、区段信息
        /// 按照 车次：Z180 区段：XXX-XXX 的格式正则提取
        /// 并创建<see cref="TrainNo"/>对象返回
        /// </summary>
        /// <param name="row">将作为数据源的<see cref="IRow"/>对象</param>
        /// <returns><see cref="TrainNo"/>对象</returns>
        private static TrainNo GetTrainNo(IRow row)
        {
            var txt = row.Cells[0].StringCellValue;
            var pattern = @"车次：(\S+)\s+区段：(\S+)";
            var match = Regex.Match(txt, pattern);
            var trainNo = match.Groups[1].Value;
            var lineName = match.Groups[2].Value;

            var code = Regex.Replace(trainNo, "\\d+", "");
            var number = Regex.Replace(trainNo, "\\D+", "");
            var dir = IsUpward(trainNo) ? "上行" : "下行";
            var stations = lineName.Split('-');

            return new TrainNo
            {
                FullName = trainNo,
                Number = number,
                Code = code,
                Direction = dir,
                FirstStation = stations[0],
                LastStation = stations[1],
                RunType = 1, // 待《根据车次判断列车类型》资料给到之后，用程序判断，目前默认都是客车
                UpdateTime = DateTime.Now
            };
        }

        /// <summary>
        /// 从给定行中提取出区段信息
        /// 按照 区段：XXX-XXX 的格式正则提取
        /// 并创建<see cref="BaseLine"/>对象返回
        /// </summary>
        /// <param name="row">将作为数据源的<see cref="IRow"/>对象</param>
        /// <returns><see cref="BaseLine"/>对象</returns>
        private static BaseLine GetLine(IRow row)
        {
            var txt = row.Cells[0].StringCellValue;
            var pattern = @"区段：(\S+)";
            var match = Regex.Match(txt, pattern);
            var lineName = match.Groups[1].Value;
            var stations = lineName.Split('-');

            return new BaseLine
            {
                FirstStation = stations[0],
                LastStation = stations[1],
                LineName = lineName,
                Spell = "",
                UpdateTime = DateTime.Now
            };
        }

        /// <summary>
        /// 验证给定行是否为空行（前八个单元格均为空）
        /// </summary>
        /// <param name="row">给定的<see cref="IRow"></see>对象</param>
        /// <returns></returns>
        private static bool IsEmptyRow(IRow row)
        {
            if (row == null)
            {
                return true;
            }

            for (var i = 0; i < 8; i++)
            {
                var txt = row.GetCell(i)?.StringCellValue;
                if (!string.IsNullOrEmpty(txt?.Trim()))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 从给定行中的第四个单元格中提取出车站名称
        /// 方法将会把提取出的名称的*号去除
        /// 返回<see cref="BaseStation"></see>类型的实例
        /// 如果第四个单元格中没有车站名称，则返回null
        /// </summary>
        /// <param name="row">将作为数据源的<see cref="IRow"/>对象</param>
        /// <returns><see cref="BaseStation"></see>类型的实例或者null</returns>
        private static BaseStation GetStation(IRow row)
        {
            var name = row.GetCell(_stationNameCellIndex).StringCellValue;
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            name = name.Trim();
            if (name.Contains("*"))
            {
                name = name.Replace("*", "");
            }

            var pinyin = PinyinHelper.GetInitials(name).ToLower();

            return new BaseStation { StationName = name, SN = 0, Spell = pinyin, UpdateTime = DateTime.Now };
        }

        /// <summary>
        /// 从给定两行数据组提取出列车时刻相关数据
        /// 并创建<see cref="TrainMoment"/>对象返回
        /// 若出发时间、到达时间均为空则返回null
        /// </summary>
        /// <param name="momentRow">第6、7、8单元格中分别带有到达、开车时刻、停车时间的<see cref="IRow"/>对象</param>
        /// <param name="speedRow">第2、3、5单元格中分别带有运行时间、运行速度、区间公里的<see cref="IRow"/>对象</param>
        /// <returns><see cref="TrainMoment"/>对象或者null</returns>
        private static TrainMoment GetTrainMoment(IRow momentRow, IRow speedRow)
        {
            var leave = GetTime(momentRow.Cells[_leaveTimeCellIndex]);
            var arrive = GetTime(momentRow.Cells[_arriveTimeCellIndex]);
            if (string.IsNullOrEmpty(leave) && string.IsNullOrEmpty(arrive))
            {
                return null;
            }

            int stopMinutes;
            try
            {
                var stopTimeStr = momentRow.Cells[_stopTimeCellIndex].StringCellValue;
                stopMinutes = string.IsNullOrEmpty(stopTimeStr)
                    ? 0
                    : stopTimeStr.Replace(":00", "").ToInt32();
            }
            catch
            {
                stopMinutes = 0;
            }

            decimal distance;
            decimal speed;
            try
            {
                // 区间（公里、车速）比车站信息数量少一条，当读取到最后一条时
                // 区间（公里、车速）数据获取将会出现异常
                // 为了降低前面逻辑处理的复杂度，此处才选择作这样的处理
                distance = (decimal)speedRow.Cells[_distanceCellIndex].NumericCellValue;
                speed = (decimal)speedRow.Cells[_speedCellIndex].NumericCellValue;
            }
            catch
            {
                distance = 0;
                speed = 0;
            }

            return new TrainMoment
            {
                DepartTime = leave,
                ArriveTime = arrive,
                StopMinutes = stopMinutes,
                IntervalKms = distance,
                SuggestSpeed = speed
            };
        }

        /// <summary>
        /// 创建此方法是为了解决单元格中值的格式不统一的问题
        /// 从给定单元格中提取出时间的 HH:mm:ss 部分
        /// 若单元格中的数据格式为字符串则直接返回
        /// 若单元格中的数据格式为时间类型：
        ///     若小时不为0，则转换为 HH:mm:ss 格式返回
        ///     若小时为0，则返回 mm:ss 格式
        /// </summary>
        /// <param name="cell">将作为数据源的<see cref="ICell"/>对象</param>
        /// <returns>表示时刻的字符串或者空字符串</returns>
        private static string GetTime(ICell cell)
        {
            try
            {
                return cell.StringCellValue;
            }
            catch (InvalidOperationException)
            {
                var time = cell.DateCellValue;
                return time.ToString(time.Hour == 0 ? "mm:ss" : "HH:mm:ss");
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 处理从excel中获取到的时间
        /// 将类似于3030这样的时间处理为30
        /// 若时间是48或者03:48则不变
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private static string TimeFormatter(string time)
        {
            if (!string.IsNullOrEmpty(time))
            {
                var temp = time.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (temp.Length == 1)
                {
                    // 如 48
                    if (temp[0].ToInt32() < 60)
                    {
                        return temp[0];
                    }
                    // 如 4830
                    else
                    {
                        return temp[0].Substring(0, temp[0].Length - 2);
                    }
                }
                else
                {
                    // 如 23:15
                    if (temp[1].ToInt32() < 60)
                    {
                        return time;
                    }
                    // 如 23：1530
                    else
                    {
                        return $"{temp[0]}:{temp[1].Substring(0, temp[1].Length -2)}";
                    }
                }
            }

            return time;
        }
    }
}
