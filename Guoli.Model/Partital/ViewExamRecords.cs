/**  版本信息模板在安装目录下，可自行修改。
* ViewExamRecords.cs
*
* 功 能： N/A
* 类 名： ViewExamRecords
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/17 15:09:08   N/A    初版
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
	/// ViewExamRecords:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewExamRecords
	{
		public ViewExamRecords()
		{}
		#region Model
		private int _examnotifyid;
		private string _examname;
		private int _persionid;
		private string _name;
        private int _departmentid;
		private string _departmentname;
        private int _postid;
		private string _postname;
		private int _passscore;
		private int _maxscore;
		private string _passed;
        private DateTime _notifyaddtime;
		/// <summary>
		/// 
		/// </summary>
		public int ExamNotifyId
		{
			set{ _examnotifyid=value;}
			get{return _examnotifyid;}
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
		public int PersionId
		{
			set{ _persionid=value;}
			get{return _persionid;}
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
        public int DepartmentId
        {
            set { _departmentid = value; }
            get { return _departmentid; }
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
        public int PostId
        {
            set { _postid = value; }
            get { return _postid; }
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
		public int PassScore
		{
			set{ _passscore=value;}
			get{return _passscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MaxScore
		{
			set{ _maxscore=value;}
			get{return _maxscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Passed
		{
			set{ _passed=value;}
			get{return _passed;}
		}
        /// <summary>
        /// 
        /// </summary>
        public DateTime NotifyAddTime
        {
            set { _notifyaddtime = value; }
            get { return _notifyaddtime; }
        }
        #endregion Model

    }
}

