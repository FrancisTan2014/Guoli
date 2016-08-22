/**  版本信息模板在安装目录下，可自行修改。
* ViewExamFiles.cs
*
* 功 能： N/A
* 类 名： ViewExamFiles
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/15 9:52:00   N/A    初版
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
	/// ViewExamFiles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewExamFiles
	{
		public ViewExamFiles()
		{}
		#region Model
		private int _id;
		private int _examtypeid;
		private string _typename;
		private string _filename;
		private string _filedesc;
		private string _filepath;
		private DateTime _addtime;
		private int? _questioncount;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ExamTypeId
		{
			set{ _examtypeid=value;}
			get{return _examtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileDesc
		{
			set{ _filedesc=value;}
			get{return _filedesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? QuestionCount
		{
			set{ _questioncount=value;}
			get{return _questioncount;}
		}
		#endregion Model

	}
}

