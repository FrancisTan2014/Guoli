/**  版本信息模板在安装目录下，可自行修改。
* TraficSearchResult.cs
*
* 功 能： N/A
* 类 名： TraficSearchResult
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/4 10:10:50   N/A    初版
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
	/// 关键字搜索结果表
	/// </summary>
	[Serializable]
	public partial class TraficSearchResult
	{
		public TraficSearchResult()
		{}
		#region Model
		private int _id;
		private int _keywordsid;
		private int _traficsearchtextid;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 关键字Id
		/// </summary>
		public int KeywordsId
		{
			set{ _keywordsid=value;}
			get{return _keywordsid;}
		}
		/// <summary>
		/// 搜索结果内容Id，关联TraficSearchText表主键
		/// </summary>
		public int TraficSearchTextId
		{
			set{ _traficsearchtextid=value;}
			get{return _traficsearchtextid;}
		}
		#endregion Model

	}
}

