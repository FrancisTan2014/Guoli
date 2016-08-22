/**  版本信息模板在安装目录下，可自行修改。
* DriveTrainNoAndLine.cs
*
* 功 能： N/A
* 类 名： DriveTrainNoAndLine
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:20   N/A    初版
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
	/// 描述手账-车次-线路对应关系
	/// </summary>
	[Serializable]
	public partial class DriveTrainNoAndLine
	{
		public DriveTrainNoAndLine()
		{}
		#region Model
		private int _id;
		private int _driverecordid;
		private int _trainnoid;
		private int _lineid;
		private DateTime _addtime= DateTime.Now;
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
		/// 手账记录Id，关联手账记录表主键
		/// </summary>
		public int DriveRecordId
		{
			set{ _driverecordid=value;}
			get{return _driverecordid;}
		}
		/// <summary>
		/// 车次Id，关联车次信息表主键
		/// </summary>
		public int TrainNoId
		{
			set{ _trainnoid=value;}
			get{return _trainnoid;}
		}
		/// <summary>
		/// 线路Id，关联线路信息表主键
		/// </summary>
		public int LineId
		{
			set{ _lineid=value;}
			get{return _lineid;}
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

