/**  版本信息模板在安装目录下，可自行修改。
* DriveSignPoint.cs
*
* 功 能： N/A
* 类 名： DriveSignPoint
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:19   N/A    初版
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
	/// 行车签点记录以及重联机车变化记录
	/// </summary>
	[Serializable]
	public partial class DriveSignPoint
	{
		public DriveSignPoint()
		{}
		#region Model
		private int _id;
		private int _driverecordid;
		private int _stationid;
		private DateTime _arrivetime= Convert.ToDateTime("1900-01-01");
		private DateTime _leavetime= Convert.ToDateTime("1900-01-01");
		private int _earlyminutes=0;
		private int _lateminutes=0;
		private string _earlyorlatereason="";
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 手账记录Id，关联手账记录表主键
		/// </summary>
		public int DriveRecordId
		{
			set{ _driverecordid=value;}
			get{return _driverecordid;}
		}
		/// <summary>
		/// 车站Id，关联车站信息表主键
		/// </summary>
		public int StationId
		{
			set{ _stationid=value;}
			get{return _stationid;}
		}
		/// <summary>
		/// 实际到达本站时间
		/// </summary>
		public DateTime ArriveTime
		{
			set{ _arrivetime=value;}
			get{return _arrivetime;}
		}
		/// <summary>
		/// 实际出发时间
		/// </summary>
		public DateTime LeaveTime
		{
			set{ _leavetime=value;}
			get{return _leavetime;}
		}
		/// <summary>
		/// 列车早点分钟数
		/// </summary>
		public int EarlyMinutes
		{
			set{ _earlyminutes=value;}
			get{return _earlyminutes;}
		}
		/// <summary>
		/// 列车晚点分钟数
		/// </summary>
		public int LateMinutes
		{
			set{ _lateminutes=value;}
			get{return _lateminutes;}
		}
		/// <summary>
		/// 早晚点原因
		/// </summary>
		public string EarlyOrLateReason
		{
			set{ _earlyorlatereason=value;}
			get{return _earlyorlatereason;}
		}
		#endregion Model

	}
}

