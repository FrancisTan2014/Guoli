/**  版本信息模板在安装目录下，可自行修改。
* InstructorPlan.cs
*
* 功 能： N/A
* 类 名： InstructorPlan
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:02   N/A    初版
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
	/// 工作总结及计划
	/// </summary>
	[Serializable]
	public partial class InstructorPlan
	{
		public InstructorPlan()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _writedate;
		private string _worksummary;
		private string _problems;
		private string _workplans;
		private DateTime _uploadtime= DateTime.Now;
		private bool _isdelete= false;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 指导司机Id
		/// </summary>
		public int InstructorId
		{
			set{ _instructorid=value;}
			get{return _instructorid;}
		}
		/// <summary>
		/// 填写日期
		/// </summary>
		public DateTime WriteDate
		{
			set{ _writedate=value;}
			get{return _writedate;}
		}
		/// <summary>
		/// 本月工作完成情况
		/// </summary>
		public string WorkSummary
		{
			set{ _worksummary=value;}
			get{return _worksummary;}
		}
		/// <summary>
		/// 存在问题分析
		/// </summary>
		public string Problems
		{
			set{ _problems=value;}
			get{return _problems;}
		}
		/// <summary>
		/// 下月工作计划
		/// </summary>
		public string WorkPlans
		{
			set{ _workplans=value;}
			get{return _workplans;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime UploadTime
		{
			set{ _uploadtime=value;}
			get{return _uploadtime;}
		}
		/// <summary>
		/// 删除标识
		/// </summary>
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

