/**  版本信息模板在安装目录下，可自行修改。
* ExamRecords.cs
*
* 功 能： N/A
* 类 名： ExamRecords
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:23   N/A    初版
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
	/// 人员考试记录表
	/// </summary>
	[Serializable]
	public partial class ExamRecords
	{
		public ExamRecords()
		{}
		#region Model
		private int _id;
		private int _examnotifyid;
		private int _persionid;
		private int _rightcount;
		private int _wrongcount;
		private int _score;
		private DateTime _examtime;
        private int _timespends;
        private DateTime _uploadtime;
        private bool _isdelete;
        /// <summary>
        /// 主键
        /// </summary>
        public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 考试通知Id
		/// </summary>
		public int ExamNotifyId
		{
			set{ _examnotifyid=value;}
			get{return _examnotifyid;}
		}
		/// <summary>
		/// 参加人员Id，关联人员信息表主键
		/// </summary>
		public int PersionId
		{
			set{ _persionid=value;}
			get{return _persionid;}
		}
		/// <summary>
		/// 正确题数
		/// </summary>
		public int RightCount
		{
			set{ _rightcount=value;}
			get{return _rightcount;}
		}
		/// <summary>
		/// 错误题数
		/// </summary>
		public int WrongCount
		{
			set{ _wrongcount=value;}
			get{return _wrongcount;}
		}
		/// <summary>
		/// 得分
		/// </summary>
		public int Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 考试时间
		/// </summary>
		public DateTime ExamTime
		{
			set{ _examtime=value;}
			get{return _examtime;}
		}
        /// <summary>
        /// 答题用时（单位：分）
        /// </summary>
        public int TimeSpends
        {
            set { _timespends = value; }
            get { return _timespends;}
        }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadTime
        {
            set { _uploadtime = value; }
            get { return _uploadtime; }
        }
        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

