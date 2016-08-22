/**  版本信息模板在安装目录下，可自行修改。
* DbUpdateLog.cs
*
* 功 能： N/A
* 类 名： DbUpdateLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:17   N/A    初版
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
	/// 数据库更新记录表
	/// </summary>
	[Serializable]
	public partial class DbUpdateLog
	{
		public DbUpdateLog()
		{}
		#region Model
		private int _id;
		private string _tablename;
		private int _updatetype;
		private int _targetid;
		private DateTime _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 更新的表格名称
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 更新类型（1 Insert； 2 Update； 3 Delete）
		/// </summary>
		public int UpdateType
		{
			set{ _updatetype=value;}
			get{return _updatetype;}
		}
		/// <summary>
		/// 目录数据主键
		/// </summary>
		public int TargetId
		{
			set{ _targetid=value;}
			get{return _targetid;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

