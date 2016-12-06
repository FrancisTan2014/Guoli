/**  版本信息模板在安装目录下，可自行修改。
* DriveRecords.cs
*
* 功 能： N/A
* 类 名： DriveRecords
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:19   N/A    初版
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
	/// 列车行车记录表
	/// </summary>
	[Serializable]
	public partial class DriveRecords
	{
		public DriveRecords()
		{}
		#region Model
		private int _id;
		private int _driverid1;
		private int _driverid2=0;
		private int _vicedriverid=0;
		private int _studentdriverid=0;
		private int _otherdriverid=0;
		private string _locomotivetype="";
		private DateTime _attendtime= Convert.ToDateTime("1900-01-01");
		private DateTime _gettraintime= Convert.ToDateTime("1900-01-01");
		private DateTime _leavedepottime1= Convert.ToDateTime("1900-01-01");
		private DateTime _leavedepottime2= Convert.ToDateTime("1900-01-01");
		private string _attendforecast="";
		private DateTime _arrivedepottime1= Convert.ToDateTime("1900-01-01");
		private DateTime _arrivedepottime2= Convert.ToDateTime("1900-01-01");
		private DateTime _givetraintime= Convert.ToDateTime("1900-01-01");
		private DateTime _recordendtime= Convert.ToDateTime("1900-01-01");
		private decimal _operateconsume=0.0M;
		private decimal _stopconsume=0.0M;
		private decimal _recieveenergy=0.0M;
		private decimal _leftenergy=0.0M;
		private decimal _engineoil=0.0M;
		private decimal _aircompressoroil=0.0M;
		private decimal _turbineoil=0.0M;
		private decimal _gearoil=0.0M;
		private decimal _governoroil=0.0M;
		private decimal _otheroil=0.0M;
		private decimal _staple=0M;
		private string _multilocodepot="";
		private string _multilocotype="";
		private string _multilocosection="";
		private string _endsummary="";
		private DateTime _addtime= DateTime.Now;
		private bool _isdelete= false;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 主司机Id，关联乘务员信息表Id
		/// </summary>
		public int DriverId1
		{
			set{ _driverid1=value;}
			get{return _driverid1;}
		}
		/// <summary>
		/// 第二个司机Id，关联乘务员信息表主键
		/// </summary>
		public int DriverId2
		{
			set{ _driverid2=value;}
			get{return _driverid2;}
		}
		/// <summary>
		/// 副司机Id，关联乘务员信息表主键
		/// </summary>
		public int ViceDriverId
		{
			set{ _vicedriverid=value;}
			get{return _vicedriverid;}
		}
		/// <summary>
		/// 学员Id，关联乘务员信息表主键
		/// </summary>
		public int StudentDriverId
		{
			set{ _studentdriverid=value;}
			get{return _studentdriverid;}
		}
		/// <summary>
		/// 其他人员Id，关联 乘务员信息表主键
		/// </summary>
		public int OtherDriverId
		{
			set{ _otherdriverid=value;}
			get{return _otherdriverid;}
		}
		/// <summary>
		/// 机车的型号，如HXDC-6355
		/// </summary>
		public string LocomotiveType
		{
			set{ _locomotivetype=value;}
			get{return _locomotivetype;}
		}
		/// <summary>
		/// 本次出勤时间
		/// </summary>
		public DateTime AttendTime
		{
			set{ _attendtime=value;}
			get{return _attendtime;}
		}
		/// <summary>
		/// 本次出勤拉车时间
		/// </summary>
		public DateTime GetTrainTime
		{
			set{ _gettraintime=value;}
			get{return _gettraintime;}
		}
		/// <summary>
		/// 本次出勤出本段时间
		/// </summary>
		public DateTime LeaveDepotTime1
		{
			set{ _leavedepottime1=value;}
			get{return _leavedepottime1;}
		}
		/// <summary>
		/// 本次出勤出外段时间
		/// </summary>
		public DateTime LeaveDepotTime2
		{
			set{ _leavedepottime2=value;}
			get{return _leavedepottime2;}
		}
		/// <summary>
		/// 出勤会，也称出勤小组会
		/// </summary>
		public string AttendForecast
		{
			set{ _attendforecast=value;}
			get{return _attendforecast;}
		}
		/// <summary>
		/// 退勤时填写，入本段时间
		/// </summary>
		public DateTime ArriveDepotTime1
		{
			set{ _arrivedepottime1=value;}
			get{return _arrivedepottime1;}
		}
		/// <summary>
		/// 退勤时填写，入外段时间
		/// </summary>
		public DateTime ArriveDepotTime2
		{
			set{ _arrivedepottime2=value;}
			get{return _arrivedepottime2;}
		}
		/// <summary>
		/// 退勤时填写，交车时间
		/// </summary>
		public DateTime GiveTrainTime
		{
			set{ _givetraintime=value;}
			get{return _givetraintime;}
		}
		/// <summary>
		/// 退勤时间
		/// </summary>
		public DateTime RecordEndTime
		{
			set{ _recordendtime=value;}
			get{return _recordendtime;}
		}
		/// <summary>
		/// 本次行车运转消耗油/电量
		/// </summary>
		public decimal OperateConsume
		{
			set{ _operateconsume=value;}
			get{return _operateconsume;}
		}
		/// <summary>
		/// 本次行车在段内打湿这段时间的能源（油/电）消耗
		/// </summary>
		public decimal StopConsume
		{
			set{ _stopconsume=value;}
			get{return _stopconsume;}
		}
		/// <summary>
		/// 接车时能源总量
		/// </summary>
		public decimal RecieveEnergy
		{
			set{ _recieveenergy=value;}
			get{return _recieveenergy;}
		}
		/// <summary>
		/// 交车时能源剩余量
		/// </summary>
		public decimal LeftEnergy
		{
			set{ _leftenergy=value;}
			get{return _leftenergy;}
		}
		/// <summary>
		/// 机油消耗量
		/// </summary>
		public decimal EngineOil
		{
			set{ _engineoil=value;}
			get{return _engineoil;}
		}
		/// <summary>
		/// 风泵油消耗量
		/// </summary>
		public decimal AirCompressorOil
		{
			set{ _aircompressoroil=value;}
			get{return _aircompressoroil;}
		}
		/// <summary>
		/// 透平油消耗量
		/// </summary>
		public decimal TurbineOil
		{
			set{ _turbineoil=value;}
			get{return _turbineoil;}
		}
		/// <summary>
		/// 齿轮油消耗量
		/// </summary>
		public decimal GearOil
		{
			set{ _gearoil=value;}
			get{return _gearoil;}
		}
		/// <summary>
		/// 调速器油消耗量
		/// </summary>
		public decimal GovernorOil
		{
			set{ _governoroil=value;}
			get{return _governoroil;}
		}
		/// <summary>
		/// 其他油类消耗量
		/// </summary>
		public decimal OtherOil
		{
			set{ _otheroil=value;}
			get{return _otheroil;}
		}
		/// <summary>
		/// 棉丝消耗量（匹）
		/// </summary>
		public decimal Staple
		{
			set{ _staple=value;}
			get{return _staple;}
		}
		/// <summary>
		/// 重联机车所属机务段
		/// </summary>
		public string MultiLocoDepot
		{
			set{ _multilocodepot=value;}
			get{return _multilocodepot;}
		}
		/// <summary>
		/// 重联机车型号
		/// </summary>
		public string MultiLocoType
		{
			set{ _multilocotype=value;}
			get{return _multilocotype;}
		}
		/// <summary>
		/// 重联机车附挂区间
		/// </summary>
		public string MultiLocoSection
		{
			set{ _multilocosection=value;}
			get{return _multilocosection;}
		}
		/// <summary>
		/// 退勤会，也称退勤小组会
		/// </summary>
		public string EndSummary
		{
			set{ _endsummary=value;}
			get{return _endsummary;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
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

