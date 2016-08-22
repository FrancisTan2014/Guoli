/**  版本信息模板在安装目录下，可自行修改。
* InstructorLocoQuality.cs
*
* 功 能： N/A
* 类 名： InstructorLocoQuality
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:01   N/A    初版
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
	/// 机车质量登记
	/// </summary>
	[Serializable]
	public partial class InstructorLocoQuality
	{
		public InstructorLocoQuality()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _registdate;
		private string _traincode;
		private string _locomotivetype;
		private int _driverid;
		private string _repairclass;
		private string _maintenancestatus;
	    private decimal _score;
		private string _faultlocation;
		private string _generalsituation="";
		private DateTime _uploadtime= DateTime.Now;
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
		/// 指导司机Id，关联乘务员信息表主键
		/// </summary>
		public int InstructorId
		{
			set{ _instructorid=value;}
			get{return _instructorid;}
		}
		/// <summary>
		/// 登记日期
		/// </summary>
		public DateTime RegistDate
		{
			set{ _registdate=value;}
			get{return _registdate;}
		}
		/// <summary>
		/// 车次
		/// </summary>
		public string TrainCode
		{
			set{ _traincode=value;}
			get{return _traincode;}
		}
		/// <summary>
		/// 机车型号
		/// </summary>
		public string LocomotiveType
		{
			set{ _locomotivetype=value;}
			get{return _locomotivetype;}
		}
		/// <summary>
		/// 主班司机Id，关联乘务员信息表主键
		/// </summary>
		public int DriverId
		{
			set{ _driverid=value;}
			get{return _driverid;}
		}
		/// <summary>
		/// 修程
		/// </summary>
		public string RepairClass
		{
			set{ _repairclass=value;}
			get{return _repairclass;}
		}
		/// <summary>
		/// 保养状态
		/// </summary>
		public string MaintenanceStatus
		{
			set{ _maintenancestatus=value;}
			get{return _maintenancestatus;}
		}
        /// <summary>
        /// 评定成功
        /// </summary>
	    public decimal Score
	    {
	        set { _score = value; }
            get { return _score; }
	    }
		/// <summary>
		/// 惯性及故障处所
		/// </summary>
		public string FaultLocation
		{
			set{ _faultlocation=value;}
			get{return _faultlocation;}
		}
		/// <summary>
		/// 概况
		/// </summary>
		public string GeneralSituation
		{
			set{ _generalsituation=value;}
			get{return _generalsituation;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime UploadTime
		{
			set{ _uploadtime=value;}
			get{return _uploadtime;}
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

