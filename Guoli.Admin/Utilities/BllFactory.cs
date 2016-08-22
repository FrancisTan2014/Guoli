using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Guoli.Admin.Utilities
{
    /// <summary>
    /// 提供根据条件创建bll层实体对象的方法
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-30</since>
    public static class BllFactory
    {
        /// <summary>
        /// 根据表名创建对应的bll层实体对象
        /// </summary>
        /// <param name="tableName">目标表名称</param>
        /// <returns>继承自BaseBll类型的子类对象</returns>
        public static object GetBllInstance(string tableName)
        {
            var assembly = Assembly.Load("Guoli.Bll");
            if (assembly == null)
            {
                throw new Exception("未能加载程序集Guoli.Bll");
            }

            var bllTypeName = string.Format("Guoli.Bll.{0}Bll", tableName);
            var bllEntity = assembly.CreateInstance(bllTypeName);
            if (bllEntity == null)
            {
                throw new Exception(string.Format("未能创建{0}类型的实例", bllTypeName));
            }

            return bllEntity;
        }
    }
}