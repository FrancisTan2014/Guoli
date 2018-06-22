using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Guoli.Bll;
using Guoli.DataSync.classes;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;

namespace Guoli.DataSync
{
    /// <summary>
    /// 封装对同步信息的描述，包括
    ///     初始化 U 盘
    ///     验证 U 盘合法性
    ///     写入数据
    ///     读出数据
    /// 等等
    /// </summary>
    public class USBSync
    {
        private const string SyncDir = "Guoli.Sync";
        private const string IdentifyFilename = "e17d877beaec65f96b27dbdd16e5f709";
        private string JsonFilename => $"{RootDir}{SyncDir}/15caacaf54f28476017282b4a1fe1550";

        public USBDeviceInfo USBDevice { get; }

        public bool DeviceReady => USBDevice != null && Match(USBDevice.Directory);

        public string RootDir => USBDevice?.Directory;

        public USBSync()
        {
            USBDevice = GetInitializedUsb();
        }

        public bool Match(string rootDir)
        {
            if (!Directory.Exists(rootDir))
            {
                return false;
            }

            var syncDir = Path.Combine(rootDir, SyncDir);
            if (!Directory.Exists(syncDir))
            {
                return false;
            }

            var identifyFilename = Path.Combine(syncDir, IdentifyFilename);
            if (!File.Exists(identifyFilename))
            {
                return false;
            }

            return true;
        }

        public void InitUsb(string rootDir)
        {
            try
            {
                var identityBll = new DbIdentityBll();
                var list = identityBll.QueryAll();
                if (!list.Any())
                {
                    // TODO: 向表 DbIdentity 新增数据库标识
                    // TODO: 将新增的数据插入 list 中
                    
                }

                var maxId = (int)new DbUpdateLogBll().GetMaxId();

                var syncDir = Path.Combine(rootDir, SyncDir);
                Directory.CreateDirectory(syncDir);

                var identityFile = Path.Combine(syncDir, IdentifyFilename);
                File.Create(identityFile);

                File.Create(IdentifyFilename);
            }
            catch (Exception e)
            {
                throw new Exception("未检测到机务运用管控系统的服务，请联系管理员");
            }
        }

        private USBDeviceInfo GetInitializedUsb()
        {
            var devices = Utils.GetUsbDevices();
            var device = devices.SingleOrDefault(d => Match(d.Directory));
            return device;
        }

        public SyncInfo GetSyncInfo()
        {
            using (var fs = new FileStream(JsonFilename, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(fs))
                {
                    var json = reader.ReadToEnd();
                    return JsonHelper.Deserialize<SyncInfo>(json);
                }
            }
        }

        public void WriteSyncInfo(SyncInfo syncInfo)
        {
            using (var fs = new FileStream(JsonFilename, FileMode.Open, FileAccess.Write))
            {
                using (var writer = new StreamWriter(fs))
                {
                    var json = JsonHelper.Serialize(syncInfo);
                    writer.Write(json);
                }
            }
        }
    }
}
