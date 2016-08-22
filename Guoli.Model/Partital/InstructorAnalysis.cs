/**  版本信息模板在安装目录下，可自行修改。
* InstructorAnalysis.cs
*
* 功 能： N/A
* 类 名： InstructorAnalysis
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:00   N/A    初版
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
	/// 监控分析单
	/// </summary>
	[Serializable]
	public partial class InstructorAnalysis
	{
		public InstructorAnalysis()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private string _traincode;
		private string _locomotivetype;
		private DateTime _rundate;
		private string _runsection;
		private int _driverid;
		private int _vicedriverid;
		private DateTime _analysisstart;
		private DateTime _analysisend;
		private string _problems="";
		private string _suggests="";
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
		/// 指导司机Id，关联乘务员信息表主键
		/// </summary>
		public int InstructorId
		{
			set{ _instructorid=value;}
			get{return _instructorid;}
		}
		/// <summary>
		/// 分析车次
		/// </summary>
		public string TrainCode
		{
			set{ _traincode=value;}
			get{return _traincode;}
		}
		/// <summary>
		/// 机车型号
		/// </summary>
		public string LocomotiveType
		{
			set{ _locomotivetype=value;}
			get{return _locomotivetype;}
		}
		/// <summary>
		/// 列车运行日期
		/// </summary>
		public DateTime RunDate
		{
			set{ _rundate=value;}
			get{return _rundate;}
		}
		/// <summary>
		/// 列车运行区段
		/// </summary>
		public string RunSection
		{
			set{ _runsection=value;}
			get{return _runsection;}
		}
		/// <summary>
		/// 主班司机Id，关联乘务员信息表主键
		/// </summary>
		public int DriverId
		{
			set{ _driverid=value;}
			get{return _driverid;}
		}
		/// <summary>
		/// 副司机Id，关联乘务员信息表主键
		/// </summary>
		public int ViceDriverId
		{
			set{ _vicedriverid=value;}
			get{return _vicedriverid;}
		}
		/// <summary>
		/// 分析开始时间
		/// </summary>
		public DateTime AnalysisStart
		{
			set{ _analysisstart=value;}
			get{return _analysisstart;}
		}
		/// <summary>
		/// 分析结束时间
		/// </summary>
		public DateTime AnalysisEnd
		{
			set{ _analysisend=value;}
			get{return _analysisend;}
		}
		/// <summary>
		/// 发现问题
		/// </summary>
		public string Problems
		{
			set{ _problems=value;}
			get{return _problems;}
		}
		/// <summary>
		/// 指导意见
		/// </summary>
		public string Suggests
		{
			set{ _suggests=value;}
			get{return _suggests;}
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

