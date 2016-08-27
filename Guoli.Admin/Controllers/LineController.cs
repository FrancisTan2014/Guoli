using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Helpers;
using Microsoft.Ajax.Utilities;   
using WebGrease.Css.Extensions;

namespace Guoli.Admin.Controllers
{ 
    public class LineController : Controller
    {
        #region 异步通用
        /// <summary>
        /// 根据车站拼音/名称/SN编号搜索车站，返回搜索结果
        /// </summary>
        /// <param name="key">车站拼音/名称/SN编号</param>
        /// <returns></returns>
        public JsonResult SearchStations(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return Json(ErrorModel.InputError);
            }

            var stationBll = new BaseStationBll();

            var condition = string.Format("IsDelete=0 AND Spell LIKE '{0}%' OR StationName LIKE '%{0}%' OR SN LIKE '%{0}%'", key);
            var stations = stationBll.QueryList(condition);

            return Json(ErrorModel.GetDataSuccess(stations));
        }

        /// <summary>
        /// 根据线路拼音/名称搜索线路，返回搜索结果
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult SearchLines(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return Json(ErrorModel.InputError);
            }

            var lineBll = new BaseLineBll();
            var condition = string.Format("IsDelete=0 AND Spell LIKE '{0}%' OR LineName LIKE '%{0}%'", key);
            var lines = lineBll.QueryList(condition);

