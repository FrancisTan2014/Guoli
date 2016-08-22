/**  版本信息模板在安装目录下，可自行修改。
* ExamErrorQuestions.cs
*
* 功 能： N/A
* 类 名： ExamErrorQuestions
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:21   N/A    初版
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
	/// 我的错题
	/// </summary>
	[Serializable]
	public partial class ExamErrorQuestions
	{
		public ExamErrorQuestions()
		{}
		#region Model
		private int _id;
		private int _persionid;
		private int _questionid;
		private int _errorcount;
		private bool _hasremembered;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 人员Id，关联人员信息表主键
		/// </summary>
		public int PersionId
		{
			set{ _persionid=value;}
			get{return _persionid;}
		}
		/// <summary>
		/// 试题Id，关联试题表主键
		/// </summary>
		public int QuestionId
		{
			set{ _questionid=value;}
			get{return _questionid;}
		}
		/// <summary>
		/// 错误次数
		/// </summary>
		public int ErrorCount
		{
			set{ _errorcount=value;}
			get{return _errorcount;}
		}
		/// <summary>
		/// 是否记住
		/// </summary>
		public bool HasRemembered
		{
			set{ _hasremembered=value;}
			get{return _hasremembered;}
		}
		#endregion Model

	}
}

