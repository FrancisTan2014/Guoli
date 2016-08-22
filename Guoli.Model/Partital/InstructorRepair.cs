/**  版本信息模板在安装目录下，可自行修改。
* InstructorRepair.cs
*
* 功 能： N/A
* 类 名： InstructorRepair
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:03   N/A    初版
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
	/// 机破临修记录
	/// </summary>
	[Serializable]
	public partial class InstructorRepair
	{
		public InstructorRepair()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _happentime;
		private string _location;
		private string _traincode;
		private string _locomotivetype;
		private int _driverid;
		private int _vicedriverid;
		private int _studentid;
		private string _faultlocation;
		private string _faultreason;
		private string _responsibility;
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
		/// 机破发生时间
		/// </summary>
		public DateTime HappenTime
		{
			set{ _happentime=value;}
			get{return _happentime;}
		}
		/// <summary>
		/// 发生地点
		/// </summary>
		public string Location
		{
			set{ _location=value;}
			get{return _location;}
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
		/// 副司机Id，关联乘务员信息表主键
   
		/// </summary>
		public int ViceDriverId
		{
			set{ _vicedriverid=value;}
			get{return _vicedriverid;}
		}
		/// <summary>
		/// 学习司机Id，关联乘务员信息表主键
		/// </summary>
		public int StudentId
		{
			set{ _studentid=value;}
			get{return _studentid;}
		}
		/// <summary>
		/// 故障处所
		/// </summary>
		public string FaultLocation
		{
			set{ _faultlocation=value;}
			get{return _faultlocation;}
		}
		/// <summary>
		/// 故障原因
		/// </summary>
		public string FaultReason
		{
			set{ _faultreason=value;}
			get{return _faultreason;}
		}
		/// <summary>
		/// 责任
		/// </summary>
		public string Responsibility
		{
			set{ _responsibility=value;}
			get{return _responsibility;}
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

