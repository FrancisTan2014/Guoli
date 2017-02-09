using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Guoli.Admin.Models;
using Guoli.Utilities.Extensions;

namespace Guoli.Admin.Filters
{
    /// <summary>
    /// 本站页面身份验证类，提供对指定控制器或者方法执行登录验证的方法
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-15</since>
    public class Authority
    {
        /// <summary>
        /// 映射配置文件filter.config的根节点
        /// </summary>
        private static XElement FilterRoot { get; set; }

        /// <summary>
        /// 在本类第一次被使用时加载过滤器配置文件到内存中
        /// </summary>
        static Authority()
        {
            try
            {
                //var configPath = HttpContext.Current.Server.MapPath("/filter.config");
                // @FrancisTan 20170208
                var configPath = PathExtension.MapPath("/filter.config");
                
                FilterRoot = XElement.Load(configPath);
            }
            catch
            {
                throw new Exception("加载filter.config出现异常，请检查此配置文件");
            }
        }

        /// <summary>
        /// 判断执行指定控制器下的指定方法是否需要登录
        /// </summary>
        /// <param name="controller">指定控制器名称</param>
        /// <param name="action">指定方法名称</param>
        /// <returns>表示是否需要登录的布尔值</returns>
        public static bool WhetherNeedLogin(string controller, string action)
        {
            var controllerElements = FilterRoot.Elements();
            if (!controllerElements.Any())
            {
                return true;
            }

            var controllerElem = controllerElements.FirstOrDefault(e => e.Attribute("name").Value == controller);
            if (controllerElem == null)
            {
                return true;
            }

            // controller节点中hole属性为true，表示此控制器下所有方法均不需要做登录验证
            var holeAttr = controllerElem.Attribute("hole");
            if (holeAttr != null && holeAttr.Value == "true")
            {
                return false;
            }

            var actionElements = controllerElem.Elements();
            if (!actionElements.Any())
            {
                return true;
            }

            var actionElem = actionElements.FirstOrDefault(e => e.Value == action);
            if (actionElem == null)
            {
                return true;
            }

            // 当前请求的方法在配置文件中存在，则表示不需要做登录验证
            return false;
        }
    }
}