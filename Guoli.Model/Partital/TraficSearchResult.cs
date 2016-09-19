/**  版本信息模板在安装目录下，可自行修改。
* TraficSearchResult.cs
*
* 功 能： N/A
* 类 名： TraficSearchResult
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/18 23:07:12   N/A    初版
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
		private string _searchresult;
		private int _traficfileid;
		private string _position;
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
		/// 搜索结果
		/// </summary>
		public string SearchResult
		{
			set{ _searchresult=value;}
			get{return _searchresult;}
		}
		/// <summary>
		/// 所在文件Id
		/// </summary>
		public int TraficFileId
		{
			set{ _traficfileid=value;}
			get{return _traficfileid;}
		}
		/// <summary>
		/// 搜索结果所在位置（如：关键字所在dom元素的Id）
		/// </summary>
		public string Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		#endregion Model

	}
}

