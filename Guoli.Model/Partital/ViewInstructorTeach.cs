/**  版本信息模板在安装目录下，可自行修改。
* ViewInstructorTeach.cs
*
* 功 能： N/A
* 类 名： ViewInstructorTeach
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
	/// ViewInstructorTeach:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewInstructorTeach
	{
		public ViewInstructorTeach()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private string _teachplace;
		private int _joincount;
		private DateTime _teachstart;
		private DateTime _teachend;
		private string _teachcontent;
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
		public string TeachPlace
		{
			set{ _teachplace=value;}
			get{return _teachplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int JoinCount
		{
			set{ _joincount=value;}
			get{return _joincount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime TeachStart
		{
			set{ _teachstart=value;}
			get{return _teachstart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime TeachEnd
		{
			set{ _teachend=value;}
			get{return _teachend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeachContent
		{
			set{ _teachcontent=value;}
			get{return _teachcontent;}
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

