/**  版本信息模板在安装目录下，可自行修改。
* ViewInstructorWifiRecord.cs
*
* 功 能： N/A
* 类 名： ViewInstructorWifiRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/28 11:28:58   N/A    初版
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
	/// ViewInstructorWifiRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewInstructorWifiRecord
	{
		public ViewInstructorWifiRecord()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private int _routerpositionid;
		private int _connectflag;
		private DateTime _connecttime;
		private bool _isdelete;
		private string _bssid;
		private string _location;
		private int? _departmentid;
		private string _departmentname;
		private string _name;
		private string _postname;
		private int? _postid;
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
		public int RouterPositionId
		{
			set{ _routerpositionid=value;}
			get{return _routerpositionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ConnectFlag
		{
			set{ _connectflag=value;}
			get{return _connectflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ConnectTime
		{
			set{ _connecttime=value;}
			get{return _connecttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BssId
		{
			set{ _bssid=value;}
			get{return _bssid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Location
		{
			set{ _location=value;}
			get{return _location;}
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		#endregion Model

	}
}

