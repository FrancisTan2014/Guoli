/**  版本信息模板在安装目录下，可自行修改。
* InstructorQuotaRecord.cs
*
* 功 能： N/A
* 类 名： InstructorQuotaRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:03   N/A    初版
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
	/// 指导司机指标完成情况
	/// </summary>
	[Serializable]
	public partial class InstructorQuotaRecord
	{
		public InstructorQuotaRecord()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private int _quotaid;
		private decimal _finishedammount;
        private int _year;
        private int _month;
		private DateTime _updatetime= DateTime.Now;
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
		/// 指标Id
		/// </summary>
		public int QuotaId
		{
			set{ _quotaid=value;}
			get{return _quotaid;}
		}
		/// <summary>
		/// 已完成数
		/// </summary>
		public decimal FinishedAmmount
		{
			set{ _finishedammount=value;}
			get{return _finishedammount;}
		}
        /// <summary>
        /// 年份
        /// </summary>
        public int Year
        {
            set { _year = value; }
            get { return _year; }
        }
        /// <summary>
        /// 月份
        /// </summary>
        public int Month
        {
            set { _month = value; }
            get { return _month; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
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

