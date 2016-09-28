using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.FileUpload;
using Guoli.Utilities.Helpers;

namespace Guoli.Admin.Controllers
{
    public class FilesController : Controller
    {
        //
        // GET: /Files/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Keywords()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddFiles()
        {
            var typeId = Request["typeId"].ToInt32();
            if (typeId == 0)
            {
                return Json(new { msg = ErrorModel.InputError });
            }

            var uploadRes = UploadHelper.FileUpload();
            var filePathInfo = uploadRes as FilePathInfo;
            if (filePathInfo == null)
            {
                return Json(new { msg = uploadRes });
            }

            var fileBll = new TraficFilesBll();

            // 验证文件是否重名
            var condition = $"IsDelete=0 AND TypeId={typeId} AND FileName='{filePathInfo.OriginalFileName}'";
            if (fileBll.Exists(condition))
            {
                return Json(ErrorModel.FileExists);
            }

            var fileModel = new TraficFiles
            {
                FileExtension = filePathInfo.FileExtension,
                FileName = filePathInfo.OriginalFileName,
                FilePath = filePathInfo.FileRelativePath,
                FileSize = filePathInfo.FileSize,
                TypeId = typeId
            };

            fileBll.Insert(fileModel);

            if (fileModel.Id > 0)
            {
                DataUpdateLog.SingleUpdate(typeof(TraficFiles).Name, fileModel.Id, DataUpdateType.Insert);

                if (filePathInfo.FileExtension.ToLower() == ".zip")
                {
                    SearchHelper.AddSearchTask(1, fileModel.Id);
                }

                return Json(new
                {
                    msg = ErrorModel.OperateSuccess,
                    data = uploadRes,
                    fileId = fileModel.Id
                });
            }

            return Json(new { msg = ErrorModel.OperateFailed });
        }

        [HttpPost]
        public JsonResult DeleteFiles(int id)
        {
            var fileBll = new TraficFilesBll();
            var success = fileBll.DeleteSoftly(id);

            if (success)
            {
                DataUpdateLog.SingleUpdate(typeof(TraficFiles).Name, id, DataUpdateType.Update);

                DeleteSearchResult(1, id);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult AddDirectory()
        {
            var json = Request["directory"];
            var model = JsonHelper.Deserialize<TraficFileType>(json);

            if (model == null)
            {
                return Json(ErrorModel.InputError);
            }

            var dirBll = new TraficFileTypeBll();
            // 验证目录是否重名
            var condition = $"ParentId={model.ParentId} AND TypeName='{model.TypeName}'";
            if (dirBll.Exists(condition))
            {
                return Json(ErrorModel.DirectoryExists);
            }

            dirBll.Insert(model);

            if (model.Id > 0)
            {
                DataUpdateLog.SingleUpdate(typeof(TraficFileType).Name, model.Id, DataUpdateType.Insert);

                return Json(ErrorModel.AddDataSuccess(model.Id));
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult DeleteDirectory(int id)
        {
            var fileTypeBll = new TraficFileTypeBll();
            if (fileTypeBll.Exists("ParentId=" + id))
            {
                return Json(ErrorModel.DeleteForbidden);
            }

            var fileBll = new TraficFilesBll();
            if (fileBll.Exists("IsDelete=0 AND TypeId=" + id))
            {
                return Json(ErrorModel.DeleteForbidden);
            }

            var success = fileTypeBll.Delete(id);
            if (success)
            {
                DataUpdateLog.SingleUpdate(typeof(TraficFileType).Name, id, DataUpdateType.Delete);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult GetDirecAndFiles()
        {
            var directoryBll = new TraficFileTypeBll();
            var directories = directoryBll.QueryAll();

            var fileBll = new TraficFilesBll();
            var files = fileBll.QueryList("IsDelete=0");

            return Json(ErrorModel.GetDataSuccess(new
            {
                directories,
                files
            }));
        }

        [HttpPost]
        public JsonResult GetKeywords()
        {
            var keywordsBll = new TraficKeywordsBll();
            var list = keywordsBll.QueryList(null, null, null, "AddTime", true);

            return Json(ErrorModel.GetDataSuccess(list));
        }

        [HttpPost]
        public JsonResult AddKeywords(string keywords)
        {
            if (string.IsNullOrEmpty(keywords))
            {
                return Json(ErrorModel.InputError);
            }

            var model = new TraficKeywords
            {
                Keywords = keywords
            };

            var keywordsBll = new TraficKeywordsBll();
            keywordsBll.Insert(model);

            if (model.Id > 0)
            {
                DataUpdateLog.SingleUpdate(typeof(TraficKeywords).Name, model.Id, DataUpdateType.Insert);

                SearchHelper.AddSearchTask(2, model.Id);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        /// <summary>
        /// 接收客户端上传的文件并保存到本地，将保存的路径返回给客户端
        /// </summary>
        [HttpPost]
        public JsonResult FileUpload()
        {
            var uploadRes = UploadHelper.FileUpload();
            return Json(uploadRes);
        }

        /// <summary>
        /// 在删除文件或者关键字的同时将其对应的搜索结果删除
        /// </summary>
        /// <param name="targetType">
        ///     当此参数为1时，则第二个参数表示TraficFilesId
        ///     当此参数为2时，则第二个参数表示KeywordsId
        /// </param>
        /// <param name="targetId">文件Id或者关键字Id</param>
        private void DeleteSearchResult(int targetType, int targetId)
        {
            string condition;
            switch (targetType)
            {
                case 1:
                    condition = $"TraficFileId={targetId}";
                    break;
                case 2:
                    condition = $"KeywordsId={targetId}";
                    break;
                default:
                    return;
            }

            var resultBll = new TraficSearchResultBll();
            var list = resultBll.QueryList(condition, new[] {"Id"}).ToList();
            if (list.Any())
            {
                var idList = list.Select(item => item.Id);
                var tableName = typeof (TraficSearchResult).Name;
                
                resultBll.ExecuteTransation(
                    () => resultBll.Delete(condition),
                    () =>
                    {
                        DataUpdateLog.BulkUpdate(tableName, idList);
                        return true;
                    });
            }
            
        }
    }
}
