/**  版本信息模板在安装目录下，可自行修改。
* LineAnnounceCommands.cs
*
* 功 能： N/A
* 类 名： LineAnnounceCommands
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:24   N/A    初版
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
	/// 描述运行揭示命令与线路关系
	/// </summary>
	[Serializable]
	public partial class LineAnnounceCommands
	{
		public LineAnnounceCommands()
		{}
		#region Model
		private int _id;
		private int _trainnoid;
		private int _lineid;
		private int _driverid;
		private long _commandid;
		private bool _ispassed= false;
		private DateTime _passedtime= Convert.ToDateTime("1900-01-01");
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 车次Id，关联车次信息表的主键
		/// </summary>
		public int TrainNoId
		{
			set{ _trainnoid=value;}
			get{return _trainnoid;}
		}
		/// <summary>
		/// 线路id，关联线路信息表的主键
		/// </summary>
		public int LineId
		{
			set{ _lineid=value;}
			get{return _lineid;}
		}
		/// <summary>
		/// 运行司机Id，关联乘务员信息表主键
		/// </summary>
		public int DriverId
		{
			set{ _driverid=value;}
			get{return _driverid;}
		}
		/// <summary>
		/// 揭示Id，关联揭示命令表主键
		/// </summary>
		public long CommandId
		{
			set{ _commandid=value;}
			get{return _commandid;}
		}
		/// <summary>
		/// 是否通过
		/// </summary>
		public bool IsPassed
		{
			set{ _ispassed=value;}
			get{return _ispassed;}
		}
		/// <summary>
		/// 通过时间
		/// </summary>
		public DateTime PassedTime
		{
			set{ _passedtime=value;}
			get{return _passedtime;}
		}
		#endregion Model

	}
}

