/**  版本信息模板在安装目录下，可自行修改。
* DrivePlan.cs
*
* 功 能： N/A
* 类 名： DrivePlan
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:18   N/A    初版
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
	/// 行车计划表
	/// </summary>
	[Serializable]
	public partial class DrivePlan
	{
		public DrivePlan()
		{}
		#region Model
		private int _id;
		private string _linename;
		private string _traincode;
		private string _locotype="";
		private string _driverno;
		private string _drivername;
		private string _vicedriverno;
		private string _vicedrivername;
		private string _studentno="";
		private string _studentname="";
		private string _otherno1="";
		private string _othername1;
		private string _otherno2="";
		private string _othername2="";
		private DateTime _attendtime;
		private DateTime _starttime;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 线路名称
		/// </summary>
		public string LineName
		{
			set{ _linename=value;}
			get{return _linename;}
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
		public string LocoType
		{
			set{ _locotype=value;}
			get{return _locotype;}
		}
		/// <summary>
		/// 司机工号
		/// </summary>
		public string DriverNo
		{
			set{ _driverno=value;}
			get{return _driverno;}
		}
		/// <summary>
		/// 司机姓名
		/// </summary>
		public string DriverName
		{
			set{ _drivername=value;}
			get{return _drivername;}
		}
		/// <summary>
		/// 副司机工号
		/// </summary>
		public string ViceDriverNo
		{
			set{ _vicedriverno=value;}
			get{return _vicedriverno;}
		}
		/// <summary>
		/// 副司机姓名
		/// </summary>
		public string ViceDriverName
		{
			set{ _vicedrivername=value;}
			get{return _vicedrivername;}
		}
		/// <summary>
		/// 学员工号
		/// </summary>
		public string StudentNo
		{
			set{ _studentno=value;}
			get{return _studentno;}
		}
		/// <summary>
		/// 学员姓名
		/// </summary>
		public string StudentName
		{
			set{ _studentname=value;}
			get{return _studentname;}
		}
		/// <summary>
		/// 其他人员工号1
		/// </summary>
		public string OtherNo1
		{
			set{ _otherno1=value;}
			get{return _otherno1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherName1
		{
			set{ _othername1=value;}
			get{return _othername1;}
		}
		/// <summary>
		/// 其他人员工号2
		/// </summary>
		public string OtherNo2
		{
			set{ _otherno2=value;}
			get{return _otherno2;}
		}
		/// <summary>
		/// 其他人员姓名2
		/// </summary>
		public string OtherName2
		{
			set{ _othername2=value;}
			get{return _othername2;}
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
		/// 开车时间
		/// </summary>
		public DateTime StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		#endregion Model

	}
}

