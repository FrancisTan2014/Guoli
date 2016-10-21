using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using Guoli.Admin.Filters;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Enums;
using Guoli.Utilities.Helpers;

namespace Guoli.Admin.Controllers
{
    [LogFilter]
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

                return new CustomJsonResult {
                    Data = jsonObj,
                    MaxJsonLength = int.MaxValue,
                    FormateStr = "yyyy-MM-dd HH:mm:ss"
                };
            }
            catch (Exception ex)
            {
                ExceptionLogBll.ExceptionPersistence("AppController.cs", "AppController", ex);

                return Json(ErrorModel.InputError, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpPost]
        //public JsonResult UpdateSearchRecord()
        //{
        //    var data = Request["data"];
        //    var searchRecord = JsonHelper.Deserialize<TraficSearchRecord>(data);
        //    if (searchRecord == null)
        //    {
        //        return Json(ErrorModel.InputError);
        //    }

        //    var searchBll = new TraficSearchRecordBll();
        //    var existCondition = $"PersonId={searchRecord.PersonId} AND ";
        //}

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

        [HttpPost]
        public JsonResult QuotaRecordUpload(List<InstructorQuotaRecord> list)
        {
            var bll = new InstructorQuotaRecordBll();
            var delegates = new List<Func<bool>>();

            list.ForEach(item =>
            {
                delegates.Add(() =>
                {
                    var condition =
                        $"InstructorId={item.InstructorId} AND QuotaId={item.QuotaId} AND Year={item.Year} AND Month={item.Month}";
                    if (bll.Exists(condition))
                    {
                        return bll.Delete(condition);
                    }

                    return true;
                });
            });

            delegates.Add(() =>
            {
                bll.BulkInsert(list);
                return true;
            });

            if (bll.ExecuteTransation(delegates.ToArray()))
            {
                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }
    }
}
