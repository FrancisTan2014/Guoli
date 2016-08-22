/**  版本信息模板在安装目录下，可自行修改。
* TrainFormation.cs
*
* 功 能： N/A
* 类 名： TrainFormation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:30   N/A    初版
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
	/// 手账-列车编组记录
	/// </summary>
	[Serializable]
	public partial class TrainFormation
	{
		public TrainFormation()
		{}
		#region Model
		private int _id;
		private int _driverecordid;
		private int _stationid;
		private int _carriagecount;
		private decimal _carryingcapacity;
		private decimal _length;
		private DateTime _notetime;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 手账Id，关联手账记录表的主键
		/// </summary>
		public int DriveRecordId
		{
			set{ _driverecordid=value;}
			get{return _driverecordid;}
		}
		/// <summary>
		/// 车站Id，关联车站信息表的主键
		/// </summary>
		public int StationId
		{
			set{ _stationid=value;}
			get{return _stationid;}
		}
		/// <summary>
		/// 列车编组-辆数
		/// </summary>
		public int CarriageCount
		{
			set{ _carriagecount=value;}
			get{return _carriagecount;}
		}
		/// <summary>
		/// 列车编组-吨数（载重）
		/// </summary>
		public decimal CarryingCapacity
		{
			set{ _carryingcapacity=value;}
			get{return _carryingcapacity;}
		}
		/// <summary>
		/// 列车编组-计长
		/// </summary>
		public decimal Length
		{
			set{ _length=value;}
			get{return _length;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime NoteTime
		{
			set{ _notetime=value;}
			get{return _notetime;}
		}
		#endregion Model

	}
}

