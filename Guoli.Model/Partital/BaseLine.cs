/**  版本信息模板在安装目录下，可自行修改。
* BaseLine.cs
*
* 功 能： N/A
* 类 名： BaseLine
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:16   N/A    初版
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
	/// 基础线路信息表
	/// </summary>
	[Serializable]
	public partial class BaseLine
	{
		public BaseLine()
		{}
		#region Model
		private int _id;
		private string _linename;
		private int _firststationid;
	    private string _firststaion;
		private int _laststationid;
	    private string _laststation;
		private decimal _linelength=0.0M;
		private string _spell="";
	    private DateTime _updatetime = DateTime.Now;
		private bool _isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 线路名称
		/// </summary>
		public string LineName
		{
			set{ _linename=value;}
			get{return _linename;}
		}
		/// <summary>
		/// 线路起始站Id，关联车站信息表主键
		/// </summary>
		public int FirstStationId
		{
			set{ _firststationid=value;}
			get{return _firststationid;}
		}
        /// <summary>
        /// 起始站名称
        /// </summary>
	    public string FirstStation
	    {
            set { _firststaion = value; }
            get { return _firststaion; }
	    }
		/// <summary>
		/// 线路终点站Id，关联车站信息表主键
		/// </summary>
		public int LastStationId
		{
			set{ _laststationid=value;}
			get{return _laststationid;}
		}
        /// <summary>
        /// 线路终点站名称
        /// </summary>
	    public string LastStation
	    {
            set { _laststation = value; }
            get { return _laststation; }
	    }
		/// <summary>
		/// 线路长度（公里数）
		/// </summary>
		public decimal LineLength
		{
			set{ _linelength=value;}
			get{return _linelength;}
		}
		/// <summary>
		/// 拼音缩写
		/// </summary>
		public string Spell
		{
			set{ _spell=value;}
			get{return _spell;}
		}
        /// <summary>
        /// 更新时间
        /// </summary>
	    public DateTime UpdateTime
	    {
            set { _updatetime = value; }
            get { return _updatetime; }
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

