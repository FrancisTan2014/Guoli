using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;
using Guoli.MSSqlToSqlite;

namespace Guoli.Admin.Controllers
{
    public class SystemController : Controller
    {
        #region 账户管理

        [HttpPost]
        public JsonResult AddOrUpdate(SystemUser user, int[] menus)
        {
            if (user != null && menus != null)
            {
                var bll = new SystemUserBll();

                var loginUserId = LoginStatus.GetLoginId();
                if (user.Id == 0)
                {
                    user.CreatorId = loginUserId;
                    // 验证账户是否重复
                    if (bll.Exists($"[Account]='{user.Account}' AND IsDelete=0"))
                    {
                        return Json(ErrorModel.ExistSameItem);
                    }
                }
                user.Password = user.Password.GetMd5();

                var log = user.Id == 0 ? $"添加了新账户：{user.Name}-{user.Account}" : $"修改了账户：{user.Name}-{user.Account}";
                var operateType = user.Id == 0 ? DataUpdateType.Insert : DataUpdateType.Update;

                bool DoAddOrUpdate()
                {
                    if (user.Id == 0)
                    {
                        return bll.Insert(user).Id > 0;
                    }

                    return bll.Update(user);
                }

                var success = bll.ExecuteTransation(
                    DoAddOrUpdate,
                    () => AddPermisions(user, menus),
                    () => new OperateLogBll().Add(nameof(SystemUser), user.Id, operateType, loginUserId, log)
                );

                return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
            }
            else
            {
                return Json(ErrorModel.InputError);
            }
        }

        private bool AddPermisions(SystemUser user, IEnumerable<int> menus)
        {
            if (user != null && user.Id > 0 && menus != null)
            {
                Func<bool> clear;

                var bll = new PermissionBll();
                if (bll.Exists($"SystemUserId={user.Id} AND IsDelete=0"))
                {
                    clear = () => bll.Delete($"SystemUserId={user.Id}");
                }
                else
                {
                    clear = () => true;
                }

                var permissions = menus.Select(menuId => new Permission { MenuId = menuId, SystemUserId = user.Id });
                Func<bool> add = () =>
                {
                    bll.BulkInsert(permissions);
                    return true;
                };

                return bll.ExecuteTransation(clear, add);
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var bll = new SystemUserBll();
            var user = bll.QuerySingle(id);
            if (user == null)
            {
                return Json(ErrorModel.InputError);
            }

            var loginId = LoginStatus.GetLoginId();
            var log = $"删除了账户：{user.Name}-{user.Account}";
            var success = bll.ExecuteTransation(
                () => bll.DeleteSoftly(id),
                () => new OperateLogBll().Add(nameof(SystemUser), id, DataUpdateType.Delete, loginId, log)
            );

            return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult ChangePwd(string account, string oldPwd, string newPwd)
        {
            if (account.IsNullOrEmpty() || oldPwd.IsNullOrEmpty() || newPwd.IsNullOrEmpty())
            {
                return Json(ErrorModel.InputError);
            }

            if (oldPwd == newPwd)
            {
                return Json(ErrorModel.OperateSuccess);
            }

            var userBll = new SystemUserBll();
            var user = userBll.QuerySingle($"[Account]='{account}' AND IsDelete=0");
            if (user == null)
            {
                return Json(ErrorModel.InputError);
            }

            // 确保只有在旧密码输入正确的情况下才允许修改密码
            if (oldPwd.GetMd5() != user.Password)
            {
                return Json(ErrorModel.WrongPassword);
            }

            user.Password = newPwd.GetMd5();
            var success = userBll.ExecuteTransation(
                () => userBll.Update(user),
                () => new OperateLogBll().Add(nameof(SystemUser), user.Id, DataUpdateType.Update, 0,
                    $"修改了账户[{user.Account}]的密码")
            );

            return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
        }

        #endregion

        #region 路由器管理

        [HttpPost]
        public JsonResult AddOrUpdateRouter(InstructorRouterPosition model)
        {
            if (model != null)
            {
                var isUpdate = model.Id > 0;
                var updateType = isUpdate ? DataUpdateType.Update : DataUpdateType.Insert;

                var bll = new InstructorRouterPositionBll();
                Func<bool> doUpdate = () => bll.Insert(model).Id > 0;
                if (isUpdate)
                {
                    doUpdate = () => bll.Update(model);
                }

                var success = bll.ExecuteTransation(
                    doUpdate,
                    () => DataUpdateLog.SingleUpdate(nameof(InstructorRouterPosition), model.Id, updateType)
                );

                return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
            }

            return Json(ErrorModel.InputError);
        }

        #endregion

        #region 菜单管理

        [HttpPost]
        public JsonResult EditMenu(Menu menu)
        {
            if (menu == null)
            {
                return Json(ErrorModel.InputError);
            }

            var bll = new MenuBll();
            var success = menu.Id > 0 ? bll.Update(menu) : bll.Insert(menu).Id > 0;
            return Json(success ? ErrorModel.GetDataSuccess(menu) : ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult DeleteMenu(int id)
        {
            var bll = new MenuBll();
            if (bll.Exists($"ParentId={id} AND IsDelete=0"))
            {
                return Json(ErrorModel.DeleteForbidden);
            }

            var success = bll.Delete(id);
            return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult GetMenuList()
        {
            var bll = new MenuBll();
            var list = bll.QueryList("IsDelete=0");

            return Json(ErrorModel.GetDataSuccess(list));
        }

        [HttpPost]
        public JsonResult GetPermissions(int userId)
        {
            var bll = new ViewPermissionBll();
            var list = bll.QueryList($"SystemUserId={userId} AND IsDelete=0");

            return Json(ErrorModel.GetDataSuccess(list));
        }

        #endregion

        public JsonResult UploadSqliteDbScript()
        {
            var file = Request.Files[0];
            if (file != null && file.FileName.ToLower().EndsWith(".xml"))
            {
                var msToSqlite = new MsSqlToSqlite();
                file.SaveAs(msToSqlite.ScriptFilePath);

                msToSqlite.GetSqliteDb();
                return Json(ErrorModel.OperateSuccess);
            }
            else
            {
                return Json(ErrorModel.OperateFailed);
            }
        }

        public FileResult GetSqliteDb()
        {
            var msToSqlite = new MsSqlToSqlite();
            var fs = new FileStream(msToSqlite.SqliteDbPath, FileMode.Open, FileAccess.Read);

            return File(fs, "application/force-download", "Railroad.db");
        }
    }
}
