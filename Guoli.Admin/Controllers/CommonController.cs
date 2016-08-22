using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Admin.Models;

namespace Guoli.Admin.Controllers
{
    /// <summary>
    /// 提供公共的ajax请求接口
    /// </summary>
    public class CommonController : Controller
    {
        /// <summary>
        /// 获取部门列表
        /// </summary>
        [HttpPost]
        public JsonResult GetDeparts()
        {
            var departBll = new DepartInfoBll();
            var list = departBll.QueryList("IsDelete=0");

            return Json(ErrorModel.GetDataSuccess(list));
        }

        /// <summary>
        /// 获取考试通知列表
        /// </summary>
        [HttpPost]
        public JsonResult GetExamNotifies()
        {
            var notifyBll = new ExamNotifyBll();
            var list = notifyBll.QueryList("IsDelete=0", null, null, "AddTime", true);

            return Json(ErrorModel.GetDataSuccess(list));
        }

        /// <summary>
        /// 获取职位信息
        /// </summary>
        [HttpPost]
        public JsonResult GetPositions()
        {
            var postBll = new PostsBll();
            var posts = postBll.QueryList("IsDelete=0");

            return Json(ErrorModel.GetDataSuccess(posts));
        }
    }
}
