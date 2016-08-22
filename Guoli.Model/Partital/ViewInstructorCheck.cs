/**  版本信息模板在安装目录下，可自行修改。
* ViewInstructorCheck.cs
*
* 功 能： N/A
* 类 名： ViewInstructorCheck
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/8 13:58:57   N/A    初版
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
	/// ViewInstructorCheck:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewInstructorCheck
	{
		public ViewInstructorCheck()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _starttime;
		private DateTime _endtime;
		private string _location;
		private string _checktype;
		private int _problemcount;
		private string _checkcontent;
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
		public DateTime StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
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
		public string CheckType
		{
			set{ _checktype=value;}
			get{return _checktype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProblemCount
		{
			set{ _problemcount=value;}
			get{return _problemcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckContent
		{
			set{ _checkcontent=value;}
			get{return _checkcontent;}
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

