/**  版本信息模板在安装目录下，可自行修改。
* ViewPersonInfo.cs
*
* 功 能： N/A
* 类 名： ViewPersonInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/3 18:10:41   N/A    初版
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
	/// ViewPersonInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewPersonInfo
	{
		public ViewPersonInfo()
		{}
		#region Model
		private long _id;
		private string _personid;
		private string _workno;
		private int _departmentid;
		private string _departmentname;
		private string _name;
		private string _spell;
		private DateTime _birthdate;
		private int _sex;
		private int _postid;
		private string _postname;
		private string _photopath;
		private string _identityno;
	    private DateTime _updatetime;
		private string _password;
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PersonId
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkNo
		{
			set{ _workno=value;}
			get{return _workno;}
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spell
		{
			set{ _spell=value;}
			get{return _spell;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime BirthDate
		{
			set{ _birthdate=value;}
			get{return _birthdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Sex
		{
			set{ _sex=value;}
			get{return _sex;}
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
		public string PostName
		{
			set{ _postname=value;}
			get{return _postname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IdentityNo
		{
			set{ _identityno=value;}
			get{return _identityno;}
		}

	    public DateTime UpdateTime
	    {
            set { _updatetime = value; }
            get { return _updatetime; }
	    }
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		#endregion Model

	}
}

