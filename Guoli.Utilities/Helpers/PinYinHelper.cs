using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPinyin;

namespace Guoli.Utilities.Helpers
{
    /// <summary>
    /// 汉字转拼音工具类
    /// </summary>
    public static class PinyinHelper
    {
        /// <summary>
        /// 获取给定汉字拼音首字母简写
        /// </summary>
        /// <param name="s">汉字字符串</param>
        /// <returns>拼音简写</returns>
        public static string GetInitials(string s)
        {
            return Pinyin.GetInitials(s);
        }
    }
}
