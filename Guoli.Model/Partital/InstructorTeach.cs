/**  版本信息模板在安装目录下，可自行修改。
* InstructorTeach.cs
*
* 功 能： N/A
* 类 名： InstructorTeach
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:04   N/A    初版
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
	/// 授课培训记录
	/// </summary>
	[Serializable]
	public partial class InstructorTeach
	{
		public InstructorTeach()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private string _teachplace;
		private int _joincount;
		private DateTime _teachstart;
		private DateTime _teachend;
		private string _teachcontent;
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
		/// 授课地点
		/// </summary>
		public string TeachPlace
		{
			set{ _teachplace=value;}
			get{return _teachplace;}
		}
		/// <summary>
		/// 参与人数
		/// </summary>
		public int JoinCount
		{
			set{ _joincount=value;}
			get{return _joincount;}
		}
		/// <summary>
		/// 授课开始时间
		/// </summary>
		public DateTime TeachStart
		{
			set{ _teachstart=value;}
			get{return _teachstart;}
		}
		/// <summary>
		/// 授课结束时间
		/// </summary>
		public DateTime TeachEnd
		{
			set{ _teachend=value;}
			get{return _teachend;}
		}
		/// <summary>
		/// 授课内容
		/// </summary>
		public string TeachContent
		{
			set{ _teachcontent=value;}
			get{return _teachcontent;}
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

