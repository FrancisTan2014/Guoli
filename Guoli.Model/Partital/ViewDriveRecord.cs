/**  版本信息模板在安装目录下，可自行修改。
* ViewDriveRecord.cs
*
* 功 能： N/A
* 类 名： ViewDriveRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/3 11:50:40   N/A    初版
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
	/// ViewDriveRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ViewDriveRecord
	{
		public ViewDriveRecord()
		{}
		#region Model
		private int _id;
		private int _driverid1;
		private int _driverid2;
		private int _vicedriverid;
		private int _studentdriverid;
		private int _otherdriverid;
		private string _locomotivetype;
		private DateTime _attendtime;
		private DateTime _gettraintime;
		private DateTime _leavedepottime1;
		private DateTime _leavedepottime2;
		private string _attendforecast;
		private DateTime _arrivedepottime1;
		private DateTime _arrivedepottime2;
		private DateTime _givetraintime;
		private DateTime _recordendtime;
		private decimal _operateconsume;
		private decimal _stopconsume;
		private decimal _recieveenergy;
		private decimal _leftenergy;
		private decimal _engineoil;
		private decimal _aircompressoroil;
		private decimal _turbineoil;
		private decimal _gearoil;
		private decimal _governoroil;
		private decimal _otheroil;
		private decimal _staple;
		private string _multilocodepot;
		private string _multilocotype;
		private string _multilocosection;
		private string _endsummary;
		private DateTime _addtime;
		private bool _isdelete;
		private string _driverworkno;
		private string _drivername;
		private string _vicedriverworkno;
		private string _vicedrivername;
		private string _studriverworkno;
		private string _studrivername;
		private string _otherdriverworkno;
		private string _otherdrivername;
		private int? _drivetrainnoandlineid;
		private int? _trainnoid;
		private int? _lineid;
		private string _code;
		private string _direction;
		private string _firststation;
		private string _fullname;
		private string _laststation;
		private string _number;
		private int? _runtype;
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
		public int DriverId1
		{
			set{ _driverid1=value;}
			get{return _driverid1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DriverId2
		{
			set{ _driverid2=value;}
			get{return _driverid2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ViceDriverId
		{
			set{ _vicedriverid=value;}
			get{return _vicedriverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StudentDriverId
		{
			set{ _studentdriverid=value;}
			get{return _studentdriverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OtherDriverId
		{
			set{ _otherdriverid=value;}
			get{return _otherdriverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LocomotiveType
		{
			set{ _locomotivetype=value;}
			get{return _locomotivetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AttendTime
		{
			set{ _attendtime=value;}
			get{return _attendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime GetTrainTime
		{
			set{ _gettraintime=value;}
			get{return _gettraintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LeaveDepotTime1
		{
			set{ _leavedepottime1=value;}
			get{return _leavedepottime1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LeaveDepotTime2
		{
			set{ _leavedepottime2=value;}
			get{return _leavedepottime2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttendForecast
		{
			set{ _attendforecast=value;}
			get{return _attendforecast;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ArriveDepotTime1
		{
			set{ _arrivedepottime1=value;}
			get{return _arrivedepottime1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ArriveDepotTime2
		{
			set{ _arrivedepottime2=value;}
			get{return _arrivedepottime2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime GiveTrainTime
		{
			set{ _givetraintime=value;}
			get{return _givetraintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RecordEndTime
		{
			set{ _recordendtime=value;}
			get{return _recordendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal OperateConsume
		{
			set{ _operateconsume=value;}
			get{return _operateconsume;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal StopConsume
		{
			set{ _stopconsume=value;}
			get{return _stopconsume;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal RecieveEnergy
		{
			set{ _recieveenergy=value;}
			get{return _recieveenergy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal LeftEnergy
		{
			set{ _leftenergy=value;}
			get{return _leftenergy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal EngineOil
		{
			set{ _engineoil=value;}
			get{return _engineoil;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal AirCompressorOil
		{
			set{ _aircompressoroil=value;}
			get{return _aircompressoroil;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TurbineOil
		{
			set{ _turbineoil=value;}
			get{return _turbineoil;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal GearOil
		{
			set{ _gearoil=value;}
			get{return _gearoil;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal GovernorOil
		{
			set{ _governoroil=value;}
			get{return _governoroil;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal OtherOil
		{
			set{ _otheroil=value;}
			get{return _otheroil;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Staple
		{
			set{ _staple=value;}
			get{return _staple;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MultiLocoDepot
		{
			set{ _multilocodepot=value;}
			get{return _multilocodepot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MultiLocoType
		{
			set{ _multilocotype=value;}
			get{return _multilocotype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MultiLocoSection
		{
			set{ _multilocosection=value;}
			get{return _multilocosection;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EndSummary
		{
			set{ _endsummary=value;}
			get{return _endsummary;}
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
		/// <summary>
		/// 
		/// </summary>
		public string DriverWorkNo
		{
			set{ _driverworkno=value;}
			get{return _driverworkno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DriverName
		{
			set{ _drivername=value;}
			get{return _drivername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ViceDriverWorkNo
		{
			set{ _vicedriverworkno=value;}
			get{return _vicedriverworkno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ViceDriverName
		{
			set{ _vicedrivername=value;}
			get{return _vicedrivername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StuDriverWorkNo
		{
			set{ _studriverworkno=value;}
			get{return _studriverworkno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StuDriverName
		{
			set{ _studrivername=value;}
			get{return _studrivername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherDriverWorkNo
		{
			set{ _otherdriverworkno=value;}
			get{return _otherdriverworkno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherDriverName
		{
			set{ _otherdrivername=value;}
			get{return _otherdrivername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DriveTrainNoAndLineId
		{
			set{ _drivetrainnoandlineid=value;}
			get{return _drivetrainnoandlineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TrainNoId
		{
			set{ _trainnoid=value;}
			get{return _trainnoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LineId
		{
			set{ _lineid=value;}
			get{return _lineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Direction
		{
			set{ _direction=value;}
			get{return _direction;}
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
		public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
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
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RunType
		{
			set{ _runtype=value;}
			get{return _runtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LineName
		{
			set{ _linename=value;}
			get{return _linename;}
		}
		#endregion Model

	}
}

