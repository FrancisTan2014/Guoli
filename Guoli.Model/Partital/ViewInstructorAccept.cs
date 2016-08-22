/**  版本信息模板在安装目录下，可自行修改。
* ViewInstructorAccept.cs
*
* 功 能： N/A
* 类 名： ViewInstructorAccept
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/9 15:52:44   N/A    初版
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
	/// 标准化验收
	/// </summary>
	[Serializable]
	public partial class ViewInstructorAccept
	{
		public ViewInstructorAccept()
		{}
		#region Model
		private int _id;
	    private DateTime _acceptdate;
		private int _instructorid;
		private int _driverid;
		private string _drivername;
		private int _vicedriverid;
		private string _vicedrivername;
		private decimal _driverscore;
		private decimal _vicedriverscore;
		private string _problems;
		private string _suggests;
		private DateTime _uploadtime;
		private int? _departmentid;
		private string _departmentname;
		private string _postname;
		private int? _postid;
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
        /// 验收日期
        /// </summary>
        public DateTime AcceptDate
        {
            set { _acceptdate = value; }
            get { return _acceptdate; }
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
		public decimal DriverScore
		{
			set{ _driverscore=value;}
			get{return _driverscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ViceDriverScore
		{
			set{ _vicedriverscore=value;}
			get{return _vicedriverscore;}
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
		public int? DepartmentId
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
		public int? PostId
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

