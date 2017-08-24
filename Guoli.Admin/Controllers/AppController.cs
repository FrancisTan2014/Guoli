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
using NPOI.SS.Formula.Functions;
using WebGrease.Css.Extensions;
using System.Linq;
using System.Text.RegularExpressions;

namespace Guoli.Admin.Controllers
{
    [LogFilter]
    [AppSignatureFilter]
    public class AppController : Controller
    {
        public JsonResult Upgrade(string version)
        {
            var latest = new AppUpdateBll().QueryAll().LastOrDefault();
            if (latest == null)
            {
                return Json(ErrorModel.AppNotUpgraded);
            }

            if (string.IsNullOrEmpty(version))
            {
                // 版本号为空且数据库不为空，则返回最新版本信息
                return Json(ErrorModel.AppUpgraded(latest));
            }

            // 验证版本号格式
            if (!Regex.IsMatch(version, @"^\d+\.\d+\.\d+\.\d+$"))
            {
                return Json(ErrorModel.InputError);
            }

            try
            {                
                if (version != latest.Version)
                {
                    // 版本号与最新发布的版本号不一致
                    // 说明发布了最新版本
                    return Json(ErrorModel.AppUpgraded(latest));
                }

                return Json(ErrorModel.AppNotUpgraded);
            }
            catch (Exception ex)
            {
                ExceptionLogBll.ExceptionPersistence(nameof(AppController), nameof(AppController), ex);
                return Json(ErrorModel.InputError);
            }
        }

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

        /// <summary>
        /// 手账记录上传
        /// </summary>
        [HttpPost]
        public JsonResult DrivePlanUpload(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return Json(ErrorModel.InputError);
            }

            // 无论上传是一条记录还是多条记录
            // 在此处都当做数组进行统一处理
            json = json.Trim();
            if (!json.StartsWith("[") && !json.EndsWith("]"))
            {
                json = $"[{json}]";
            }
            
            var data = JsonHelper.Deserialize<DrivePlanUploadModel[]>(json);

            var bll = new DriveRecordsBll();
            var delegates = new Func<bool>[data.Length];

            for (var i = 0; i < data.Length; i++)
            {
                MakeSureDatetimeHasLegalValue(data[i]);
                delegates[i] = MakeInsertDelegate(data[i]);
            }

            if (bll.ExecuteTransation(delegates))
            {
                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        private Func<bool> MakeInsertDelegate(DrivePlanUploadModel model)
        {
            var driveRecordBll = new DriveRecordsBll();
            
            return () =>
            {
                var inserted = driveRecordBll.Insert(model.DriveRecords);
                if (inserted.Id > 0)
                {
                    model.DriveSignPoints.ForEach(item => item.DriveRecordId = inserted.Id);
                    model.DriveTrainNoAndLines.ForEach(item => item.DriveRecordId = inserted.Id);
                    model.TrainFormations.ForEach(item => item.DriveRecordId = inserted.Id);

                    var signBll = new DriveSignPointBll();
                    var trainBll = new DriveTrainNoAndLineBll();
                    var formationsBll = new TrainFormationBll();

                    signBll.BulkInsert(model.DriveSignPoints);
                    trainBll.BulkInsert(model.DriveTrainNoAndLines);
                    formationsBll.BulkInsert(model.TrainFormations);

                    return true;
                }

                return false;
            };
        }

        private void MakeSureDatetimeHasLegalValue(DrivePlanUploadModel model)
        {
            MakeSureDatetimeHasLegalValue(model.DriveRecords);
            
            model.DriveSignPoints.ForEach(MakeSureDatetimeHasLegalValue);
            model.DriveTrainNoAndLines.ForEach(MakeSureDatetimeHasLegalValue);
            model.TrainFormations.ForEach(MakeSureDatetimeHasLegalValue);
        }

        private void MakeSureDatetimeHasLegalValue(object instance)
        {
            var defaultDateTime = new DateTime(1970, 1, 1);
            var typeofDatatime = typeof (DateTime);

            var type = instance.GetType();

            type.GetProperties().ForEach(property =>
            {
                if (property.PropertyType == typeofDatatime)
                {
                    var propValue = (DateTime) property.GetValue(instance, BindingFlags.GetProperty, null, null, null);
                    if (propValue == DateTime.MinValue)
                    {
                        property.SetValue(instance, defaultDateTime, BindingFlags.SetProperty, null, null, null);
                    }
                }
            });
        }
    }
}
