/**  版本信息模板在安装目录下，可自行修改。
* PersonInfo.cs
*
* 功 能： N/A
* 类 名： PersonInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:25   N/A    初版
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
	/// 描述机务段人员信息
	/// </summary>
	[Serializable]
	public partial class PersonInfo
	{
		public PersonInfo()
		{}
		#region Model
		private long _id;
		private string _personid="0";
		private string _workno;
		private int _departmentid;
		private string _name;
		private string _spell="";
		private DateTime _birthdate;
		private int _sex=1;
		private int _postid;
		private string _photopath="";
		private string _identityno="";
		private string _password="";
		private bool _isdelete;
		/// <summary>
		/// 主键
		/// </summary>
		public long Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 人员ID，关联运安数据库人员表Id（有可能获取不到此Id，则此时本字段值为0）
		/// </summary>
		public string PersonId
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 工号，绝大多数情况下可用此字段作为人员的唯一标识
		/// </summary>
		public string WorkNo
		{
			set{ _workno=value;}
			get{return _workno;}
		}
		/// <summary>
		/// 部门Id，关联部门信息表主键
		/// </summary>
		public int DepartmentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 拼音简写
		/// </summary>
		public string Spell
		{
			set{ _spell=value;}
			get{return _spell;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime BirthDate
		{
			set{ _birthdate=value;}
			get{return _birthdate;}
		}
		/// <summary>
		/// 性别（1 表示男；2 表示女；3 表示未知）
		/// </summary>
		public int Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 岗位Id，关联岗位信息表主键
		/// </summary>
		public int PostId
		{
			set{ _postid=value;}
			get{return _postid;}
		}
		/// <summary>
		/// 照片路径
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string IdentityNo
		{
			set{ _identityno=value;}
			get{return _identityno;}
		}
		/// <summary>
		/// 各种系统统一密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

