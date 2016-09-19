/**  版本信息模板在安装目录下，可自行修改。
* InstructorQuota.cs
*
* 功 能： N/A
* 类 名： InstructorQuota
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
	/// 指导司机指标量化库
	/// </summary>
	[Serializable]
	public partial class InstructorQuota
	{
		public InstructorQuota()
		{}
		#region Model
		private int _id;
		private string _quotaname;
		private decimal _quataammount;
		private bool _needreview= false;
		private string _reviewdesc="";
		private decimal _basescore=0M;
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
		/// 指标名称
		/// </summary>
		public string QuotaName
		{
			set{ _quotaname=value;}
			get{return _quotaname;}
		}
		/// <summary>
		/// 指标量化数
		/// </summary>
		public decimal QuataAmmount
		{
			set{ _quataammount=value;}
			get{return _quataammount;}
		}
		/// <summary>
		/// 是否参与评分
		/// </summary>
		public bool NeedReview
		{
			set{ _needreview=value;}
			get{return _needreview;}
		}
		/// <summary>
		/// 评分描述
		/// </summary>
		public string ReviewDesc
		{
			set{ _reviewdesc=value;}
			get{return _reviewdesc;}
		}
		/// <summary>
		/// 基础分值
		/// </summary>
		public decimal BaseScore
		{
			set{ _basescore=value;}
			get{return _basescore;}
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

