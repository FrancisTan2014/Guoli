/**  版本信息模板在安装目录下，可自行修改。
* StationFiles.cs
*
* 功 能： N/A
* 类 名： StationFiles
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:26   N/A    初版
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
	/// 与车站相关的文件（如站段明细、操作提示卡、站场示意图等）
	/// </summary>
	[Serializable]
	public partial class StationFiles
	{
		public StationFiles()
		{}
		#region Model
		private int _id;
		private int _stationid;
		private int _filetype;
	    private long _filesize;
	    private string _filename;
		private string _filepath;
		private DateTime _addtime = DateTime.Now;
		private bool _isdelete = false;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 车站Id，关联车站信息表主键
		/// </summary>
		public int StationId
		{
			set{ _stationid=value;}
			get{return _stationid;}
		}
		/// <summary>
		/// 文件类型（1 表示站段明细； 2 表示操作提示卡； 3 表示站场示意图；）
		/// </summary>
		public int FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
        /// <summary>
        /// 文件大小（单位：KB）
        /// </summary>
	    public long FileSize
	    {
            set { _filesize = value; }
            get { return _filesize; }
	    }
        /// <summary>
        /// 文件名称
        /// </summary>
	    public string FileName
	    {
            set { _filename = value; }
            get { return _filename; }
	    }
		/// <summary>
		/// 文件在服务器存储的地址
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
		public bool IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

