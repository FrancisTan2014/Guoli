using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Guoli.Utilities.Extensions;

namespace Guoli.Admin.Filters
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class LogFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("{0}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            foreach (var key in request.QueryString.AllKeys)
            {
                stringBuilder.AppendFormat("{0}：{1}\r\n", key, request.QueryString[key]);
            }
            foreach (var key in request.Form.AllKeys)
            {
                stringBuilder.AppendFormat("{0}：{1}\r\n", key, request.Form[key]);
            }
            stringBuilder.AppendLine("===============================================\r\n");

            //var path = filterContext.HttpContext.Server.MapPath("/Log/App");
            // @FrancisTan 20170208
            var path = PathExtension.MapPath("/Log/App");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, "params.log");

            using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(stringBuilder);
                }
            }
            
            
        }
    }
}