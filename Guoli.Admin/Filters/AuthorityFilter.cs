using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Models;

namespace Guoli.Admin.Filters
{
    /// <summary>
    /// 身份验证过滤器，对指定控制器或者方法执行身份验证逻辑
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-15</since>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorityFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 在执行Action之前对请求作登录验证
        /// </summary>
        /// <param name="filterContext">当前过滤器上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var routeData = filterContext.RouteData;
            var controller = routeData.Values["controller"].ToString();
            var action = routeData.Values["action"].ToString();

            // 后台登录验证
            if (Authority.WhetherNeedLogin(controller, action))
            {
                if (!LoginStatus.IsLogin())
                {
                    var actionResult = LoginStatus.RedirectToLogin();
                    filterContext.Result = actionResult;
                }
            }
        }
    }
}