/**  版本信息模板在安装目录下，可自行修改。
* Announcement.cs
*
* 功 能： N/A
* 类 名： Announcement
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:15   N/A    初版
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
	/// 公告信息表
	/// </summary>
	[Serializable]
	public partial class Announcement
	{
		public Announcement()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private int _systemuserid;
		private DateTime _pubtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 公告标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 公告信息
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 管理员Id
		/// </summary>
		public int SystemUserId
		{
			set{ _systemuserid=value;}
			get{return _systemuserid;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime PubTime
		{
			set{ _pubtime=value;}
			get{return _pubtime;}
		}
		#endregion Model

	}
}

