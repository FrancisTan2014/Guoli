using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guoli.Utilities.Extensions;

namespace Guoli.Bll
{
    public partial class SystemUserBll
    {
        /// <summary>
        /// 与数据库对比用户输入的用户名及密码，返回登录结果
        /// </summary>
        /// <param name="userName">用户输入的用户名</param>
        /// <param name="password">用户输入的密码</param>
        /// <returns>表示登录结果的枚举值</returns>
        public LoginResult Login(string userName, string password, out int userId)
        {
            var user = DalInstance.QuerySingle(
                "Account=@account AND IsDelete=0", 
                null, 
                new Dictionary<string, object>{ {"@account", userName} });

            userId = 0;
            if (user == null)
            {
                return LoginResult.NotExists;
            }

            userId = user.Id;

            var encrytPwd = password.GetMd5();
            if (encrytPwd == user.Password)
            {
                return LoginResult.Success;
            }

            return LoginResult.PasswordError;
        }
    }
}
