using System;
using System.Web.Mvc;
using Guoli.Admin.Models;
using Guoli.Bll;
using Guoli.Utilities.Helpers;
using CookieNames = Guoli.Admin.Utilities.CookieNames;
using Guoli.Utilities.Extensions;

namespace Guoli.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string backUrl)
        {
            ViewBag.BackUrl = backUrl;

            return View();
        }

        [HttpPost]
        public JsonResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var systemUserBll = new SystemUserBll();

                int userId;
                var loginResult = systemUserBll.Login(loginModel.Account, loginModel.Password, out userId);

                if (loginResult == LoginResult.NotExists || loginResult == LoginResult.PasswordError)
                {
                    return Json(ErrorModel.LoginFailed);
                }

                // 记录登录状态
                if (loginModel.Remember)
                {
                    LoginStatus.WriteCookie(userId);
                }
                else
                {
                    LoginStatus.RemoveCookie();
                    LoginStatus.WriteSession();
                }

                // 记录管理员id
                CookieHelper.Set(CookieNames.LoginUserId, userId.ToString());

                //====================================
                //2017-08-04 为使用vue做的后台生成token
                var token = $"{userId}:{DateTime.Now.Timestamp()}";
                var user = systemUserBll.QuerySingle(userId);
                user.Password = "";
                
                return Json(ErrorModel.LoginSuccess(new { token, user }));
            }

            return Json(ErrorModel.InputError);
        }

        [HttpPost]
        public JsonResult Exit()
        {
            LoginStatus.RemoveSession();
            LoginStatus.RemoveCookie();

            return Json(ErrorModel.Logout);
        }
    }
}
