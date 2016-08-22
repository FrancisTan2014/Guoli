/**  版本信息模板在安装目录下，可自行修改。
* ViewInstructorTempTake.cs
*
* 功 能： N/A
* 类 名： ViewInstructorTempTake
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/8 13:58:55   N/A    初版
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
	/// ViewInstructorTempTake:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewInstructorTempTake
	{
		public ViewInstructorTempTake()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _takedate;
		private string _traincode;
		private string _locomotivetype;
		private int _driverid;
		private string _drivername;
		private int _vicedriverid;
		private string _vicedrivername;
		private int _studentid;
		private string _studentname;
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
		private DateTime _uploadtime;
		private int _departmentid;
		private string _departmentname;
		private string _postname;
		private int _postid;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int InstructorId
		{
			set{ _instructorid=value;}
			get{return _instructorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime TakeDate
		{
			set{ _takedate=value;}
			get{return _takedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrainCode
		{
			set{ _traincode=value;}
			get{return _traincode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LocomotiveType
		{
			set{ _locomotivetype=value;}
			get{return _locomotivetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DriverId
		{
			set{ _driverid=value;}
			get{return _driverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DriverName
		{
			set{ _drivername=value;}
			get{return _drivername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ViceDriverId
		{
			set{ _vicedriverid=value;}
			get{return _vicedriverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ViceDriverName
		{
			set{ _vicedrivername=value;}
			get{return _vicedrivername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StudentId
		{
			set{ _studentid=value;}
			get{return _studentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentName
		{
			set{ _studentname=value;}
			get{return _studentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CarCount
		{
			set{ _carcount=value;}
			get{return _carcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal WholeWeight
		{
			set{ _wholeweight=value;}
			get{return _wholeweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Length
		{
			set{ _length=value;}
			get{return _length;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TakeSection
		{
			set{ _takesection=value;}
			get{return _takesection;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RunStart
		{
			set{ _runstart=value;}
			get{return _runstart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RunEnd
		{
			set{ _runend=value;}
			get{return _runend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OperateSection
		{
			set{ _operatesection=value;}
			get{return _operatesection;}
		}
		/// <summary>
		/// 
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
            set { _operateend = value; }
            get { return _operateend; }
	    }
		/// <summary>
		/// 
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
		/// 
		/// </summary>
		public string TakeAims
		{
			set{ _takeaims=value;}
			get{return _takeaims;}
		}
		/// <summary>
		/// 
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
		/// 
		/// </summary>
		public DateTime UploadTime
		{
			set{ _uploadtime=value;}
			get{return _uploadtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DepartmentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostName
		{
			set{ _postname=value;}
			get{return _postname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PostId
		{
			set{ _postid=value;}
			get{return _postid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

