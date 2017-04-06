using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guoli.Utilities.Extensions;

namespace Guoli.Utilities.Helpers
{
    /// <summary>
    /// 提供对明文字符串进行加密或者解密的方法
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2017-02-17</since>
    public static class EncryptHelper
    {
        /// <summary>
        /// 对密码进行加密，返回加密后的密文
        /// </summary>
        /// <param name="password">待加密的明文字符串</param>
        /// <returns>加密后的密文字符串</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string EncryptPassword(string password)
        {
            return password?.GetMd5();
        }
    }
}
