using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Utilities;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using CookieNames = Guoli.Admin.Utilities.CookieNames;
using SessionNames = Guoli.Admin.Utilities.SessionNames;
using System.Text.RegularExpressions;
using System;

namespace Guoli.Admin.Models
{
    /// <summary>
    /// 提供对管理员登录状态进行管理的方法
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-14</since>
    public class LoginStatus
    {
        private const int LoginExpireDays = 7;

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
            var expire = LoginExpireDays * 24*60*60; 

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
        /// 从cookie或token中获取当前登录用户id
        /// </summary>
        /// <returns>当前登录管理员id</returns>
        public static int GetLoginId()
        {
            var encryptId = CookieHelper.Get(CookieNames.LoginCookie);
            if (string.IsNullOrEmpty(encryptId))
            {
                int userId;
                var token = HttpContext.Current.Request["token"];
                IsTokenLegal(token, out userId);

                return userId;
            }

            return encryptId.ToInt32();
        }

        /// <summary>
        /// 判断当前是否已经登录
        /// </summary>
        /// <returns>返回表示是否已登录的布尔值</returns>
        public static bool IsLogin()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                var token = ctx.Request["token"];
                if (!string.IsNullOrEmpty(token))
                {
                    int userId;
                    // 验证跨域请求token是否合法
                    return IsTokenLegal(token, out userId);
                }
                else
                {
                    // 验证本地请求是否已登录
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
                }                
            }            

            return false;
        }

        /// <summary>
        /// 验证登录token是否合法
        ///     1. 验证时间戳是否过期
        ///     2. 验证UserId是否大于零
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsTokenLegal(string token, out int userId)
        {
            userId = 0;

            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            var pattern = @"^(\d+):(\d+)$";
            var match = Regex.Match(token, pattern);
            if (match.Success)
            {
                userId = Convert.ToInt32(match.Groups[1].Value);
                var timestamp = Convert.ToInt64(match.Groups[2].Value);
                var expires = LoginExpireDays * 24 * 3600 * 1000;
                if (DateTime.Now.Timestamp() - timestamp <= expires)
                {
                    return userId > 0;
                }
            }

            return false;
        }

        /// <summary>
        /// 将当前请求终止，并重定向到登录页面
        /// </summary>
        public static ActionResult RedirectToLogin()
        {
            var context = HttpContext.Current;
            var requestUrl = context.Request.Url.ToString();

            if (RequestHelper.IsAsyncRequest())
            {
                var msg = ErrorModel.NeedLoginFirst(requestUrl);

                var jsonResult = new JsonResult
                {
                    ContentType = "application/json",
                    Data = msg
                };

                return jsonResult;
            }
            else
            {
                var redirectUrl = $"/Home/Login?backUrl={requestUrl}";
                return new RedirectResult(redirectUrl);
            }
        }
    }
}