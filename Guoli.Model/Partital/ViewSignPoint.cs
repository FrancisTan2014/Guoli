using System;
namespace Guoli.Model
{
    /// <summary>
    /// ViewSignPoint:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ViewSignPoint
    {
        public ViewSignPoint()
        { }
        #region Model
        private int? _id;
        private int? _driverecordid;
        private int? _stationid;
        private DateTime? _arrivetime;
        private DateTime? _leavetime;
        private int? _earlyminutes;
        private int? _lateminutes;
        private string _earlyorlatereason;
        private string _linename;
        private string _stationname;
        private int? _sort;
        private int? _carriagecount;
        private decimal? _carryingcapacity;
        private decimal? _length;
        private DateTime? _notetime;
        /// <summary>
        /// 
        /// </summary>
        public int? Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DriveRecordId
        {
            set { _driverecordid = value; }
            get { return _driverecordid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? StationId
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ArriveTime
        {
            set { _arrivetime = value; }
            get { return _arrivetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LeaveTime
        {
            set { _leavetime = value; }
            get { return _leavetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EarlyMinutes
        {
            set { _earlyminutes = value; }
            get { return _earlyminutes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LateMinutes
        {
            set { _lateminutes = value; }
            get { return _lateminutes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EarlyOrLateReason
        {
            set { _earlyorlatereason = value; }
            get { return _earlyorlatereason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineName
        {
            set { _linename = value; }
            get { return _linename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StationName
        {
            set { _stationname = value; }
            get { return _stationname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CarriageCount
        {
            set { _carriagecount = value; }
            get { return _carriagecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CarryingCapacity
        {
            set { _carryingcapacity = value; }
            get { return _carryingcapacity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Length
        {
            set { _length = value; }
            get { return _length; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? NoteTime
        {
            set { _notetime = value; }
            get { return _notetime; }
        }
        #endregion Model

    }
}

