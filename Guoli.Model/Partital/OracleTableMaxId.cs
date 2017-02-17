/**  版本信息模板在安装目录下，可自行修改。
* OracleTableMaxId.cs
*
* 功 能： N/A
* 类 名： OracleTableMaxId
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/10 9:54:29   N/A    初版
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
	/// Oracle数据库表的最大Id记录
	/// </summary>
	[Serializable]
	public partial class OracleTableMaxId
	{
		public OracleTableMaxId()
		{}
		#region Model
		private int _id;
		private string _tablename;
		private string _maxid;
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
		/// 表名
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaxId
		{
			set{ _maxid=value;}
			get{return _maxid;}
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

