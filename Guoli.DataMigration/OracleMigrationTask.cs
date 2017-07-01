using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Guoli.DataMigration.Classes;
using Guoli.Utilities.Helpers;
using System.IO;
using Guoli.Utilities.Extensions;

namespace Guoli.DataMigration
{
    /// <summary>
    /// 对外提供完成从Oracle数据库同步数据到系统数据库的方法
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2017-03-10</since>
    public sealed class OracleMigrationTask
    {
        /// <summary>
        /// 获取配置文件中的待执行数据同步的任务列表
        /// 我们约定配置文件中的配置项以不变量类<see cref="Constants"/>中的前缀字符串开头
        /// 如：
        ///     <add key="_migration_DepartmentMigration" value="Guoli.DataMigration.DepartmentMigration" />
        /// </summary>
        /// <returns>返回获取到的任务列表或者空列表</returns>
        private static List<IMigration> GetSyncTasks()
        {
            var tasks = new List<IMigration>();

            try
            {
                var assemblyName = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                var appSettings = ConfigurationManager.AppSettings;
                var configKeys = appSettings.AllKeys.Where(key => key.StartsWith(Constants.PrefixOfMigrationTasks));
                tasks.AddRange(
                    configKeys.Select(key => ReflectorHelper.GetInstance($"{assemblyName}", appSettings[key]))
                    .Cast<IMigration>());
            }
            catch (Exception ex)
            {
                // Ignore
            }

            return tasks;
        }

        /// <summary>
        /// 执行数据同步操作
        /// 通过获取在配置文件中所配置的实现了<see cref="IMigration"/>接口的类型名称，
        /// 并反射创建类型集合，最终循环执行同步操作
        /// </summary>
        public static void ExecuteDataSynchronization()
        {
            try
            {
                var tasks = GetSyncTasks();
                tasks.ForEach(task =>
                {
                    task.ImportNewData();
                    task.UpdateEditedData();
                });
            }
            catch (Exception ex)
            {
                var logPath = PathExtension.MapPath("service.log");
                FileHelper.Write(logPath, ex.ToString());
            }
        }
    }
}
