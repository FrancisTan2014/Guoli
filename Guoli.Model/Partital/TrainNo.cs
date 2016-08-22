/**  版本信息模板在安装目录下，可自行修改。
* TrainNo.cs
*
* 功 能： N/A
* 类 名： TrainNo
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
	/// 基础车次信息
	/// </summary>
	[Serializable]
	public partial class TrainNo
	{
		public TrainNo()
		{}
		#region Model
		private int _id;
		private string _fullname;
		private string _code="";
		private string _number="";
		private string _direction;
	    private string _firststation;
	    private string _laststation;
		private int _runtype;
		private DateTime _updatetime= DateTime.Now;
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
		/// 车次全称，如Z170
		/// </summary>
		public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// 车次打头的字母，如Z170的编码为Z
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 车次除去打头字母后，剩下的数字
		/// </summary>
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 列车运行方向，此方向是相对于北京来说，朝北京运行的方向称为“上行”，远离北京的运行方向称为“下行”
		/// </summary>
		public string Direction
		{
			set{ _direction=value;}
			get{return _direction;}
		}
		/// <summary>
		/// 车次类型（1 客车； 2 货车； 3 单机； 4 其他）
		/// </summary>
		public int RunType
		{
			set{ _runtype=value;}
			get{return _runtype;}
		}
        /// <summary>
        /// 起始站
        /// </summary>
	    public string FirstStation
	    {
            set { _firststation = value; }
            get { return _firststation; }
	    }
        /// <summary>
        /// 终点站
        /// </summary>
	    public string LastStation
	    {
            set { _laststation = value; }
            get { return _laststation; }
	    }
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
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

