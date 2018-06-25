using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Management;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;

namespace Guoli.DataSync
{
    internal class Utils
    {
        public static List<string> GetClient2ServerTables()
        {
            var config = ConfigurationManager.AppSettings["Client2ServerTables"];
            if (config.IsNullOrEmpty())
            {
                throw new ConfigurationErrorsException("没有找到客户端向服务器端同步的表名这一项配置");
            }

            return config.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static List<string> GetServer2ClientTables()
        {
            var config = ConfigurationManager.AppSettings["Server2ClientTables"];
            if (config.IsNullOrEmpty())
            {
                throw new ConfigurationErrorsException("没有找到服务器端向客户端同步的表名这一项配置");
            }

            return config.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static string GetWebAppPath()
        {
            return ConfigurationManager.AppSettings["WebAppPath"];
        }

        public static IEnumerable<USBDeviceInfo> GetUsbDevices()
        {
            var list = new List<USBDeviceInfo>();

            foreach (var device in new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive WHERE InterfaceType LIKE 'USB%'").Get())
            {
                foreach (var partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value
                    + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                {
                    foreach (var disk in new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                        + partition["DeviceID"]
                        + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                    {
                        var dir = disk["Name"].ToString();
                        var volume = disk["VolumeName"].ToString();
                        var d = new USBDeviceInfo { Name = dir, VolumeName = volume };
                        list.Add(d);
                    }
                }
            }

            return list;
        }

        public static USBDeviceInfo GetInitializedUsb()
        {
            var devices = GetUsbDevices();
            return GetInitializedUsb(devices);
        }

        public static USBDeviceInfo GetInitializedUsb(IEnumerable<USBDeviceInfo> devices)
        {
            var device = devices.SingleOrDefault(d =>
            {
                var sync = new USBSync(d);
                return sync.Match();
            });
            return device;
        }

        /// <summary>
        /// 获取当前连接到的数据库的类型（0.未设置；1.服务端数据库；2.客户端数据库）
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentServerType()
        {
            var bll = new DbIdentityBll();
            var list = bll.QueryAll();
            if (list.Any())
            {
                var m = list.First();
                return m.Identity;
            }
            else
            {
                return 0;
            }
        }

        public static DbIdentity AddDbIdentity()
        {
            var m = new DbIdentity
            {
                Identity = 2,
                UniqueId = Guid.NewGuid()
            };

            var bll = new DbIdentityBll();
            for (var i = 0; i < 5; i++)
            {
                bll.Insert(m);
                if (m.Id > 0)
                {
                    return m;
                }
            }

            throw new Exception("数据库标识插入失败，请联系管理员");
        }

        public static void CopyNewFiles(List<string> files, string sourcePath, string targetPath)
        {
            if (sourcePath.IsNullOrEmpty())
            {
                throw new ArgumentNullException("源路径不能为空");
            }
            if (targetPath.IsNullOrEmpty())
            {
                throw new ArgumentNullException("目标路径不能为空");
            }
            if (!Directory.Exists(sourcePath))
            {
                throw new ArgumentException("源路径不存在");
            }
            if (!Directory.Exists(targetPath))
            {
                throw new ArgumentException("目标路径不存在");
            }

            if (files == null || files.Count == 0)
            {
                return;
            }

            var dir = targetPath;
            var list = files;
            list.ForEach(p =>
            {
                var destName = Path.Combine(dir, p); // 新的文件绝对路径
                var destDir = Path.GetDirectoryName(destName); // 新的目录绝对路径
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                var sourceName = Path.Combine(sourcePath, p);
                if (File.Exists(sourceName))
                {
                    File.Move(sourceName, destName);
                }
            });
        }
    }
}
