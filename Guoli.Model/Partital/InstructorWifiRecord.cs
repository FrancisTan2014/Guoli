/**  版本信息模板在安装目录下，可自行修改。
* InstructorWifoRecord.cs
*
* 功 能： N/A
* 类 名： InstructorWifoRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/28 11:28:58   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Guoli.Model
{
	/// <summary>
	/// Wifi连接记录
	/// </summary>
	[Serializable]
	public partial class InstructorWifiRecord
	{
		public InstructorWifiRecord()
		{}
		#region Model
		private int _id;
		private int _instructorid;
        private int _deviceid;
		private int _routerpositionid;
		private int _connectflag;
		private DateTime _connecttime;
		private bool _isdelete= false;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 指导司机Id
		/// </summary>
		public int InstructorId
		{
			set{ _instructorid=value;}
			get{return _instructorid;}
		}
		/// <summary>
		/// 路由器地点对照表Id，用于确定所在位置
		/// </summary>
		public int RouterPositionId
		{
			set{ _routerpositionid=value;}
			get{return _routerpositionid;}
		}
		/// <summary>
		/// 连接断开标识（1 连接； 2 断开）
		/// </summary>
		public int ConnectFlag
		{
			set{ _connectflag=value;}
			get{return _connectflag;}
		}
		/// <summary>
		/// 连接时间
		/// </summary>
		public DateTime ConnectTime
		{
			set{ _connecttime=value;}
			get{return _connecttime;}
		}
        /// <summary>
        /// 设备 Id
        /// </summary>
        public int DeviceId
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
		/// <summary>
		/// 删除标识
		/// </summary>
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

