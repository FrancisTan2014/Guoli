using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Utilities.Helpers;

namespace Guoli.Admin.Filters
{
    /// <summary>
    /// 此过滤器对app请求数据接口
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AppSignatureFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 在执行Action之前对请求作数字签名验证
        /// </summary>
        /// <param name="filterContext">当前过滤器上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var token = filterContext.HttpContext.Request["signature"];
#if DEBUG
            if (token == "FrancisTan")
            {
                return;
            }
#endif

            if (token != AppSettings.AppRequestToken)
            {
                var res = JsonHelper.Serialize(ErrorModel.SignatureError);
                filterContext.HttpContext.Response.Write(res);
                filterContext.HttpContext.Response.End();
            }
        }
    }
}