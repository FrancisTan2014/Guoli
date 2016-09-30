using System.Web;
using Guoli.Admin.Utilities;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using CookieNames = Guoli.Admin.Utilities.CookieNames;
using SessionNames = Guoli.Admin.Utilities.SessionNames;

namespace Guoli.Admin.Models
{
    /// <summary>
    /// 提供对管理员登录状态进行管理的方法
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-14</since>
    public class LoginStatus
    {
        /// <summary>
        /// 在session中记录当前用户已登录
        /// </summary>
        public static void WriteSession()
        {
            SessionHelper.Set(SessionNames.LoginSession, true);
        }

        /// <summary>
        /// 从session中将当前用户已登录的记录移除
        /// </summary>
        public static void RemoveSession()
        {
            SessionHelper.Remove(SessionNames.LoginSession);
        }

        /// <summary>
        /// 将用户登录状态记录到cookie中
        /// </summary>
        public static void WriteCookie(int userId)
        {
            var encryptId = userId.ToString();
            var expire = 7*24*60*60; // 7天

            CookieHelper.Set(CookieNames.LoginCookie, encryptId, expire);
        }

        /// <summary>
        /// 将用户登录状态记录从cookie中移除
        /// </summary>
        public static void RemoveCookie()
        {
            CookieHelper.Remove(CookieNames.LoginCookie);
        }

        /// <summary>
        /// 从cookie中获取当前登录用户id
        /// </summary>
        /// <returns>当前登录管理员id</returns>
        public static int GetLoginId()
        {
            var encryptId = CookieHelper.Get(CookieNames.LoginCookie);

            return encryptId.ToInt32();
        }

        /// <summary>
        /// 判断当前是否已经登录
        /// </summary>
        /// <returns>返回表示是否已登录的布尔值</returns>
        public static bool IsLogin()
        {
            var session = SessionHelper.Get(SessionNames.LoginSession);
            if (null != session && session.Equals(true))
            {
                return true;
            }

            var userId = GetLoginId();
            if (userId > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 将当前请求终止，并重定向到登录页面
        /// </summary>
        public static void RedirectToLogin()
        {
            var context = HttpContext.Current;
            var requestUrl = context.Request.Url.ToString();

            if (RequestHelper.IsAsyncRequest())
            {
                var msg = ErrorModel.NeedLoginFirst(requestUrl);
                var json = JsonHelper.Serialize(msg);

                context.Response.Write(json);
                context.Response.End();
            }
            else
            {
                var redirectUrl = $"/Home/Login?backUrl={requestUrl}";
                context.Response.Redirect(redirectUrl);
            }
        }
    }
}