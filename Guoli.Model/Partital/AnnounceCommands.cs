/**  版本信息模板在安装目录下，可自行修改。
* AnnounceCommands.cs
*
* 功 能： N/A
* 类 名： AnnounceCommands
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:15   N/A    初版
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
	/// 运行揭示命令表
	/// </summary>
	[Serializable]
	public partial class AnnounceCommands
	{
		public AnnounceCommands()
		{}
		#region Model
		private long _id;
		private string _commandno;
		private string _commandinterval="";
		private string _direction="";
		private string _speedlimitlocation="";
		private string _startendtime="";
		private DateTime _loseeffecttime= Convert.ToDateTime("1900-01-01");
		private int _limitedspeed=0;
		private DateTime _addtime= DateTime.Now;
		private bool _isactive= false;
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 调度命令号
		/// </summary>
		public string CommandNo
		{
			set{ _commandno=value;}
			get{return _commandno;}
		}
		/// <summary>
		/// 命令指示区间
		/// </summary>
		public string CommandInterval
		{
			set{ _commandinterval=value;}
			get{return _commandinterval;}
		}
		/// <summary>
		/// 列车运行方向，此方向是相对于北京来说，朝北京运行的方向称为“上行”，远离北京的运行方向称为“下行”
		/// </summary>
		public string Direction
		{
			set{ _direction=value;}
			get{return _direction;}
		}
		/// <summary>
		/// 限速地点
		/// </summary>
		public string SpeedLimitLocation
		{
			set{ _speedlimitlocation=value;}
			get{return _speedlimitlocation;}
		}
		/// <summary>
		/// 起止时间（字符串形式）
		/// </summary>
		public string StartEndTime
		{
			set{ _startendtime=value;}
			get{return _startendtime;}
		}
		/// <summary>
		/// 标识此揭示命令的失效时间
		/// </summary>
		public DateTime LoseEffectTime
		{
			set{ _loseeffecttime=value;}
			get{return _loseeffecttime;}
		}
		/// <summary>
		/// 限速值（km/h）
		/// </summary>
		public int LimitedSpeed
		{
			set{ _limitedspeed=value;}
			get{return _limitedspeed;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 标识此揭示命令当前是否有效
		/// </summary>
		public bool IsActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		#endregion Model

	}
}

