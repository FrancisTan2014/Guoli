using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guoli.Bll;
using Guoli.Utilities.Helpers;

namespace Guoli.Admin.Controllers
{
    public class PlannerController : Controller
    {
        public ActionResult Reports()
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
                    var recordBll = new ViewDriveRecordBll();

                    int totalCount;
                    var data = recordBll.QueryPageList(pageIndex, pageSize, "AttendTime",
                        true, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, data);
                }
            );

            return Json(json);
        }

        public ActionResult Single(int id)
        {
            var driveRecordBll = new ViewDriveRecordBll();
            var driveRocord = driveRecordBll.QuerySingle(id);
            if (driveRocord == null)
            {
                return RedirectToAction("Reports");
            }
            
            var signPointBll = new ViewSignPointBll();
            var signPoints = signPointBll.QueryList($"DriveRecordId={id}", null, null, "Sort").ToList();

            ViewBag.Record = driveRocord;
            ViewBag.Signs = signPoints;

            return View();
        }
    }
}
