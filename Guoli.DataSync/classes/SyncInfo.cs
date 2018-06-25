using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.DataSync
{
    public class SyncInfo
    {
        /// <summary>
        /// 客户端数据库标识
        /// </summary>
        public Guid DbIdentity { get; set; }

        /// <summary>
        /// 基础数据更新标记（DbUpdateLog表的最大Id）
        /// </summary>
        public int DbUpdateLogMaxId { get; set; }

        /// <summary>
        /// 客户端本次导出各数据表的最大 Id 字典
        /// </summary>
        public Dictionary<string, int> ExportMaxIdDict { get; set; }

        /// <summary>
        /// 服务端数据写入成功标识
        /// </summary>
        public bool ServerWriteSuccess { get; set; }

        /// <summary>
        /// 客户端数据定入成功标识
        /// </summary>
        public bool ClientWriteSuccess { get; set; }

        /// <summary>
        /// 服务端是否有新数据的标识
        /// </summary>
        public bool ServerNewDataFlag { get; set; }

        /// <summary>
        /// 客户端是否有新数据的标识
        /// </summary>
        public bool ClientNewDataFlag { get; set; }

        /// <summary>
        /// 服务端新数据
        /// </summary>
        public Dictionary<string, object> ServerData { get; set; }

        /// <summary>
        /// 客户端新数据
        /// </summary>
        public Dictionary<string, object> ClientData { get; set; }

        /// <summary>
        /// 需要拷贝的文件路径集合
        /// </summary>
        public List<string> PathList { get; set; }

        public SyncInfo()
        {
            PathList = new List<string>();
            ClientData = new Dictionary<string, object>();
            ServerData = new Dictionary<string, object>();
            ExportMaxIdDict = new Dictionary<string, int>();
        }
    }
}
