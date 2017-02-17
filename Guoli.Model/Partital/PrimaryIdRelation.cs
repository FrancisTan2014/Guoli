/**  版本信息模板在安装目录下，可自行修改。
* PrimaryIdRelation.cs
*
* 功 能： N/A
* 类 名： PrimaryIdRelation
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
	/// Sqlserver与Oracle表的主键对应关系表
	/// </summary>
	[Serializable]
	public partial class PrimaryIdRelation
	{
		public PrimaryIdRelation()
		{}
		#region Model
		private int _id;
		private string _sqltablename;
		private string _sqlprimaryid;
		private string _oracletablename;
		private string _oracleprimaryid;
		private DateTime _addtime= DateTime.Now;
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
		/// Sqlserver表名
		/// </summary>
		public string SqlTableName
		{
			set{ _sqltablename=value;}
			get{return _sqltablename;}
		}
		/// <summary>
		/// Sqlserver主键
		/// </summary>
		public string SqlPrimaryId
		{
			set{ _sqlprimaryid=value;}
			get{return _sqlprimaryid;}
		}
		/// <summary>
		/// Oracle表名
		/// </summary>
		public string OracleTableName
		{
			set{ _oracletablename=value;}
			get{return _oracletablename;}
		}
		/// <summary>
		/// Oracle主键
		/// </summary>
		public string OraclePrimaryId
		{
			set{ _oracleprimaryid=value;}
			get{return _oracleprimaryid;}
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

