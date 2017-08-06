using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guoli.Admin
{
    public class EnableCorsAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            filterContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type");
            filterContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        }
    }
}