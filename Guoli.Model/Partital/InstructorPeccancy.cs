﻿/**  版本信息模板在安装目录下，可自行修改。
* InstructorPeccancy.cs
*
* 功 能： N/A
* 类 名： InstructorPeccancy
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:02   N/A    初版
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
	/// 违章违纪记录
	/// </summary>
	[Serializable]
	public partial class InstructorPeccancy
	{
		public InstructorPeccancy()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _writedate;
		private int _driverid;
		private string _peccancytype;
		private string _generalsituation;
		private string _analysis;
		private string _suggests;
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
		/// 指导司机Id
		/// </summary>
		public int InstructorId
		{
			set{ _instructorid=value;}
			get{return _instructorid;}
		}
		/// <summary>
		/// 记录日期
		/// </summary>
		public DateTime WriteDate
		{
			set{ _writedate=value;}
			get{return _writedate;}
		}
		/// <summary>
		/// 违章司机Id
		/// </summary>
		public int DriverId
		{
			set{ _driverid=value;}
			get{return _driverid;}
		}
		/// <summary>
		/// 违章性质
		/// </summary>
		public string PeccancyType
		{
			set{ _peccancytype=value;}
			get{return _peccancytype;}
		}
		/// <summary>
		/// 概况
		/// </summary>
		public string GeneralSituation
		{
			set{ _generalsituation=value;}
			get{return _generalsituation;}
		}
		/// <summary>
		/// 分析情况
		/// </summary>
		public string Analysis
		{
			set{ _analysis=value;}
			get{return _analysis;}
		}
		/// <summary>
		/// 处理意见
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
		/// 
		/// </summary>
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

