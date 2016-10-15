using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using WebGrease.Css.Extensions;

namespace Guoli.Admin.Controllers
{
    public class InstructorController : Controller
    {
        //
        // GET: /Instructor/

        public ActionResult Index()
        {
            return View();
        }

        #region AJAX公共方法
        /// <summary>
        /// 获取数据列表的公共方法（通过表名反映获取）
        /// </summary>
        /// <returns></returns>
        public JsonResult GetList()
        {
            var instructorId = Request["instructorId"].ToInt32();
            var month = Request["month"].ToDateTime();
            var tableName = Request["target"];

            if (string.IsNullOrEmpty(tableName))
            {
                return Json(ErrorModel.InputError);
            }

            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                Request,
                (pageIndex, pageSize) =>
                {
                    var bllInstance = BllFactory.GetBllInstance(tableName);
                    if (bllInstance != null)
                    {
                        var type = bllInstance.GetType();

                        try
                        {
                            // build condition
                            var conditionList = new List<string>();
                            if (instructorId > 0)
                            {
                                conditionList.Add("InstructorId=" + instructorId);
                            }

                            if (month != default(DateTime))
                            {
                                var start = month.AddDays(-1);
                                var end = month.AddMonths(1);
                                conditionList.Add($"UploadTime>'{start}' AND UploadTime<'{end}'");
                            }

                            var condition = string.Join(" AND ", conditionList);
                            var orderField = Request["order"] ?? "UploadTime";
                            var arguments = new object[] { pageIndex, pageSize, condition, orderField, true, 0 };
                            var list = type.InvokeMember("QueryPageList", BindingFlags.InvokeMethod, null, bllInstance,
                                arguments);

                            return new KeyValuePair<int, object>((int)arguments[5], list);
                        }
                        catch (Exception ex)
                        {
                            ExceptionLogBll.ExceptionPersistence("InstructorController.cs", "InstructorController", ex);

                            return new KeyValuePair<int, object>();
                        }
                    }

                    return new KeyValuePair<int, object>();
                });

            return Json(json);
        }

        [HttpPost]
        public JsonResult GetSingle(int id, string target)
        {
            if (string.IsNullOrEmpty(target) || id == 0)
            {
                return Json(ErrorModel.InputError);
            }

            var bllInstance = BllFactory.GetBllInstance(target);
            if (bllInstance == null)
            {
                return Json(ErrorModel.InputError);
            }

            var type = bllInstance.GetType();
            var data = type.InvokeMember("QuerySingle", BindingFlags.InvokeMethod, null, bllInstance,
                new object[] { id, null });

            if (data == null)
            {
                return Json(ErrorModel.GetDataFailed);
            }

            return Json(ErrorModel.GetDataSuccess(data));
        }

        /// <summary>
        /// 获取指导司机列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetInstructorList()
        {
            var personBll = new ViewPersonInfoBll();
            var instructorList = personBll.QueryList("PostId=" + AppSettings.InstructorPostId);

            return Json(ErrorModel.GetDataSuccess(instructorList));
        }
        #endregion

        #region 抽查信息单
        public ActionResult Check()
        {
            return View();
        }

        public ActionResult CheckDetail(int? id)
        {
            ViewBag.Id = id;

            return View();
        }
        #endregion

        #region 机破临修记录

        public ActionResult Repair()
        {
            return View();
        }

        public ActionResult RepairDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        #endregion

        #region 监控分析单

        public ActionResult Analysis()
        {
            return View();
        }

        public ActionResult AnalysisDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        #endregion

        #region 机车质量登记
        public ActionResult Quality()
        {
            return View();
        }

        public ActionResult QualityDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        #endregion

        #region 防止事故及好人好事记录

        public ActionResult Good()
        {
            return View();
        }

        public ActionResult GoodDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        #endregion

        #region 违章违纪记录

        public ActionResult Peccancy()
        {
            return View();
        }

        public ActionResult PeccancyDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        #endregion

        #region 添乘信息单

        public ActionResult Take()
        {
            return View();
        }

        public ActionResult TakeDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        #endregion

        #region 授课培训记录

        public ActionResult Teach()
        {
            return View();
        }

        public ActionResult TeachDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        #endregion

        #region 关键人管理

        public ActionResult KeyPerson()
        {
            return View();
        }

        public ActionResult KeyPersonDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        #endregion

        #region 工作总结及计划

        public ActionResult Plan()
        {
            return View();
        }

        public ActionResult PlanDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        #endregion

