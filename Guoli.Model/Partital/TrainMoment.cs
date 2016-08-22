/**  版本信息模板在安装目录下，可自行修改。
* TrainMoment.cs
*
* 功 能： N/A
* 类 名： TrainMoment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/31 18:58:18   N/A    初版
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
	/// 列车时刻表
	/// </summary>
	[Serializable]
	public partial class TrainMoment
	{
		public TrainMoment()
		{}
		#region Model
		private int _id;
		private int _trainnolineid;
		private int _trainstationid;
		private string _arrivetime="";
		private string _departtime="";
		private int _stopminutes;
		private decimal _intervalkms=0.0M;
		private decimal _suggestspeed=0.0M;
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
		/// 车次线路关联表id，关联车次线路关联表的主键
		/// </summary>
		public int TrainNoLineId
		{
			set{ _trainnolineid=value;}
			get{return _trainnolineid;}
		}
		/// <summary>
		/// 车站id，关联车站信息表的主键
		/// </summary>
		public int TrainStationId
		{
			set{ _trainstationid=value;}
			get{return _trainstationid;}
		}
		/// <summary>
		/// 列车到达本站的时间点，如15：32
		/// </summary>
		public string ArriveTime
		{
			set{ _arrivetime=value;}
			get{return _arrivetime;}
		}
		/// <summary>
		/// 列车从本站发车的时间点，如16：48
		/// </summary>
		public string DepartTime
		{
			set{ _departtime=value;}
			get{return _departtime;}
		}
		/// <summary>
		/// 列车在本站停靠的时间，以分为单位表示
		/// </summary>
		public int StopMinutes
		{
			set{ _stopminutes=value;}
			get{return _stopminutes;}
		}
		/// <summary>
		/// 区间公里数，指的是从上一个站到本站的一段距离
		/// </summary>
		public decimal IntervalKms
		{
			set{ _intervalkms=value;}
			get{return _intervalkms;}
		}
		/// <summary>
		/// 建议车速
		/// </summary>
		public decimal SuggestSpeed
		{
			set{ _suggestspeed=value;}
			get{return _suggestspeed;}
		}
        /// <summary>
        /// 编号，描述车次经过车站的顺序，数字越小越靠前
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
		#endregion Model

	}
}

