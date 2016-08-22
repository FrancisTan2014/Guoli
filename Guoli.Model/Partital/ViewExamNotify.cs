/**  版本信息模板在安装目录下，可自行修改。
* ViewExamNotify.cs
*
* 功 能： N/A
* 类 名： ViewExamNotify
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/16 14:37:52   N/A    初版
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
	/// ViewExamNotify:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewExamNotify
	{
		public ViewExamNotify()
		{}
		#region Model
		private int _id;
		private int _postid;
		private string _postname;
		private string _examname;
		private int _examfilesid;
		private string _filename;
		private int _questioncount;
		private int _passscore;
		private int _resitcount;
		private DateTime _endtime;
		private int _timelimit;
		private DateTime _addtime;
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
		public string ExamName
		{
			set{ _examname=value;}
			get{return _examname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ExamFilesId
		{
			set{ _examfilesid=value;}
			get{return _examfilesid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int QuestionCount
		{
			set{ _questioncount=value;}
			get{return _questioncount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PassScore
		{
			set{ _passscore=value;}
			get{return _passscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ResitCount
		{
			set{ _resitcount=value;}
			get{return _resitcount;}
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
		public int TimeLimit
		{
			set{ _timelimit=value;}
			get{return _timelimit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

