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

namespace Guoli.Admin.Controllers
{
    public class AnnounceController : Controller
    {
        //
        // GET: /Announce/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList()
        {
            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                Request,
                (pageIndex, pageSize) =>
                {
                    int totalCount;
                    var bll = new AnnouncementBll();
                    var list = bll.QueryPageList(pageIndex, pageSize, "PubTime", true, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, list);
                }
            );
            
            return Json(json);
        }

        public ActionResult Detail(int? id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public JsonResult GetGingle(int id)
        {
            var bll = new AnnouncementBll();
            var model = bll.QuerySingle(id);

            if (model == null)
            {
                return Json(ErrorModel.GetDataFailed);
            }

            return Json(ErrorModel.GetDataSuccess(model));
        }

        [HttpPost]
        public JsonResult Save(string json)
        {
            var model = JsonHelper.Deserialize<Announcement>(json);
            if (model == null)
            {
                return Json(ErrorModel.InputError);
            }

            model.PubTime = DateTime.Now;
            model.SystemUserId = LoginStatus.GetLoginId();

            var updateType = model.Id > 0 ? DataUpdateType.Update : DataUpdateType.Insert;

            bool success;
            var bll = new AnnouncementBll();
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
                var logBll = new OperateLogBll();
                var dic = new Dictionary<int, string> { { 1, "普通公告" }, { 2, "事故预警" }, { 3, "附件4" } };
                var log = $"发布了[{dic[model.BusinessType]}]类型的公告";
                logBll.Add(nameof(Announcement), model.Id, updateType, LoginStatus.GetLoginId(), log);
                DataUpdateLog.SingleUpdate(nameof(Announcement), model.Id, updateType);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var bll = new AnnouncementBll();
            var success = bll.ExecuteTransation(
                () => bll.Delete(id),
                () => DataUpdateLog.SingleUpdate(nameof(Announcement), id, DataUpdateType.Delete)
            );

            if (success)
            {
                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }
    }
}
