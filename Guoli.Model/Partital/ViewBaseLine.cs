/**  版本信息模板在安装目录下，可自行修改。
* ViewBaseLine.cs
*
* 功 能： N/A
* 类 名： ViewBaseLine
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/19 15:07:56   N/A    初版
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
	/// ViewBaseLine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewBaseLine
	{
		public ViewBaseLine()
		{}
		#region Model
		private int _id;
		private string _linename;
		private int _firststationid;
		private string _firststation;
		private int _laststationid;
		private string _laststation;
		private decimal _linelength;
		private string _spell;
		private DateTime _updatetime;
		private int _stationid;
		private string _stationname;
		private int _sort;
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
		public string LineName
		{
			set{ _linename=value;}
			get{return _linename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FirstStationId
		{
			set{ _firststationid=value;}
			get{return _firststationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FirstStation
		{
			set{ _firststation=value;}
			get{return _firststation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LastStationId
		{
			set{ _laststationid=value;}
			get{return _laststationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LastStation
		{
			set{ _laststation=value;}
			get{return _laststation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal LineLength
		{
			set{ _linelength=value;}
			get{return _linelength;}
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
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StationId
		{
			set{ _stationid=value;}
			get{return _stationid;}
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
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

