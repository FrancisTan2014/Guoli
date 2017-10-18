using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;

namespace Guoli.Utilities.Helpers
{
    /// <summary>
    /// 操作应用程序配置文件的帮助类
    /// </summary>
    public static class ConfigHelper
    {
        public static void ChangeAppsettings(string key, string value)
        {
            var path = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            var doc = new XmlDocument();
            doc.Load(path);
            var node = doc.SelectSingleNode($"//appSettings/add[@key='${key}']");
            if (node != null)
            {
                node.Attributes["value"].Value = value;
                doc.Save(path);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}
