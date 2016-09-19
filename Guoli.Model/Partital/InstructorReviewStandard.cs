/**  版本信息模板在安装目录下，可自行修改。
* InstructorReviewStandard.cs
*
* 功 能： N/A
* 类 名： InstructorReviewStandard
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/18 8:51:32   N/A    初版
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
	/// 指导司机评分标准
	/// </summary>
	[Serializable]
	public partial class InstructorReviewStandard
	{
		public InstructorReviewStandard()
		{}
		#region Model
		private int _id;
		private int _instructorquotaid;
		private decimal _conditionammount;
		private decimal _extrascore;
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
		/// 
		/// </summary>
		public int InstructorQuotaId
		{
			set{ _instructorquotaid=value;}
			get{return _instructorquotaid;}
		}
		/// <summary>
		/// 达标数值
		/// </summary>
		public decimal ConditionAmmount
		{
			set{ _conditionammount=value;}
			get{return _conditionammount;}
		}
		/// <summary>
		/// 加减分值（在基础分值的基础上加減）
		/// </summary>
		public decimal ExtraScore
		{
			set{ _extrascore=value;}
			get{return _extrascore;}
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

