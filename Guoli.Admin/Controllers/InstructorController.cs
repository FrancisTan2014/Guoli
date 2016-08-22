using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;

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
                                conditionList.Add(string.Format("UploadTime>'{0}' AND UploadTime<'{1}'", start, end));
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
                new object[] { id });

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
    }
}
