/**  版本信息模板在安装目录下，可自行修改。
* ExamQuestion.cs
*
* 功 能： N/A
* 类 名： ExamQuestion
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/12 18:04:27   N/A    初版
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
	/// 考试试题表
	/// </summary>
	[Serializable]
	public partial class ExamQuestion
	{
		public ExamQuestion()
		{}
		#region Model
		private int _id;
		private int _examfileid;
		private string _question;
		private int _answertype;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 试题文件Id
		/// </summary>
		public int ExamFileId
		{
			set{ _examfileid=value;}
			get{return _examfileid;}
		}
		/// <summary>
		/// 试题内容
		/// </summary>
		public string Question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 答题类型（1 单选； 2 多选； 3 判断）
		/// </summary>
		public int AnswerType
		{
			set{ _answertype=value;}
			get{return _answertype;}
		}
		#endregion Model

	}
}

