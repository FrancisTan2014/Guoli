/**  版本信息模板在安装目录下，可自行修改。
* ViewTrainNoLIne.cs
*
* 功 能： N/A
* 类 名： ViewTrainNoLIne
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/1 13:48:47   N/A    初版
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
	/// ViewTrainNoLIne:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewTrainNoLIne
	{
		public ViewTrainNoLIne()
		{}
		#region Model
		private int _id;
		private string _fullname;
		private int _trainnolineid;
		private int _sort;
		private int _lineid;
		private string _linename;
        private int _firststationid;
        private string _firststation;
        private int _laststationid;
        private string _laststation;
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
		public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
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
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LineId
		{
			set{ _lineid=value;}
			get{return _lineid;}
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
            set { _firststationid = value; }
            get { return _firststationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FirstStation
        {
            set { _firststation = value; }
            get { return _firststation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LastStationId
        {
            set { _laststationid = value; }
            get { return _laststationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastStation
        {
            set { _laststation = value; }
            get { return _laststation; }
        }
		#endregion Model

	}
}

