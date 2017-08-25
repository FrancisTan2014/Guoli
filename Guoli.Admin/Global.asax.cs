using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Guoli.Admin
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 运行需要在程序启动时运行的临时任务
            //TempTask.RunTempTasks();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //var ctx = HttpContext.Current;
            //if (ctx.Request.HttpMethod == "OPTIONS")
            //{
            //    ctx.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //    ctx.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            //    ctx.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            //}

            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }

            // @FrancisTan 2017-08-25
            // 屏蔽所有老后台的GET请求
            if (Request.HttpMethod == "GET" 
                && (!Request.Form.AllKeys.Contains("token") && !Request.Form.AllKeys.Contains("token")) // 新后台请求必带参数
                && (!Request.QueryString.AllKeys.Contains("token") && !Request.QueryString.AllKeys.Contains("token"))
                && (!Request.Form.AllKeys.Contains("signature") && !Request.Form.AllKeys.Contains("signature")) // app请求必带参数
                && (!Request.QueryString.AllKeys.Contains("signature") && !Request.QueryString.AllKeys.Contains("signature"))
            )
            {
                Response.StatusCode = 404;
                Response.Flush();
            }
        }
    }
}