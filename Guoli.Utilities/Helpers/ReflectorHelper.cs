using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Guoli.Utilities.Helpers
{
    /// <summary>
    /// 反射工具类
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2017-02-10</since>
    public static class ReflectorHelper
    {
        /// <summary>
        /// 根据指定的程序集及类的全名创建类的实例
        /// </summary>
        /// <param name="assemblyName">指定的程序集名称</param>
        /// <param name="fullName">待创建实例的类型的全名</param>
        /// <returns>创建好的实例</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <author>FrancisTan</author>
        /// <since>2017-02-10</since>
        public static object GetInstance(string assemblyName, string fullName)
        {
            if (string.IsNullOrEmpty(assemblyName))
            {
                throw new ArgumentNullException(nameof(assemblyName));
            }
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentNullException(nameof(fullName));
            }

            var assembly = Assembly.Load(assemblyName);
            if (assembly == null)
            {
                throw new InvalidOperationException($"未能加载程序集{assemblyName}");
            }
            
            var instance = assembly.CreateInstance(fullName);
            if (instance == null)
            {
                throw new InvalidOperationException($"未能创建{fullName}类型的实例");
            }

            return instance;
        }

        /// <summary>
        /// 反射获取给定实例中指定属性名称的值
        /// </summary>
        /// <param name="instance">反射操作的实体对象</param>
        /// <param name="name">待获取的属性名称</param>
        /// <returns>返回获取到的值或者null</returns>
        public static object GetPropertyValue(object instance, string name)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var type = instance.GetType();
            var prop = type.GetProperty(name);

            return prop?.GetValue(instance, BindingFlags.GetProperty, null, null, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 执行指定类型的任意级别（static、public、private）的静态方法，并返回结果
        /// </summary>
        /// <param name="type">待执行的类型</param>
        /// <param name="methodName">待执行的方法名称</param>
        /// <param name="parameters">方法需要的参数集合</param>
        /// <returns>执行的结果</returns>
        public static object RunStaticMethod(Type type, string methodName, params object[] parameters)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            var method = type.GetMethod(methodName, flags);
            return method.Invoke(null, flags, null, parameters, null);
        }
    }
}