        #region 标准化验收

        public ActionResult Accept()
        {
            return View();
        }

        public ActionResult AcceptDetail(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        #endregion

        #region 指标/评分管理

        public ActionResult Quota()
        {
            return View();
        }

        public ActionResult QuotaEdit(int? id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public JsonResult GetQuotaList()
        {
            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                Request,
                (pageIndex, pageSize) =>
                {
                    var quotaBll = new InstructorQuotaBll();

                    int totalCount;
                    var list = quotaBll.QueryPageList(pageIndex, pageSize, "IsDelete=0", null, false, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, list);
                });

            return Json(json);
        }

        [HttpPost]
        public JsonResult SaveQuota()
        {
            var quotaJson = Request["quota"];
            if (string.IsNullOrEmpty(quotaJson))
            {
                return Json(ErrorModel.InputError);
            }

            var quota = JsonHelper.Deserialize<InstructorQuota>(quotaJson);
            if (quota == null)
            {
                return Json(ErrorModel.InputError);
            }

            var standardJson = Request["standard"];
            if (quota.NeedReview && string.IsNullOrEmpty(standardJson))
            {
                return Json(ErrorModel.InputError);
            }

            var standardList = JsonHelper.Deserialize<List<InstructorReviewStandard>>(standardJson);
            if (quota.NeedReview && (standardList == null || standardList.Count == 0))
            {
                return Json(ErrorModel.InputError);
            }

            var updateType = quota.Id == 0 ? DataUpdateType.Insert : DataUpdateType.Update;

            bool success;
            var quotaBll = new InstructorQuotaBll();
            if (quota.Id > 0)
            {
                success = quotaBll.Update(quota);
            }
            else
            {
                quotaBll.Insert(quota);
                success = quota.Id > 0;
            }

            if (success)
            {
                DataUpdateLog.SingleUpdate(typeof(InstructorQuota).Name, quota.Id, updateType);

                if (standardList != null && standardList.Count > 0)
                {
                    var standardToInsert = standardList.Where(s => s.Id == 0).ToList();
                    if (standardToInsert.Any())
                    {
                        standardToInsert.ForEach(s => s.InstructorQuotaId = quota.Id);

                        var standardBll = new InstructorReviewStandardBll();
                        standardBll.BulkInsert(standardToInsert);
                    }
                }

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult GetStandardList(int quotaId)
        {
            var standardBll = new InstructorReviewStandardBll();
            var standardList = standardBll.QueryList($"InstructorQuotaId={quotaId} AND IsDelete=0");

            return Json(ErrorModel.GetDataSuccess(standardList));
        }

        [HttpPost]
        public JsonResult DeleteStandard(int id)
        {
            var standardBll = new InstructorReviewStandardBll();
            if (standardBll.DeleteSoftly(id))
            {
                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        public ActionResult Score()
        {
            ComputeScore();
            return View();
        }

        [HttpPost]
        public JsonResult GetScoreList()
        {
            var monthParam = Request["month"];
            if (string.IsNullOrEmpty(monthParam) || !Regex.IsMatch(monthParam, "\\d{4}-\\d{2}"))
            {
                return Json(ErrorModel.InputError);
            }

            var splits = monthParam.Split('-');
            var year = splits[0].ToInt32();
            var month = splits[1].ToInt32();

            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                Request,
                (pageIndex, pageSize) =>
                {
                    var scoreBll = new ViewInstructorReviewScoreBll();
                    var condition = $"Year={year} AND Month={month}";

                    int totalCount;
                    var list = scoreBll.QueryPageList(pageIndex, pageSize, condition, null, false, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, list);
                });

            return Json(json);
        }

        /// <summary>
        /// 用于统计指导司机单项指标得分
        /// </summary>
        private struct ScoreCounter
        {
            /// <summary>
            /// 指导司机Id
            /// </summary>
            public int InstructorId { get; set; }
            /// <summary>
            /// 指标Id
            /// </summary>
            public int QuotaId { get; set; }
            /// <summary>
            /// 本项指标得分
            /// </summary>
            public decimal Score { get; set; }
        }

        private void ComputeScore()
        {
            var quotaBll = new InstructorQuotaBll();
            var quotaList = quotaBll.QueryList("IsDelete=0").ToList();

            var standardBll = new InstructorReviewStandardBll();
            var standardList = standardBll.QueryList("IsDelete=0").ToList();

            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            var instructorQuotaRecordBll = new InstructorQuotaRecordBll();
            var condition = $"Year={currentYear} AND Month={currentMonth} AND IsDelete=0";
            var recordList = instructorQuotaRecordBll.QueryList(condition).ToList();

            // 将指标完成记录以指标Id分组
            var groupList = recordList.GroupBy(item => item.QuotaId);

            // 分别计算每项指标得分
            var counterList = new List<ScoreCounter>();
            foreach (var item in groupList)
            {
                var quotaId = item.Key;
                var quota = quotaList.Single(q => q.Id == quotaId);
                var standards = standardList.Where(s => s.InstructorQuotaId == quotaId).ToList();

                if (quota.NeedReview)
                {
                    counterList.AddRange(
                        from record in item
                        let score = ScoreCalculater(quota.QuataAmmount, quota.BaseScore, record.FinishedAmmount, standards)
                        select new ScoreCounter
                        {
                            InstructorId = record.InstructorId,
                            QuotaId = quotaId,
                            Score = score
                        });
                }
            }

            // 统计指导司机本月总得分
            var instructorScoreList =
                counterList.GroupBy(item => item.InstructorId)
                .Select(group => new InstructorReviewScore
                {
                    InstructorId = group.Key,
                    Year = currentYear,
                    Month = currentMonth,
                    Score = group.Sum(s => s.Score)
                });

            // 删除本月当前得分记录，插入新的得分记录
            var scoreBll = new InstructorReviewScoreBll();
            var deleteCondition = $"Year={currentYear} AND Month={currentMonth}";

            scoreBll.ExecuteTransation(
                () => !scoreBll.Exists(deleteCondition) || scoreBll.Delete(deleteCondition),
                () =>
                {
                    scoreBll.BulkInsert(instructorScoreList);
                    return true;
                });
        }

        private decimal ScoreCalculater(decimal quotaAmmount, decimal baseScore, decimal finishAmmount, List<InstructorReviewStandard> standardList)
        {
            // 当前指标项无标准时，得基础分值
            if (standardList == null || standardList.Count == 0)
            {
                return baseScore;
            }

            var orderedList = standardList.OrderByDescending(s => s.ConditionAmmount);
            foreach (var standard in orderedList)
            {
                // 当标准中所要求的量比指标规定的量多时，则大于标准值才给予加分
                if (standard.ConditionAmmount >= quotaAmmount)
                {
                    if (finishAmmount >= standard.ConditionAmmount)
                    {
                        return baseScore + standard.ExtraScore;
                    }
                }
                // 当标准中所要求的量比指标规定的量少时，则小于标准值就给予扣分
                else
                {
                    if (finishAmmount < standard.ConditionAmmount)
                    {
                        return baseScore + standard.ExtraScore;
                    }
                }
            }

            // 不满足任务标准，返回基础分值
            return baseScore;
        }
        #endregion

        #region 指导司机定位

        public ActionResult Router()
        {
            return View();
        }

        public ActionResult RouterDetail(int? id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public JsonResult SaveRouter()
        {
            var json = Request["json"];
            if (string.IsNullOrEmpty(json))
            {
                return Json(ErrorModel.InputError);
            }

            var model = JsonHelper.Deserialize<InstructorRouterPosition>(json);
            if (model == null)
            {
                return Json(ErrorModel.InputError);
            }

            model.AddTime = DateTime.Now;

            var updateType = model.Id > 0 ? DataUpdateType.Update : DataUpdateType.Insert;

            bool success;
            var bll = new InstructorRouterPositionBll();
            if (model.Id > 0)
            {
                success = bll.Update(model);
            }
            else
            {
                model = bll.Insert(model);
                success = model.Id > 0;
            }

            if (success)
            {
                DataUpdateLog.SingleUpdate(nameof(InstructorRouterPosition), model.Id, updateType);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        public ActionResult Wifi()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetWifiRecods()
        {
            var instructorId = Request["pid"].ToInt32();
            var connectTime = Request["time"];
            var pageIndex = Request["pageIndex"].ToInt32();
            var pageSize = Request["pageSize"].ToInt32();

            var bll = new ViewInstructorWifiRecordBll();

            var condition = $"InstructorId={instructorId} AND ConnectTime<'{connectTime}'";
            var data = bll.QueryPageList(pageIndex, pageSize, condition, null, null, "ConnectTime", true);

            if (!data.Any())
            {
                return Json(ErrorModel.GetDataFailed);
            }

            return Json(ErrorModel.GetDataSuccess(data));
        }
        #endregion
    }
}
