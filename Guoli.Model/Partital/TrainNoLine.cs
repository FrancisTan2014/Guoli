﻿/**  版本信息模板在安装目录下，可自行修改。
* TrainNoLine.cs
*
* 功 能： N/A
* 类 名： TrainNoLine
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/31 18:58:18   N/A    初版
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
	/// 车次与线路关联表，车次与线路为多对多的关系
	/// </summary>
	[Serializable]
	public partial class TrainNoLine
	{
		public TrainNoLine()
		{}
		#region Model
		private int _id;
		private int _trainnoid;
		private int _lineid;
		private int _sort;
		private DateTime _updatetime= DateTime.Now;
		private bool _isdelete= false;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 车次Id
		/// </summary>
		public int TrainNoId
		{
			set{ _trainnoid=value;}
			get{return _trainnoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LineId
		{
			set{ _lineid=value;}
			get{return _lineid;}
		}
		/// <summary>
        /// 编号，它代表了车次经过线路的顺序
		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
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

