/**  版本信息模板在安装目录下，可自行修改。
* ViewInstructorKeyPerson.cs
*
* 功 能： N/A
* 类 名： ViewInstructorKeyPerson
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
	/// ViewInstructorKeyPerson:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewInstructorKeyPerson
	{
		public ViewInstructorKeyPerson()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _confirmdate;
		private int _keypersonid;
		private string _keypersonname;
		private DateTime _expectremovetime;
		private DateTime _actualremovetime;
		private string _keylocation;
		private string _personconfirmreason;
		private string _helpmethod;
	    private string _changes;
		private string _personremovesuggests;
		private string _locationconfirmreason;
		private string _controlmethod;
		private string _actualcontrol;
		private string _locationremovesuggests;
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
		public DateTime ConfirmDate
		{
			set{ _confirmdate=value;}
			get{return _confirmdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int KeyPersonId
		{
			set{ _keypersonid=value;}
			get{return _keypersonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyPersonName
		{
			set{ _keypersonname=value;}
			get{return _keypersonname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ExpectRemoveTime
		{
			set{ _expectremovetime=value;}
			get{return _expectremovetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ActualRemoveTime
		{
			set{ _actualremovetime=value;}
			get{return _actualremovetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyLocation
		{
			set{ _keylocation=value;}
			get{return _keylocation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PersonConfirmReason
		{
			set{ _personconfirmreason=value;}
			get{return _personconfirmreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HelpMethod
		{
			set{ _helpmethod=value;}
			get{return _helpmethod;}
		}
        /// <summary>
        /// 转变情况
        /// </summary>
        public string Changes
        {
            set { _changes = value; }
            get { return _changes; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string PersonRemoveSuggests
		{
			set{ _personremovesuggests=value;}
			get{return _personremovesuggests;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LocationConfirmReason
		{
			set{ _locationconfirmreason=value;}
			get{return _locationconfirmreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ControlMethod
		{
			set{ _controlmethod=value;}
			get{return _controlmethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActualControl
		{
			set{ _actualcontrol=value;}
			get{return _actualcontrol;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LocationRemoveSuggests
		{
			set{ _locationremovesuggests=value;}
			get{return _locationremovesuggests;}
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

