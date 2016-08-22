/**  版本信息模板在安装目录下，可自行修改。
* InstructorCheck.cs
*
* 功 能： N/A
* 类 名： InstructorCheck
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/27 18:59:00   N/A    初版
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
	/// 抽查信息单
	/// </summary>
	[Serializable]
	public partial class InstructorCheck
	{
		public InstructorCheck()
		{}
		#region Model
		private int _id;
		private int _instructorid;
		private DateTime _starttime;
		private DateTime _endtime;
		private string _location;
		private string _checktype;
		private int _problemcount;
		private string _checkcontent="";
		private string _problems;
		private string _suggests;
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
		/// 指导司机Id，关联乘务员信息表主键
		/// </summary>
		public int InstructorId
		{
			set{ _instructorid=value;}
			get{return _instructorid;}
		}
		/// <summary>
		/// 抽查开始时间
		/// </summary>
		public DateTime StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 抽查结束时间
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 抽查地点
		/// </summary>
		public string Location
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// 抽查类型（如：坐岗，测查等）
		/// </summary>
		public string CheckType
		{
			set{ _checktype=value;}
			get{return _checktype;}
		}
		/// <summary>
		/// 发现问题个数
		/// </summary>
		public int ProblemCount
		{
			set{ _problemcount=value;}
			get{return _problemcount;}
		}
		/// <summary>
		/// 抽查内容
		/// </summary>
		public string CheckContent
		{
			set{ _checkcontent=value;}
			get{return _checkcontent;}
		}
		/// <summary>
		/// 发现问题
		/// </summary>
		public string Problems
		{
			set{ _problems=value;}
			get{return _problems;}
		}
		/// <summary>
		/// 
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

