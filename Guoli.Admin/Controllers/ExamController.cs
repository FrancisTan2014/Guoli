using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Helpers;
using System.Web.Mvc;
using System.Collections.Generic;
using Guoli.Utilities.Extensions;
using System.Linq;

namespace Guoli.Admin.Controllers
{
    public class ExamController : Controller
    {
        #region 考试通知
        public ActionResult Notify()
        {
            return View();
        }

        public ActionResult NotifyEdit()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetExamFileList()
        {
            var examFilesBll = new ExamFilesBll();
            var list = examFilesBll.QueryList("IsDelete=0");

            return Json(ErrorModel.GetDataSuccess(list));
        }

        [HttpPost]
        public JsonResult SaveNotify(string json)
        {
            var model = JsonHelper.Deserialize<ExamNotify>(json);
            if (model == null)
            {
                return Json(ErrorModel.InputError);
            }

            var notifyBll = new ExamNotifyBll();
            notifyBll.Insert(model);

            if (model.Id > 0)
            {
                DataUpdateLog.SingleUpdate(typeof(ExamNotify).Name, model.Id, DataUpdateType.Insert);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult GetNotifies()
        {
            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                Request,
                (pageIndex, pageSize) => {
                    var notifyBll = new ViewExamNotifyBll();

                    int totalCount;
                    var list = notifyBll.QueryPageList(pageIndex, pageSize, "AddTime", true, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, list);
                });

            return Json(json);
        }

        #endregion

        #region 考试结果
        public ActionResult Result()
        {
            return View();
        }

        public ActionResult ResultDetail(int? notifyId, int? personId)
        {
            if (notifyId == null || personId == null)
            {
                return RedirectToAction("Result");
            }

            ViewBag.NotifyId = notifyId;
            ViewBag.PersonId = personId;

            var notifyBll = new ViewExamNotifyBll();
            var notify = notifyBll.QuerySingle(notifyId);

            var resultBll = new ExamRecordsBll();
            var condition = string.Format("IsDelete=0 AND PersionId={0} AND ExamNotifyId={1}", personId, notifyId);
            var results = resultBll.QueryList(condition);

            if (notify == null || !results.Any())
            {
                return RedirectToAction("Result");
            }

            ViewBag.Notify = notify;
            ViewBag.Results = results.ToList();

            return View();
        }

        [HttpPost]
        public JsonResult GetResults()
        {
            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                    Request,
                    (pageIndex, pageSize) => {
                        var conditionList = new List<string>();

                        var notifyId = Request["notifyId"].ToInt32();
                        if (notifyId > 0)
                        {
                            conditionList.Add("ExamNotifyId=" + notifyId);
                        }

                        var departId = Request["departId"].ToInt32();
                        if (departId > 0)
                        {
                            conditionList.Add("DepartmentId=" + departId);
                        }

                        var passed = Request["passed"] ?? string.Empty;
                        if (!string.IsNullOrEmpty(passed))
                        {
                            conditionList.Add(string.Format("Passed='{0}'", passed));
                        }

                        int totalCount;
                        var condition = string.Join(" AND ", conditionList);

                        var resultBll = new ViewExamRecordsBll();
                        var list = resultBll.QueryPageList(pageIndex, pageSize, condition, "NotifyAddTime", true, out totalCount);

                        return new KeyValuePair<int, object>(totalCount, list);
                    }
                );

            return Json(json);
        }
        #endregion

        #region 试题管理
        public ActionResult Files()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetFiles()
        {
            var json = JqueryDataTableAjaxHelper.GetPageListJson(Request,
                (pageIndex, pageSize) =>
                {
                    var fileBll = new ViewExamFilesBll();

                    int totalCount;
                    var list = fileBll.QueryPageList(pageIndex, pageSize, "AddTime", true, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, list);
                });

            return Json(json);
        }

        [HttpPost]
        public JsonResult Upload(string data)
        {
            var examFile = JsonHelper.Deserialize<ExamFiles>(data);
            if (examFile == null)
            {
                return Json(ErrorModel.InputError);
            }

            var result = NpoiHelper.AnalysisExamQuestion(examFile);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetTypeList()
        {
            var typeBll = new ExamTypeBll();
            var typeList = typeBll.QueryAll();

            return Json(ErrorModel.GetDataSuccess(typeList));
        }

        [HttpPost]
        public JsonResult AddExamType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Json(ErrorModel.InputError);
            }

            var typeBll = new ExamTypeBll();

            var condition = string.Format("IsDelete=0 AND name='{0}'", name.Trim());
            if (typeBll.Exists(condition))
            {
                return Json(ErrorModel.ExistSameItem);
            }

            var typeModel = new ExamType { TypeName = name };
            typeBll.Insert(typeModel);

            if (typeModel.Id > 0)
            {
                DataUpdateLog.SingleUpdate(typeof(ExamType).Name, typeModel.Id, DataUpdateType.Insert);

                return Json(ErrorModel.GetDataSuccess(typeModel.Id));
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult FileUpload()
        {
            var pathInfo = UploadHelper.FileUpload();
            return Json(pathInfo);
        } 
        #endregion
    }
}
