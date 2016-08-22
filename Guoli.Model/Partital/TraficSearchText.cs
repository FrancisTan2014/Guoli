/**  版本信息模板在安装目录下，可自行修改。
* TraficSearchText.cs
*
* 功 能： N/A
* 类 名： TraficSearchText
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
	/// 搜索结果文本内容
	/// </summary>
	[Serializable]
	public partial class TraficSearchText
	{
		public TraficSearchText()
		{}
		#region Model
		private int _id;
		private int _fileid;
		private string _chapter;
		private string _item;
		private string _content;
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
		/// 所在文件Id
		/// </summary>
		public int FileId
		{
			set{ _fileid=value;}
			get{return _fileid;}
		}
		/// <summary>
		/// 章节，如第三章
		/// </summary>
		public string Chapter
		{
			set{ _chapter=value;}
			get{return _chapter;}
		}
		/// <summary>
		/// 条目，如第229条
		/// </summary>
		public string Item
		{
			set{ _item=value;}
			get{return _item;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
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

