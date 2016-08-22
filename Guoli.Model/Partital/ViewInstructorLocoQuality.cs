/**  版本信息模板在安装目录下，可自行修改。
* ViewInstructorLocoQuality.cs
*
* 功 能： N/A
* 类 名： ViewInstructorLocoQuality
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/8 13:58:56   N/A    初版
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
	/// ViewInstructorLocoQuality:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewInstructorLocoQuality
	{
		public ViewInstructorLocoQuality()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _registdate;
		private string _traincode;
		private string _locomotivetype;
		private int _driverid;
		private string _drivername;
		private string _repairclass;
		private string _maintenancestatus;
	    private decimal _score;
		private string _faultlocation;
		private string _generalsituation;
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
		public DateTime RegistDate
		{
			set{ _registdate=value;}
			get{return _registdate;}
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
		public string RepairClass
		{
			set{ _repairclass=value;}
			get{return _repairclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaintenanceStatus
		{
			set{ _maintenancestatus=value;}
			get{return _maintenancestatus;}
		}/// <summary>
        /// 评定成功
        /// </summary>
        public decimal Score
        {
            set { _score = value; }
            get { return _score; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string FaultLocation
		{
			set{ _faultlocation=value;}
			get{return _faultlocation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GeneralSituation
		{
			set{ _generalsituation=value;}
			get{return _generalsituation;}
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

