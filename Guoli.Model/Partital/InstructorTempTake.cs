/**  版本信息模板在安装目录下，可自行修改。
* InstructorTempTake.cs
*
* 功 能： N/A
* 类 名： InstructorTempTake
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:04   N/A    初版
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
	/// 添乘信息单
	/// </summary>
	[Serializable]
	public partial class InstructorTempTake
	{
		public InstructorTempTake()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _takedate;
		private string _traincode;
		private string _locomotivetype;
		private int _driverid;
		private int _vicedriverid;
		private int _studentid;
		private int _carcount;
		private decimal _wholeweight;
		private decimal _length;
		private string _takesection;
		private DateTime _runstart;
		private DateTime _runend;
		private string _operatesection;
		private DateTime _operatestart;
		private DateTime _operateend;
		private DateTime _attendtime;
		private DateTime _endattendtime;
		private string _takeaims;
		private string _problems;
		private string _suggests;
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
		/// 指导司机Id
		/// </summary>
		public int InstructorId
		{
			set{ _instructorid=value;}
			get{return _instructorid;}
		}
		/// <summary>
		/// 添乘日期
		/// </summary>
		public DateTime TakeDate
		{
			set{ _takedate=value;}
			get{return _takedate;}
		}
		/// <summary>
		/// 添乘车次
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
		/// 主班司机
		/// </summary>
		public int DriverId
		{
			set{ _driverid=value;}
			get{return _driverid;}
		}
		/// <summary>
		/// 副司机Id
		/// </summary>
		public int ViceDriverId
		{
			set{ _vicedriverid=value;}
			get{return _vicedriverid;}
		}
		/// <summary>
		/// 学习司机Id
		/// </summary>
		public int StudentId
		{
			set{ _studentid=value;}
			get{return _studentid;}
		}
		/// <summary>
		/// 车辆数
		/// </summary>
		public int CarCount
		{
			set{ _carcount=value;}
			get{return _carcount;}
		}
		/// <summary>
		/// 总重
		/// </summary>
		public decimal WholeWeight
		{
			set{ _wholeweight=value;}
			get{return _wholeweight;}
		}
		/// <summary>
		/// 换长
		/// </summary>
		public decimal Length
		{
			set{ _length=value;}
			get{return _length;}
		}
		/// <summary>
		/// 添乘区段
		/// </summary>
		public string TakeSection
		{
			set{ _takesection=value;}
			get{return _takesection;}
		}
		/// <summary>
		/// 开车时间
		/// </summary>
		public DateTime RunStart
		{
			set{ _runstart=value;}
			get{return _runstart;}
		}
		/// <summary>
		/// 到达时间
		/// </summary>
		public DateTime RunEnd
		{
			set{ _runend=value;}
			get{return _runend;}
		}
		/// <summary>
		/// 操纵区间
		/// </summary>
		public string OperateSection
		{
			set{ _operatesection=value;}
			get{return _operatesection;}
		}
		/// <summary>
		/// 操纵开始时间
		/// </summary>
		public DateTime OperateStart
		{
			set{ _operatestart=value;}
			get{return _operatestart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime OperateEnd
		{
			set{ _operateend=value;}
			get{return _operateend;}
		}
		/// <summary>
		/// 出勤时间
		/// </summary>
		public DateTime AttendTime
		{
			set{ _attendtime=value;}
			get{return _attendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndAttendTime
		{
			set{ _endattendtime=value;}
			get{return _endattendtime;}
		}
		/// <summary>
		/// 添乘目的
		/// </summary>
		public string TakeAims
		{
			set{ _takeaims=value;}
			get{return _takeaims;}
		}
		/// <summary>
		/// 发现问题
		/// </summary>
		public string Problems
		{
			set{ _problems=value;}
			get{return _problems;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Suggests
		{
			set{ _suggests=value;}
			get{return _suggests;}
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

