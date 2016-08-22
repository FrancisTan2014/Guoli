/**  版本信息模板在安装目录下，可自行修改。
* ViewTrainMoment.cs
*
* 功 能： N/A
* 类 名： ViewTrainMoment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/19 15:05:48   N/A    初版
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
	/// ViewTrainMoment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewTrainMoment
	{
		public ViewTrainMoment()
		{}
		#region Model
		private int _id;
		private int _trainnolineid;
		private int _trainstationid;
		private string _arrivetime;
		private string _departtime;
		private int _stopminutes;
		private decimal _intervalkms;
		private decimal _suggestspeed;
		private int _sort;
		private string _fullname;
		private string _stationname;
		private int _trainnoid;
        private int _lineid;
        private string _linename;
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
		public int TrainNoLineId
		{
			set{ _trainnolineid=value;}
			get{return _trainnolineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TrainStationId
		{
			set{ _trainstationid=value;}
			get{return _trainstationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArriveTime
		{
			set{ _arrivetime=value;}
			get{return _arrivetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartTime
		{
			set{ _departtime=value;}
			get{return _departtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StopMinutes
		{
			set{ _stopminutes=value;}
			get{return _stopminutes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal IntervalKms
		{
			set{ _intervalkms=value;}
			get{return _intervalkms;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SuggestSpeed
		{
			set{ _suggestspeed=value;}
			get{return _suggestspeed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
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
		public int TrainNoId
		{
			set{ _trainnoid=value;}
			get{return _trainnoid;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int LineId
        {
            set { _lineid = value; }
            get { return _lineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineName
        {
            set { _linename = value; }
            get { return _linename; }
        }
		#endregion Model

	}
}

