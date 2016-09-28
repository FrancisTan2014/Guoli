/**  版本信息模板在安装目录下，可自行修改。
* ViewInstructorReviewScore.cs
*
* 功 能： N/A
* 类 名： ViewInstructorReviewScore
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/21 13:03:33   N/A    初版
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
	/// ViewInstructorReviewScore:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewInstructorReviewScore
	{
		public ViewInstructorReviewScore()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private int _month;
		private int _year;
		private decimal _score;
		private DateTime _updatetime;
		private int? _departmentid;
		private string _departmentname;
		private int? _postid;
		private string _postname;
		private string _name;
		private string _workno;
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
		public int Month
		{
			set{ _month=value;}
			get{return _month;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Year
		{
			set{ _year=value;}
			get{return _year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
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
		public int? PostId
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkNo
		{
			set{ _workno=value;}
			get{return _workno;}
		}
		#endregion Model

	}
}

