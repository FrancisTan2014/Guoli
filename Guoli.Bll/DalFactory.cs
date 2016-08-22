using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Guoli.Dal;

namespace Guoli.Bll
{
    /// <summary>
    /// 数据访问层对象工厂类
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-14</since>
    public class DalFactory
    {
        /// <summary>
        /// 根据指定Model层对象的类型，创建与其相对应的Dal层对象
        /// </summary>
        /// <typeparam name="T">Model层对象类型</typeparam>
        /// <returns>与指定类型对应的Dal层实例</returns>
        public static BaseDal<T> CreateInstance<T>() where T : class,new()
        {
            var model = new T();
            var type = model.GetType();
            var dalFullName = string.Format("Guoli.Dal.{0}Dal", type.Name);

            var assembly = Assembly.Load("Guoli.Dal");
            if (assembly == null)
            {
                throw new Exception("未能加载程序集Guoli.Dal");
            }

            var dalInstance = (BaseDal<T>)assembly.CreateInstance(dalFullName);
            if (dalInstance == null)
            {
                var msg = string.Format("创建{0}的实例失败", dalFullName);
                throw new Exception(msg);
            }

            return dalInstance;
        }
    }
}