            var json = ErrorModel.GetDataSuccess(lines);
            return Json(json);
        }
        #endregion

        #region 车次管理
        /// <summary>
        /// 车次列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult TrainNo()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetTrainNos()
        {
            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                Request,
                (pageIndex, pageSize) =>
                {
                    var stationBll = new TrainNoBll();

                    int totalCount;
                    var data = stationBll.QueryPageList(pageIndex, pageSize, "UpdateTime",
                        true, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, data);
                }
            );

            return Json(json);
        }

        /// <summary>
        /// 车次编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult TrainNoEdit(int? id)
        {
            ViewBag.Id = id ?? 0;

            return View();
        }

        [HttpPost]
        public JsonResult GetTrainNo(int id)
        {
            var trainNoBll = new TrainNoBll();
            var trainNo = trainNoBll.QuerySingle("IsDelete=0 AND Id=" + id);
            if (trainNo == null)
            {
                return Json(ErrorModel.GetDataFailed);
            }

            var viewLineBll = new ViewTrainNoLIneBll();
            var lines = viewLineBll.QueryList("Id=" + id);

            var json = ErrorModel.GetDataSuccess(new
            {
                trainNo,
                lines
            });

            return Json(json);
        }

        [HttpPost]
        public JsonResult SaveTrainNo()
        {
            var trainNoJson = Request["trainNo"];
            var trainNo = JsonHelper.Deserialize<TrainNo>(trainNoJson);
            if (trainNo == null)
            {
                return Json(ErrorModel.InputError);
            }

            var updateType = trainNo.Id > 0 ? DataUpdateType.Update : DataUpdateType.Insert;

            var trainNoBll = new TrainNoBll();
            var updateSuccess = false;
            if (trainNo.Id > 0)
            {
                updateSuccess = trainNoBll.Update(trainNo);
            }
            else
            {
                // 验证是否存在相同的车次
                var condition = string.Format("FullName='{0}' AND IsDelete=0", trainNo.FullName);
                if (trainNoBll.Exists(condition))
                {
                    return Json(ErrorModel.ExistSameItem);
                }

                var insertedTrainNo = trainNoBll.Insert(trainNo);
                updateSuccess = insertedTrainNo.Id > 0;
            }

            if (!updateSuccess)
            {
                return Json(ErrorModel.OperateFailed);
            }

            DataUpdateLog.SingleUpdate(typeof(TrainNo).Name, trainNo.Id, updateType);

            var linesJson = Request["lines"];
            var lines = JsonHelper.Deserialize<TrainNoLine[]>(linesJson);
            if (lines == null || !lines.Any())
            {
                return Json(ErrorModel.InputError);
            }

            var linesToInsert = lines.Where(line => line.Id == 0).ToArray();
            if (linesToInsert.Any())
            {
                linesToInsert.ForEach(line => { line.TrainNoId = trainNo.Id; });

                var trainNoLineBll = new TrainNoLineBll();
                var maxId = (int)trainNoLineBll.GetMaxId();

                trainNoLineBll.BulkInsert(linesToInsert);

                DataUpdateLog.BulkUpdate(typeof(TrainNoLine).Name, maxId);
            }

            return Json(ErrorModel.OperateSuccess);
        }

        [HttpPost]
        public JsonResult DeleteTrainNoLine(int id)
        {
            var trainNoLineBll = new TrainNoLineBll();
            var deleteSuccess = trainNoLineBll.Delete(id);

            if (deleteSuccess)
            {
                DataUpdateLog.SingleUpdate(typeof(TrainNoLine).Name, id, DataUpdateType.Delete);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        #endregion

        #region 线路管理
        /// <summary>
        /// 线路列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 线路编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult LineEdit(int? id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public JsonResult LineEdit()
        {
            var lineJson = Request["line"];
            var line = JsonHelper.Deserialize<BaseLine>(lineJson);

            var updateType = line.Id > 0 ? DataUpdateType.Update : DataUpdateType.Insert;

            // 更新线路
            var lineUpdateRes = false;
            var lineBll = new BaseLineBll();
            if (line.Id > 0)
            {
                lineUpdateRes = lineBll.Update(line);
            }
            else
            {
                var condition = string.Format("LineName='{0}' AND IsDelete=0", line.LineName);
                if (lineBll.Exists(condition))
                {
                    return Json(ErrorModel.ExistSameItem);
                }

                var insertedLine = lineBll.Insert(line);
                lineUpdateRes = insertedLine.Id > 0;
            }

            // 更新车站
            if (lineUpdateRes)
            {
                // 写入更新记录
                DataUpdateLog.SingleUpdate(typeof(BaseLine).Name, line.Id, updateType);

                var stationsJson = Request["stations"];
                var stations = JsonHelper.Deserialize<LineStations[]>(stationsJson);
                if (!stations.Any())
                {
                    return Json(ErrorModel.OperateSuccess);
                }

                stations.ForEach(f => { f.LineId = line.Id; });

                var stationsToInsert = stations.Where(f => f.Id == 0);
                var lineStationsBll = new LineStationsBll();

                var maxId = (int)lineStationsBll.GetMaxId();

                lineStationsBll.BulkInsert(stationsToInsert);

                // 写入更新记录
                DataUpdateLog.BulkUpdate(typeof(LineStations).Name, maxId);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        /// <summary>
        /// 获取线路列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetLines()
        {
            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                Request,
                (pageIndex, pageSize) =>
                {
                    var stationBll = new BaseLineBll();

                    int totalCount;
                    var data = stationBll.QueryPageList(pageIndex, pageSize, "UpdateTime",
                        true, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, data);
                }
            );

            return Json(json);
        }

        /// <summary>
        /// 获取线路信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetLineInfo(int id)
        {
            var lineBll = new BaseLineBll();
            var lineData = lineBll.QuerySingle(id);
            if (lineData == null)
            {
                return Json(ErrorModel.GetDataFailed);
            }

            var lineStationBll = new LineStationsBll();
            var lineStations = lineStationBll.QueryList("LineId=" + id);

            var data = new
            {
                line = lineData,
                stations = lineStations
            };

            return Json(ErrorModel.GetDataSuccess(data));
        }

        /// <summary>
        /// 删除线路上指定的车站
        /// </summary>
        /// <param name="lineStationId">LineStation表的主键</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteLineStation(int lineStationId)
        {
            if (lineStationId == 0)
            {
                return Json(ErrorModel.OperateSuccess);
            }

            var lineStationBll = new LineStationsBll();
            var success = lineStationBll.Delete(lineStationId);

            if (success)
            {
                DataUpdateLog.SingleUpdate(typeof(LineStations).Name, lineStationId, DataUpdateType.Delete);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        #endregion

        #region 车站管理
        public ActionResult Stations()
        {
            return View();
        }

        public JsonResult GetStations()
        {
            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                Request,
                (pageIndex, pageSize) =>
                {
                    var stationBll = new ViewStationBll();

                    int totalCount;
                    var data = stationBll.QueryPageList(pageIndex, pageSize, "UpdateTime",
                        true, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, data);
                }
            );

            return Json(json);
        }

        /// <summary>
        /// 添加/更新车站信息页面
        /// </summary>
        /// <param name="id">车站Id</param>
        /// <returns></returns>
        public ActionResult StationEdit(int? id)
        {
            ViewBag.Id = id;

            return View();
        }

        /// <summary>
        /// 车站信息更新（异步请求）
        /// </summary>
        /// <param name="station">车站信息对象</param>
        /// <param name="files">车站文件列表</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult StationEdit()
        {
            var stationJson = Request["station"];
            var station = JsonHelper.Deserialize<BaseStation>(stationJson);

            var updateType = station.Id > 0 ? DataUpdateType.Update : DataUpdateType.Insert;

            // 更新车站
            var stationUpdateRes = false;
            var stationBll = new BaseStationBll();
            if (station.Id > 0)
            {
                stationUpdateRes = stationBll.Update(station);
            }
            else
            {
                var condition = string.Format("StationName='{0}' AND IsDelete=0", station.StationName);
                if (stationBll.Exists(condition))
                {
                    return Json(ErrorModel.ExistSameItem);
                }

                var insertedStation = stationBll.Insert(station);
                stationUpdateRes = insertedStation.Id > 0;
            }

            // 更新文件
            if (stationUpdateRes)
            {
                // 写入更新记录
                DataUpdateLog.SingleUpdate(typeof(BaseStation).Name, station.Id, updateType);

                var filesJson = Request["files"];
                var files = JsonHelper.Deserialize<StationFiles[]>(filesJson);
                if (!files.Any())
                {
                    return Json(ErrorModel.OperateSuccess);
                }

                files.ForEach(f => { f.StationId = station.Id; });

                var filesToInsert = files.Where(f => f.Id == 0);
                var filesBll = new StationFilesBll();

                var maxId = (int)filesBll.GetMaxId();

                filesBll.BulkInsert(filesToInsert);

                // 写入更新记录
                DataUpdateLog.BulkUpdate(typeof(StationFiles).Name, maxId);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        /// <summary>
        /// 获取指定车站的基本信息（包括文件）
        /// </summary>
        [HttpPost]
        public JsonResult GetStationInfo(int stationId)
        {
            var stationBll = new BaseStationBll();
            var station = stationBll.QuerySingle(stationId);
            if (station != null)
            {
                var stationFileBll = new StationFilesBll();
                var files = stationFileBll.QueryList(string.Format("StationId={0} AND IsDelete=0", stationId));
                var jsonObj = new
                {
                    station = station,
                    files = files
                };

                var response = ErrorModel.GetDataSuccess(jsonObj);
                return Json(response);
            }

            return Json(ErrorModel.GetDataFailed);
        }

        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteStationFiles(int fileId)
        {
            var stationFilesBll = new StationFilesBll();
            var success = stationFilesBll.DeleteSoftly(fileId);

            if (success)
            {
                DataUpdateLog.SingleUpdate(typeof(StationFiles).Name, fileId, DataUpdateType.Delete);
                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        #endregion

        #region 列车时刻
        public ActionResult TrainMoment(int? trainNoId)
        {
            if (trainNoId == null)
            {
                return RedirectToAction("TrainNo");
            }

            var trainNoBll = new TrainNoBll();
            var trainMomentBll = new ViewTrainMomentBll();

            var trainNo = trainNoBll.QuerySingle(trainNoId);
            if (trainNo == null)
            {
                return RedirectToAction("TrainNo");
            }

            var moments = trainMomentBll.QueryList("TrainNoId=" + trainNoId, null, null, "Sort").ToList();

            var trainMomentHasAdded = true;
            if (!moments.Any())
            {
                trainMomentHasAdded = false;

                var lineStationBll = new LineStationsBll();
                var viewTrainNoLineBll = new ViewTrainNoLIneBll();
                
                var lines = viewTrainNoLineBll.QueryList("Id=" + trainNoId, null, null, "Sort");
                var lineIds = lines.Select(item => item.LineId);

                var condition = string.Format("LineId IN({0})", string.Join(",", lineIds));
                var stations = lineStationBll.QueryList(condition);

                var lineStationDic = new List<KeyValuePair<ViewTrainNoLIne, List<LineStations>>>();
                lines.ForEach(line =>
                {
                    // 将线路与其经过的车站以键值对的方式按顺序归到一起
                    var theStations = stations.Where(item => item.LineId == line.LineId).OrderBy(item => item.Sort);

                    lineStationDic.Add(new KeyValuePair<ViewTrainNoLIne, List<LineStations>>(line, theStations.ToList()));
                });

                // 构造一个ViewTrainMoment集合以便在前台统一展示
                var lineCounter = 0;
                var stationOrder = 0;
                moments = new List<ViewTrainMoment>();
                lineStationDic.ForEach(item =>
                {
                    lineCounter++;

                    var tempLine = item.Key;
                    var tempSations = item.Value;

                    var stationCounter = 0;
                    tempSations.ForEach(t =>
                    {
                        stationCounter++;
                        if (lineCounter > 1 && stationCounter == 1)
                        {
                            // 由于上一条线的终点站与下一站的终点站相同，此处去掉后一条线的起点站
                            return;
                        }

                        stationOrder++;

                        var model = new ViewTrainMoment();
                        model.FullName = trainNo.FullName;
                        model.Sort = stationOrder;
                        model.StationName = t.StationName;
                        model.TrainNoId = trainNo.Id;
                        model.TrainNoLineId = tempLine.TrainNoLineId;
                        model.TrainStationId = t.StationId;
                        model.LineId = t.LineId;
                        model.LineName = tempLine.LineName;

                        moments.Add(model);
                    });
                });
            }

            ViewBag.Id = trainNoId;
            ViewBag.TrainNo = trainNo;
            ViewBag.Moments = moments.ToList();
            ViewBag.IsFirstTime = !trainMomentHasAdded;

            return View();
        }

        public JsonResult Save(string json)
        {
            var list = JsonHelper.Deserialize<List<TrainMoment>>(json);
            if (list == null || !list.Any())
            {
                return Json(ErrorModel.OperateSuccess);
            }

            // 对列车时刻的更新只存在两种情况
            //  1 某车次的列车时刻第一次添加，此时将所有车站的列车时刻表插入数据库
            //  2 对某车次的某些车站的列车时刻进行更新

            var trainMomentBll = new TrainMomentBll();
            var tableName = typeof(TrainMoment).Name;

            var isInsert = list[0].Id == 0;
            if (isInsert)
            {
                var maxId = trainMomentBll.GetMaxId();
                trainMomentBll.BulkInsert(list);

                DataUpdateLog.BulkUpdate(tableName, (int)maxId);

                return Json(ErrorModel.OperateSuccess);
            }

            var success = trainMomentBll.ExecuteTransation(() => {
                foreach (var item in list)
                {
                    if (!trainMomentBll.Update(item))
                    {
                        return false;
                    }

                    DataUpdateLog.SingleUpdate(tableName, item.Id, DataUpdateType.Update);
                }

                return true;
            });

            if (success)
            {
                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }
        #endregion
    }
}
