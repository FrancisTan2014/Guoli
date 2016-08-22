/**  版本信息模板在安装目录下，可自行修改。
* BaseStation.cs
*
* 功 能： N/A
* 类 名： BaseStation
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
	/// 基础车站信息
	/// </summary>
	[Serializable]
	public partial class BaseStation
	{
		public BaseStation()
		{}
		#region Model
		private int _id;
		private string _stationname;
		private int _sn;
		private string _spell;
	    private DateTime _updatetime = DateTime.Now;
	    private bool _isdelete = false;
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
		public string StationName
		{
			set{ _stationname=value;}
			get{return _stationname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SN
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 
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
            set { _isdelete = value; }
            get { return _isdelete; }
	    }
		#endregion Model

	}
}

