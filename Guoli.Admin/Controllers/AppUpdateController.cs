using Guoli.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guoli.Utilities.Extensions;
using Guoli.Bll;
using System.IO;
using Guoli.Admin.Utilities;
using Guoli.Utilities.Helpers;
using Guoli.Model;

namespace Guoli.Admin.Controllers
{
    /// <summary>
    /// app更新发布业务逻辑
    /// </summary>
    public class AppUpdateController : Controller
    {
        [HttpPost]
        public JsonResult Upload()
        {
            // 获取文件流
            var file = Request.Files[0];
            if (file == null)
            {
                return Json(ErrorModel.InputError);
            }

            // 获取文件hash值
            var hash = file.InputStream.GetMd5();

            // 生成版本号和文件名
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            // 处理相对路径与绝对路径
            var relatePath = Path.Combine(AppSettings.ApkFiles, fileName).Replace("\\", "/");
            var absolutePath = PathExtension.MapPath(relatePath);
            var dir = absolutePath.Replace(fileName, "");
            if (!Directory.Exists(absolutePath))
            {
                Directory.CreateDirectory(dir);
            }

            // 存储到本地
            file.SaveAs(absolutePath);

            return Json(new
            {
                path = relatePath,
                hash
            });
        }

        /// <summary>
        /// 根据app更新级别，在最近发布的app版本号的基础上生成新的版本号
        /// 若是第一次发布，则返回1.0.0.xxxx
        /// </summary>
        /// <param name="level">app更新级别（1.重大版本更新；2.模块局部更新；3.BUG修复；）</param>
        /// <returns>带有发布日期的版本号</returns>
        private string GenerateVersion(int level)
        {
            if (level < 1 || level > 3)
            {
                return "";
            }

            var bll = new AppUpdateBll();
            var latest = bll.QueryAll().LastOrDefault();
            var pubTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (latest == null)
            {
                return "1.0.0." + pubTime;
            }

            var versionNums = latest.Version.Split('.').Select(s => Convert.ToInt64(s)).ToList();
            var mainVersion = versionNums[0];
            var subVersion = versionNums[1];
            var reviseVersion = versionNums[2];
            if (level == 1)
            {
                // 重大版本更新，将主版本号+1
                return $"{mainVersion + 1}.0.0.{pubTime}";
            }
            else if (level == 2)
            {
                // 模块局部更新，将次版本号+1
                return $"{mainVersion}.{subVersion + 1}.0.{pubTime}";
            }
            else
            {
                // BUG修复，将修订版本号+1
                return $"{mainVersion}.{subVersion}.{reviseVersion + 1}.{pubTime}";
            }
        }

        [HttpPost]
        public JsonResult Add(AppUpdate model, int level)
        {
            if (model != null)
            {
                model.Version = GenerateVersion(level);
                model.Token = $"guoli.app.upgradedat:{model.AddTime.ToString("yyyyMMddHHmmss")}".GetMd5();

                var bll = new AppUpdateBll();
                var success = bll.Insert(model).Id > 0;

                return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
            }

            return Json(ErrorModel.InputError);
        }
    }
}
