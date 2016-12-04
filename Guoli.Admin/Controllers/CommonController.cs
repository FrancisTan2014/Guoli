using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using JNL.Web.Models;

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

        /// <summary>
        /// 公共接口，获取数据集合
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetList(GetListParams parameters)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bllInstance = BllFactory.GetBllInstance(parameters.TableName);
                    if (bllInstance == null)
                    {
                        return Json(ErrorModel.InputError);
                    }

                    var condition = string.IsNullOrEmpty(parameters.Conditions)
                        ? string.Empty
                        : parameters.Conditions.Replace("###", " AND ");

                    var fields = string.IsNullOrEmpty(parameters.Fields)
                        ? null
                        : parameters.Fields.Split(new[] { "###" }, StringSplitOptions.RemoveEmptyEntries);

                    object data;
                    var type = bllInstance.GetType();
                    if (parameters.PageIndex <= 0 || parameters.PageSize <= 0)
                    {
                        data = type.InvokeMember("QueryList", BindingFlags.InvokeMethod, null, bllInstance,
                            new object[] { condition, fields, null, parameters.OrderField, parameters.Desending });
                    }
                    else
                    {
                        data = type.InvokeMember("QueryPageList", BindingFlags.InvokeMethod, null, bllInstance,
                            new object[] { parameters.PageIndex, parameters.PageSize, condition, fields, null, parameters.OrderField, parameters.Desending });
                    }

                    return Json(ErrorModel.GetDataSuccess(data));
                }
                catch (Exception ex)
                {
                    ExceptionLogBll.ExceptionPersistence(nameof(CommonController), nameof(CommonController), ex);

                    return Json(ErrorModel.InputError);
                }
            }

            return Json(ErrorModel.InputError);
        }
    }
}
