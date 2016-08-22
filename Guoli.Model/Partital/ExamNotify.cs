/**  版本信息模板在安装目录下，可自行修改。
* ExamNotify.cs
*
* 功 能： N/A
* 类 名： ExamNotify
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/10 10:57:50   N/A    初版
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
	/// 考试通知表
	/// </summary>
	[Serializable]
	public partial class ExamNotify
	{
		public ExamNotify()
		{}
		#region Model
		private int _id;
		private int _postid;
		private string _examname;
		private int _examfilesid;
		private int _questioncount;
		private int _passscore;
		private int _resitcount;
		private DateTime _endtime;
        private int _timelimit;
		private DateTime _addtime= DateTime.Now;
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
		/// 需要参加人员的岗位Id，关联岗位信息表的主键
		/// </summary>
		public int PostId
		{
			set{ _postid=value;}
			get{return _postid;}
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
		/// 考试分类Id，试题范围
		/// </summary>
		public int ExamFilesId
		{
			set{ _examfilesid = value;}
			get{return _examfilesid; }
		}
		/// <summary>
		/// 试题总数
		/// </summary>
		public int QuestionCount
		{
			set{ _questioncount=value;}
			get{return _questioncount;}
		}
		/// <summary>
		/// 考试通过分数
		/// </summary>
		public int PassScore
		{
			set{ _passscore=value;}
			get{return _passscore;}
		}
		/// <summary>
		/// 允许补考次数
		/// </summary>
		public int ResitCount
		{
			set{ _resitcount=value;}
			get{return _resitcount;}
		}
		/// <summary>
		/// 考试截止日期
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
        /// <summary>
        /// 考试时长（单位：分）
        /// </summary>
        public int TimeLimit
        {
            set { _timelimit = value; }
            get { return _timelimit; }
        }
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
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

