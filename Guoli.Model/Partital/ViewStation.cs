/**  版本信息模板在安装目录下，可自行修改。
* View_Station.cs
*
* 功 能： N/A
* 类 名： View_Station
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/28 23:35:24   N/A    初版
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
	/// View_Station:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewStation
	{
		public ViewStation()
		{}
		#region Model
		private int _id;
		private int _sn;
		private string _stationname;
		private string _spell;
		private int _filecount;
		private int _zdcount;
		private int _czcount;
		private int _zccount;
	    private DateTime _updatetime;
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
		public int SN
		{
			set{ _sn=value;}
			get{return _sn;}
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
		public string Spell
		{
			set{ _spell=value;}
			get{return _spell;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FileCount
		{
			set{ _filecount=value;}
			get{return _filecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ZdCount
		{
			set{ _zdcount=value;}
			get{return _zdcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CzCount
		{
			set{ _czcount=value;}
			get{return _czcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ZcCount
		{
			set{ _zccount=value;}
			get{return _zccount;}
		}
        /// <summary>
        /// 
        /// </summary>
	    public DateTime UpdateTime
	    {
            set { _updatetime = value; }
            get { return _updatetime; }
	    }
		#endregion Model

	}
}

