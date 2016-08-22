/**  版本信息模板在安装目录下，可自行修改。
* InstructorAccept.cs
*
* 功 能： N/A
* 类 名： InstructorAccept
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/9 15:52:43   N/A    初版
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
	/// 标准化验收
	/// </summary>
	[Serializable]
	public partial class InstructorAccept
	{
		public InstructorAccept()
		{}
		#region Model
		private int _id;
	    private DateTime _acceptdate;
		private int _instructorid;
		private int _driverid;
		private int _vicedriverid;
		private decimal _driverscore;
		private decimal _vicedriverscore;
		private string _problems="";
		private string _suggests="";
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
        /// 验收日期
        /// </summary>
	    public DateTime AcceptDate
	    {
            set { _acceptdate = value; }
            get { return _acceptdate; }
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
		/// 司机Id
		/// </summary>
		public int DriverId
		{
			set{ _driverid=value;}
			get{return _driverid;}
		}
		/// <summary>
		/// 副司机Id
		/// </summary>
		public int ViceDriverId
		{
			set{ _vicedriverid=value;}
			get{return _vicedriverid;}
		}
		/// <summary>
		/// 司机得分
		/// </summary>
		public decimal DriverScore
		{
			set{ _driverscore=value;}
			get{return _driverscore;}
		}
		/// <summary>
		/// 副司机得分
		/// </summary>
		public decimal ViceDriverScore
		{
			set{ _vicedriverscore=value;}
			get{return _vicedriverscore;}
		}
		/// <summary>
		/// 主要问题
		/// </summary>
		public string Problems
		{
			set{ _problems=value;}
			get{return _problems;}
		}
		/// <summary>
		/// 指导意见
		/// </summary>
		public string Suggests
		{
			set{ _suggests=value;}
			get{return _suggests;}
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

