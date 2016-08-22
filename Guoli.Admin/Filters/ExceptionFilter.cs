using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Utilities.Helpers;

namespace Guoli.Admin.Filters
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-28</since>
    public class ExceptionFilter : HandleErrorAttribute
    {
        /// <summary>
        /// 将未经处理的异常信息持久化
        /// </summary>
        /// <param name="filterContext">上下文对象</param>
        public override void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            ExceptionLogBll.ExceptionPersistence("", "", exception);

            base.OnException(filterContext);

            if (RequestHelper.IsAsyncRequest())
            {
                HttpContext.Current.Response.Write(JsonHelper.Serialize(ErrorModel.InputError));
                HttpContext.Current.Response.End();
            }
        }
    }
}