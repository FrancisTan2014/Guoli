using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Guoli.Bll;
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

        public bool DeviceReady => USBDevice != null && Match();

        public string RootDir => USBDevice?.Directory;

        public string USBFilePath => Path.Combine(RootDir, SyncDir);

        public USBSync(USBDeviceInfo device)
        {
            USBDevice = device;
        }

        public USBSync(string rootDir)
        {
            USBDevice = new USBDeviceInfo
            {
                Name = rootDir
            };
        }

        public bool Match()
        {
            if (!Directory.Exists(RootDir))
            {
                return false;
            }

            var syncDir = Path.Combine(RootDir, SyncDir);
            if (!Directory.Exists(syncDir))
            {
                return false;
            }

            var identifyFilename = Path.Combine(syncDir, IdentifyFilename);
            if (!File.Exists(identifyFilename))
            {
                return false;
            }

            var syncInfo = GetSyncInfo();
            if (syncInfo == null)
            {
                return false;
            }

            return true;
        }

        public void DoSync(int serverType, string webAppDir)
        {
            var syncInfo = GetSyncInfo();
            if (syncInfo == null)
            {
                throw new Exception("无法获取到同步信息的 json");
            }

            var sync = new SyncFactory().GetInstance(serverType);
            syncInfo = sync.Import(syncInfo);
            
            if (serverType == 2 && syncInfo.ClientWriteSuccess)
            {
                Utils.CopyNewFiles(syncInfo.PathList, USBFilePath, webAppDir);
            }

            var newSyncInfo = sync.Export(syncInfo);
            if (serverType == 1 && newSyncInfo.PathList.Any())
            {
                Utils.CopyNewFiles(newSyncInfo.PathList, webAppDir, USBFilePath);
            }

            ClearData(syncInfo);
            WriteSyncInfo(newSyncInfo);
        }

        private void ClearData(SyncInfo syncInfo)
        {
            if (syncInfo.ServerWriteSuccess)
            {
                // 服务端已成功导入客户端数据
                // 则将其设置为 null，以减少
                // 后面向文件中写入内容的大小
                syncInfo.ClientData = null;
            }
            if (syncInfo.ClientWriteSuccess)
            {
                syncInfo.ServerData = null;
                syncInfo.PathList = null;
            }
        }

        public void InitUsb()
        {
            try
            {
                var identityBll = new DbIdentityBll();
                var list = identityBll.QueryAll().ToList();
                if (!list.Any())
                {
                    // TODO: 向表 DbIdentity 新增数据库标识
                    // TODO: 将新增的数据插入 list 中
                    var identity = Utils.AddDbIdentity();
                    list.Add(identity);
                }

                var dbIdentity = list.First();
                var maxId = (int)new DbUpdateLogBll().GetMaxId();

                var syncDir = Path.Combine(RootDir, SyncDir);
                Directory.CreateDirectory(syncDir);

                var identityFile = Path.Combine(syncDir, IdentifyFilename);
                File.Create(identityFile);

                var syncInfo = new SyncInfo
                {
                    DbIdentity = dbIdentity.UniqueId,
                    ServerWriteSuccess = true,
                    ClientNewDataFlag = false,
                    DbUpdateLogMaxId = maxId
                };
                WriteSyncInfo(syncInfo);
            }
            catch (Exception e)
            {
                throw new Exception("未检测到机务运用管控系统的服务，请联系管理员");
            }
        }

        private SyncInfo GetSyncInfo()
        {
            if (!File.Exists(JsonFilename))
            {
                return null;
            }

            using (var fs = new FileStream(JsonFilename, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(fs))
                {
                    var json = reader.ReadToEnd();
                    if (json.IsNullOrEmpty())
                    {
                        return null;
                    }

                    return JsonHelper.Deserialize<SyncInfo>(json);
                }
            }
        }

        private void WriteSyncInfo(SyncInfo syncInfo)
        {
            using (var writer = new StreamWriter(JsonFilename, false))
            {
                var json = JsonHelper.Serialize(syncInfo);
                writer.Write(json);
            }
        }
    }
}
