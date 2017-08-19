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
            var departId = Request["depart"].ToInt32();
            if (typeId == 0 || departId == 0)
            {
                return Json(new { msg = ErrorModel.InputError });
            }

            // 将文件保存到本地
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

            var loginUser = LoginStatus.GetLoginId();
            var fileModel = new TraficFiles
            {
                FileExtension = filePathInfo.FileExtension,
                FileName = filePathInfo.OriginalFileName,
                FilePath = filePathInfo.FileRelativePath,
                FileSize = filePathInfo.FileSize,
                TypeId = typeId,
                CreatorId = loginUser,
                DepartmentId = departId
            };

            var logBll = new OperateLogBll();
            var dirBll = new TraficFileTypeBll();
            var dir = dirBll.QuerySingle(typeId);
            var log = $"在目录[{dir.TypeName}]下添加了文件《{filePathInfo.OriginalFileName}》";

            // 执行插入操作、数据库更新日志插入操作以及后台操作日志插入操作
            var success = fileBll.ExecuteTransation(
                () => fileBll.Insert(fileModel).Id > 0,
                () => DataUpdateLog.SingleUpdate(nameof(TraficFiles), fileModel.Id, DataUpdateType.Insert),
                () => logBll.Add(nameof(TraficFiles), fileModel.Id, DataUpdateType.Insert, loginUser, log)
            );

            if (success)
            {
                if (filePathInfo.FileExtension.ToLower() == ".zip")
                {
                    SearchHelper.AddSearchTask(1, fileModel.Id);
                }

                return Json(new
                {
                    msg = ErrorModel.OperateSuccess,
                    data = uploadRes,
                    fileId = fileModel.Id,
                    fileModel
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
                DataUpdateLog.SingleUpdate(typeof(TraficFiles).Name, id, DataUpdateType.Delete);

                DeleteSearchResult(1, id);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult AddDirectory(string directory)
        {
            var model = JsonHelper.Deserialize<TraficFileType>(directory);

            if (model == null)
            {
                return Json(ErrorModel.InputError);
            }

            var dirBll = new TraficFileTypeBll();
            // 验证目录是否重名
            var condition = $"ParentId={model.ParentId} AND TypeName='{model.TypeName}' AND IsDelete=0";
            if (dirBll.Exists(condition))
            {
                return Json(ErrorModel.DirectoryExists);
            }

            // 准备数据库操作事务
            var updateType = model.Id > 0 ? DataUpdateType.Update : DataUpdateType.Insert;
            var log = $"添加了目录[{model.TypeName}]";
            Func<bool> doAddOrUpdate = () => dirBll.Insert(model).Id > 0;
            if (model.Id > 0)
            {
                var viewDirBll = new ViewTraficFileTypeBll();
                var origin = viewDirBll.QuerySingle(model.Id);
                var newDepartName = new DepartInfoBll().QuerySingle(model.DepartmentId, new[] { nameof(DepartInfo.DepartmentName) }).DepartmentName;
                log = $"将目录由[{origin.TypeName}-{origin.DepartmentName}-{(origin.IsPublic ? "公共文件夹" : "私有文件夹")}]更新为[{model.TypeName}-{newDepartName}-{(model.IsPublic ? "公共文件夹" : "私有文件夹")}]";
                doAddOrUpdate = () => dirBll.Update(model);
            }

            // 执行事务
            var loginUser = LoginStatus.GetLoginId();
            var logBll = new OperateLogBll();
            var success = dirBll.ExecuteTransation(
                doAddOrUpdate,
                () => DataUpdateLog.SingleUpdate(nameof(TraficFileType), model.Id, updateType),
                () => logBll.Add(nameof(TraficFileType), model.Id, updateType, loginUser, log)
            );

            return Json(success ? ErrorModel.AddDataSuccess(model.Id) : ErrorModel.OperateFailed);
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
            var directoryBll = new ViewTraficFileTypeBll();
            var directories = directoryBll.QueryList("IsDelete=0");

            var fileBll = new ViewTraficFilesBll();
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
            var list = resultBll.QueryList(condition, new[] { "Id" }).ToList();
            if (list.Any())
            {
                var idList = list.Select(item => item.Id);
                var tableName = typeof(TraficSearchResult).Name;

                resultBll.ExecuteTransation(
                    () => resultBll.Delete(condition),
                    () =>
                    {
                        DataUpdateLog.BulkUpdate(tableName, idList);
                        return true;
                    });
            }

        }

        //===========================================================
        // 2017-08-04 为vue重构的后台增加接口

        /// <summary>
        /// 文件或者目录重命名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type">
        ///     1 为目录重命名
        ///     2 为文件重命名
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Rename(int id, string name)
        {
            var viewFileBll = new ViewTraficFilesBll();
            var fileBll = new TraficFilesBll();
            var logBll = new OperateLogBll();

            var origin = viewFileBll.QuerySingle(id);
            var log = $"将目录[{origin.TypeName}]下的文件[{origin.FileName}]重命名为[{name}]";
            var success = fileBll.ExecuteTransation(
                () => fileBll.Update(new TraficFiles { Id = id, FileName = name }, new string[] { nameof(TraficFiles.FileName) }),
                () => DataUpdateLog.SingleUpdate(nameof(TraficFiles), id, DataUpdateType.Update),
                () => logBll.Add(nameof(TraficFiles), id, DataUpdateType.Update, LoginStatus.GetLoginId(), log)
            );

            return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
        }

        /// <summary>
        /// 删除文件或目录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type">
        ///     1 删除目录
        ///     2 删除文件
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int id, int type)
        {
            bool success = false;

            if (type == 1)
            {
                success = DeleteDirectoryAndChildren(id);
            }
            else if (type == 2)
            {
                var fileBll = new ViewTraficFilesBll();
                var file = fileBll.QuerySingle(id);
                if (file == null)
                {
                    success = false;
                }
                else
                {
                    var log = $"删除了目录[{file.TypeName}]下的文件《{file.FileName}》";
                    var logBll = new OperateLogBll();
                    success = fileBll.ExecuteTransation(
                        () => fileBll.DeleteSoftly(id),
                        () => DataUpdateLog.SingleUpdate(nameof(TraficFiles), id, DataUpdateType.Delete),
                        () => logBll.Add(nameof(TraficFiles), id, DataUpdateType.Delete, LoginStatus.GetLoginId(), log)
                    );
                }
            }

            if (success)
            {
                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        /// <summary>
        /// 删除目录，将在事务环境中执行以下操作
        ///  1. 删除此目录及所有子目录
        ///  2. 删除此目录及所有子目录下的文件
        ///  3. 删除此与此目录下所有文件关联的关键字搜索结果数据
        ///  4. 将操作同步到DbUpdateLog表中
        ///  5. 将操作日志记录到OperateLog表中
        /// </summary>
        /// <param name="id">待删除的目录Id</param>
        /// <returns></returns>
        private bool DeleteDirectoryAndChildren(int id)
        {
            var dirBll = new TraficFileTypeBll();
            var dirList = dirBll.QueryList("IsDelete=0", new[] { nameof(TraficFileType.Id), nameof(TraficFileType.ParentId), nameof(TraficFileType.TypeName) }).ToList();
            var deleteDir = dirList.Find(dir => dir.Id == id);
            if (deleteDir == null)
            {
                return false;
            }

            var fileBll = new TraficFilesBll();
            var fileList = fileBll.QueryList("IsDelete=0", new[] { nameof(TraficFiles.Id), nameof(TraficFiles.TypeId) }).ToList();

            // 所有待删除的目录Id
            var dirDeleteIdList = new List<int> { id };
            FindChildDirIds(dirList, id, dirDeleteIdList);

            // 所有待删除的文件Id
            var fileDeleteIdList = fileList.Where(file => dirDeleteIdList.Contains(file.TypeId)).Select(file => file.Id).ToList();

            // 所有待删除的搜索结果Id
            var searchBll = new TraficSearchResultBll();
            var searchSql = $"TraficFileId IN({string.Join(",", fileDeleteIdList.Count == 0 ? new List<int> { 0 } : fileDeleteIdList)})"; // 不能让sql语句中IN()中的字符串为空
            var searchIdList = searchBll.QueryList(searchSql, new[] { nameof(TraficSearchResult.Id) })
                .Select(item => item.Id).ToList();

            // 操作日志
            var log = $"删除了目录[{deleteDir.TypeName}]及其所有的子目录和子文件";

            // 准备sql语句
            var dirDeleteSql = $"UPDATE TraficFileType SET IsDelete=1 WHERE Id IN({string.Join(",", dirDeleteIdList)})";
            var fileDeleteSql = $"UPDATE TraficFiles SET IsDelete=1 WHERE Id IN({string.Join(",", fileDeleteIdList)})";
            var searchDeleteSql = $"DELETE FROM TraficSearchResult WHERE TraficFileId IN({string.Join(",", fileDeleteIdList)})";

            // 准备执行委托
            var logBll = new OperateLogBll();
            var loginUser = LoginStatus.GetLoginId();
            Func<bool> deleteDirs = () => dirBll.ExecuteSql(dirDeleteSql) == dirDeleteIdList.Count;
            Func<bool> deleteFiles = () => fileDeleteIdList.Count == 0 ? true : fileBll.ExecuteSql(fileDeleteSql) == fileDeleteIdList.Count;
            Func<bool> deleleSearch = () => searchIdList.Count == 0 ? true : searchBll.ExecuteSql(searchDeleteSql) == searchIdList.Count;
            Func<bool> insertDirUpdateLog = () => { DataUpdateLog.BulkUpdate(nameof(TraficFileType), dirDeleteIdList, DataUpdateType.Delete); return true; };
            Func<bool> insertFileUpdateLog = () => { DataUpdateLog.BulkUpdate(nameof(TraficFiles), fileDeleteIdList, DataUpdateType.Delete); return true; };
            Func<bool> insertSearchUpdateLog = () => { DataUpdateLog.BulkUpdate(nameof(TraficSearchResult), searchIdList, DataUpdateType.Delete); return true; };
            Func<bool> insertOperateLog = () => logBll.Add(nameof(TraficFileType), id, DataUpdateType.Delete, loginUser, log);

            // 执行事务
            var success = dirBll.ExecuteTransation(
                deleteDirs,
                deleteFiles,
                deleleSearch,
                insertDirUpdateLog,
                insertFileUpdateLog,
                insertSearchUpdateLog,
                insertOperateLog
            );

            return success;
        }

        private void FindChildDirIds(List<TraficFileType> dirList, int parent, List<int> result)
        {
            var children = dirList.Where(item => item.ParentId == parent).ToList();
            if (children.Count > 0)
            {
                children.ForEach(item =>
                {
                    result.Add(item.Id);
                    FindChildDirIds(dirList, item.Id, result);
                });
            }
        }
    }
}
