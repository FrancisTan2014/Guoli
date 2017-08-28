using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guoli.Admin.Controllers
{
    public class SystemController : Controller
    {
        [HttpPost]
        public JsonResult AddOrUpdate(SystemUser user)
        {
            if (user != null)
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

                Func<bool> doAddOrUpdate = () =>
                {
                    if (user.Id == 0)
                    {
                        return bll.Insert(user).Id > 0;
                    }

                    return bll.Update(user);
                };

                var success = bll.ExecuteTransation(
                    () => doAddOrUpdate(),
                    () => new OperateLogBll().Add(nameof(SystemUser), user.Id, operateType, loginUserId, log)
                );

                return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
            }

            return Json(ErrorModel.InputError);
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
                () => new OperateLogBll().Add(nameof(SystemUser), user.Id, DataUpdateType.Update, 0, $"修改了账户[{user.Account}]的密码")
            );

            return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
        }
    }
}
