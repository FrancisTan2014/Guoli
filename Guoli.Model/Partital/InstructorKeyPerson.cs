/**  版本信息模板在安装目录下，可自行修改。
* InstructorKeyPerson.cs
*
* 功 能： N/A
* 类 名： InstructorKeyPerson
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:01   N/A    初版
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
	/// 关键人记录
	/// </summary>
	[Serializable]
	public partial class InstructorKeyPerson
	{
		public InstructorKeyPerson()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _confirmdate;
		private int _keypersonid;
		private DateTime _expectremovetime;
		private DateTime _actualremovetime= Convert.ToDateTime("1900-01-01");
		private string _keylocation;
		private string _personconfirmreason="";
		private string _helpmethod="";
	    private string _changes = "";
		private string _personremovesuggests="";
		private string _locationconfirmreason="";
		private string _controlmethod="";
		private string _actualcontrol="";
		private string _locationremovesuggests="";
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
		/// 确定日期
		/// </summary>
		public DateTime ConfirmDate
		{
			set{ _confirmdate=value;}
			get{return _confirmdate;}
		}
		/// <summary>
		/// 关键人Id
		/// </summary>
		public int KeyPersonId
		{
			set{ _keypersonid=value;}
			get{return _keypersonid;}
		}
		/// <summary>
		/// 预计解除日期
		/// </summary>
		public DateTime ExpectRemoveTime
		{
			set{ _expectremovetime=value;}
			get{return _expectremovetime;}
		}
		/// <summary>
		/// 实际解除日期
		/// </summary>
		public DateTime ActualRemoveTime
		{
			set{ _actualremovetime=value;}
			get{return _actualremovetime;}
		}
		/// <summary>
		/// 关键点（关键部位，关键站）
		/// </summary>
		public string KeyLocation
		{
			set{ _keylocation=value;}
			get{return _keylocation;}
		}
		/// <summary>
		/// 关键人确定原因
		/// </summary>
		public string PersonConfirmReason
		{
			set{ _personconfirmreason=value;}
			get{return _personconfirmreason;}
		}
		/// <summary>
		/// 帮救措施
		/// </summary>
		public string HelpMethod
		{
			set{ _helpmethod=value;}
			get{return _helpmethod;}
		}
        /// <summary>
        /// 转变情况
        /// </summary>
	    public string Changes
	    {
            set { _changes = value; }
            get { return _changes; }
	    }
		/// <summary>
		/// 关键人解除意见
		/// </summary>
		public string PersonRemoveSuggests
		{
			set{ _personremovesuggests=value;}
			get{return _personremovesuggests;}
		}
		/// <summary>
		/// 关键点确定原因
		/// </summary>
		public string LocationConfirmReason
		{
			set{ _locationconfirmreason=value;}
			get{return _locationconfirmreason;}
		}
		/// <summary>
		/// 盯控措施
		/// </summary>
		public string ControlMethod
		{
			set{ _controlmethod=value;}
			get{return _controlmethod;}
		}
		/// <summary>
		/// 落实情况
		/// </summary>
		public string ActualControl
		{
			set{ _actualcontrol=value;}
			get{return _actualcontrol;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LocationRemoveSuggests
		{
			set{ _locationremovesuggests=value;}
			get{return _locationremovesuggests;}
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

