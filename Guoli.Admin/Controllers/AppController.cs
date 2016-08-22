using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using Guoli.Admin.Filters;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Utilities.Enums;

namespace Guoli.Admin.Controllers
{
    [AppSignatureFilter]
    public class AppController : Controller
    {
        //
        // GET: /App/

        /// <summary>
        /// APP通用数据访问接口（CRUD）
        /// </summary>
        /// <param name="parameters">请求接口所带的参数模型对象</param>
        /// <returns>请求结果</returns>
        public JsonResult Index(CommonApiModel parameters)
        {
            var bllEntity = BllFactory.GetBllInstance(parameters.TableName);
            var entityType = bllEntity.GetType();
            var methodName = parameters.Operate.ToString();

            var invokeParameters = PrepareInvokeParameters(parameters);
            try
            {
                if (parameters.Operate == DbOperateType.BulkInsert)
                {
                    entityType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, bllEntity, invokeParameters);

                    return Json(ErrorModel.BulkInsertSuccess);
                }

                var result = entityType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, bllEntity, invokeParameters);
                var jsonObj = ErrorModel.GetDataSuccess(result, parameters.TableName);

                return Json(jsonObj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionLogBll.ExceptionPersistence("AppController.cs", "AppController", ex);

                return Json(ErrorModel.InputError, JsonRequestBehavior.AllowGet);
            }
        }

        private object[] PrepareInvokeParameters(CommonApiModel parameters)
        {
            if (parameters.StartId > 0)
            {
                if (string.IsNullOrEmpty(parameters.Condition))
                {
                    parameters.Condition = "Id>" + parameters.StartId;
                }
                else
                {
                    parameters.Condition += "AND Id>" + parameters.StartId;
                }
            }

            object[] invokeParams = null;
            switch (parameters.Operate)
            {
                case DbOperateType.Insert:
                case DbOperateType.Update:
                    invokeParams = new object[] { parameters.Data, parameters.Fields };
                    break;
                case DbOperateType.BulkInsert:
                    invokeParams = new object[] { parameters.Data };
                    break;
                case DbOperateType.Delete:
                    invokeParams = new [] { (object)parameters.Data };
                    break;
                case DbOperateType.QuerySingle:
                    invokeParams = new object[] { parameters.Condition, parameters.Fields, (IDictionary<string, object>)null };
                    break;
                case DbOperateType.QueryList:
                    invokeParams = new object[] { parameters.Condition, parameters.Fields, (IDictionary<string, object>)null, parameters.OrderField, parameters.IsDescending };
                    break;
                case DbOperateType.QueryPageList:
                    invokeParams = new object[] { parameters.PageIndex, parameters.PageSize, parameters.Condition, parameters.Fields, (IDictionary<string, object>)null, parameters.OrderField, parameters.IsDescending };
                    break;
            }

            return invokeParams;
        }
    }
}
