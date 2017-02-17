using System;
namespace Guoli.Model.OracleModels
{
    /// <summary>
    /// Z_JCYY_BASEPERSONNEL:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Z_JCYY_BASEPERSONNEL
    {
        public Z_JCYY_BASEPERSONNEL()
        { }
        #region Model
        private string _personid;
        private string _workno;
        private string _deptid;
        private string _depotid;
        private string _hname;
        private decimal? _iccardid;
        private string _spell;
        private string _folk;
        private DateTime? _dob;
        private string _marrystatus;
        private string _sex;
        private string _postid;
        private string _familyphonenum;
        private string _mobilenumber;
        private string _officephonenum;
        private DateTime? _beginworktime;
        private DateTime? _enterrailroadtime;
        private DateTime? _enterdepottime;
        private byte[] _photo;
        private string _eductionlevel;
        private string _political;
        private string _nativeplace;
        private string _title;
        private string _address;
        private DateTime? _safebeginday = DateTime.Now;
        private string _idcard;
        private string _techgrade;
        private string _password;
        private decimal? _status = 1M;
        private decimal? _color = 0M;
        private string _plategroupid;
        private string _lococrew;
        private DateTime? _promoteminordriverdate;
        private string _minordriveno;
        private DateTime? _promotedriverdate;
        private string _driveno;
        private string _drivelocotype;
        private string _techniclevel;
        private decimal? _roomarea;
        private string _hishonour;
        private string _safelevel;
        private decimal? _drivekm;
        private decimal? _safekm;
        private decimal? _hundreds;
        private string _dynamicinfo;
        private DateTime? _offdepotdate;
        private byte[] _electronicseal;
        private decimal? _isinnp;
        private string _acttraintype;
        private string _drivinglicence;
        private string _keymemo;
        private string _workgroupid;
        private string _workgroupname;
        private string _place;
        private string _lastoutdepottime;
        private string _trainclasses;
        private DateTime? _last_time;
        private string _dynamicinfo2;
        private string _dynamicinfo3;
        private string _drivelocotypea;
        private string _licensekind;
        private string _workshopplace;
        private DateTime? _promoteemusdriverdate;
        private string _emusdriveno;
        private DateTime? _licensedate;
        private DateTime? _emuslicensedate;
        private DateTime? _minorlicensedate;
        private DateTime? _changelicensedate;
        private DateTime? _changeemuslicensedate;
        private DateTime? _changeminorlicensedate;
        private string _jl;
        private string _cf;
        private string _id;
        private string _minorlicensekind;
        private string _emuslicensekind;
        private decimal? _monthlyworktime;
        private decimal? _contnightworks;
        private DateTime? _enterrailwaytime;
        private string _jobclassification;
        private string _dynamicjccwy;
        private string _dynamic200dccwy;
        private string _dynamic300dccwy;
        private string _licencetype1;
        private string _licenceno;
        private string _dclicencetype;
        private string _dclicenceno;
        private DateTime? _dclicensedate;
        private decimal? _safedays;
        private decimal? _salary;
        private string _spousepolitical;
        private string _encourage;
        private string _workplace;
        private string _housing;
        private string _licencetype;
        private DateTime? _statustime;
        private string _dgpostid;
        private string _fbzper;
        /// <summary>
        /// 
        /// </summary>
        public string PERSONID
        {
            set { _personid = value; }
            get { return _personid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WORKNO
        {
            set { _workno = value; }
            get { return _workno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DEPTID
        {
            set { _deptid = value; }
            get { return _deptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DEPOTID
        {
            set { _depotid = value; }
            get { return _depotid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HNAME
        {
            set { _hname = value; }
            get { return _hname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ICCARDID
        {
            set { _iccardid = value; }
            get { return _iccardid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPELL
        {
            set { _spell = value; }
            get { return _spell; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FOLK
        {
            set { _folk = value; }
            get { return _folk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DOB
        {
            set { _dob = value; }
            get { return _dob; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MARRYSTATUS
        {
            set { _marrystatus = value; }
            get { return _marrystatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEX
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string POSTID
        {
            set { _postid = value; }
            get { return _postid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FAMILYPHONENUM
        {
            set { _familyphonenum = value; }
            get { return _familyphonenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MOBILENUMBER
        {
            set { _mobilenumber = value; }
            get { return _mobilenumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OFFICEPHONENUM
        {
            set { _officephonenum = value; }
            get { return _officephonenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BEGINWORKTIME
        {
            set { _beginworktime = value; }
            get { return _beginworktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ENTERRAILROADTIME
        {
            set { _enterrailroadtime = value; }
            get { return _enterrailroadtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ENTERDEPOTTIME
        {
            set { _enterdepottime = value; }
            get { return _enterdepottime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] PHOTO
        {
            set { _photo = value; }
            get { return _photo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EDUCTIONLEVEL
        {
            set { _eductionlevel = value; }
            get { return _eductionlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string POLITICAL
        {
            set { _political = value; }
            get { return _political; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NATIVEPLACE
        {
            set { _nativeplace = value; }
            get { return _nativeplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TITLE
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADDRESS
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SAFEBEGINDAY
        {
            set { _safebeginday = value; }
            get { return _safebeginday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDCARD
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TECHGRADE
        {
            set { _techgrade = value; }
            get { return _techgrade; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PASSWORD
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? COLOR
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PLATEGROUPID
        {
            set { _plategroupid = value; }
            get { return _plategroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOCOCREW
        {
            set { _lococrew = value; }
            get { return _lococrew; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PROMOTEMINORDRIVERDATE
        {
            set { _promoteminordriverdate = value; }
            get { return _promoteminordriverdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MINORDRIVENO
        {
            set { _minordriveno = value; }
            get { return _minordriveno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PROMOTEDRIVERDATE
        {
            set { _promotedriverdate = value; }
            get { return _promotedriverdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DRIVENO
        {
            set { _driveno = value; }
            get { return _driveno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DRIVELOCOTYPE
        {
            set { _drivelocotype = value; }
            get { return _drivelocotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TECHNICLEVEL
        {
            set { _techniclevel = value; }
            get { return _techniclevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ROOMAREA
        {
            set { _roomarea = value; }
            get { return _roomarea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HISHONOUR
        {
            set { _hishonour = value; }
            get { return _hishonour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SAFELEVEL
        {
            set { _safelevel = value; }
            get { return _safelevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DRIVEKM
        {
            set { _drivekm = value; }
            get { return _drivekm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SAFEKM
        {
            set { _safekm = value; }
            get { return _safekm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HUNDREDS
        {
            set { _hundreds = value; }
            get { return _hundreds; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DYNAMICINFO
        {
            set { _dynamicinfo = value; }
            get { return _dynamicinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OFFDEPOTDATE
        {
            set { _offdepotdate = value; }
            get { return _offdepotdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] ELECTRONICSEAL
        {
            set { _electronicseal = value; }
            get { return _electronicseal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ISINNP
        {
            set { _isinnp = value; }
            get { return _isinnp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ACTTRAINTYPE
        {
            set { _acttraintype = value; }
            get { return _acttraintype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DRIVINGLICENCE
        {
            set { _drivinglicence = value; }
            get { return _drivinglicence; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KEYMEMO
        {
            set { _keymemo = value; }
            get { return _keymemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WORKGROUPID
        {
            set { _workgroupid = value; }
            get { return _workgroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WORKGROUPNAME
        {
            set { _workgroupname = value; }
            get { return _workgroupname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PLACE
        {
            set { _place = value; }
            get { return _place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LASTOUTDEPOTTIME
        {
            set { _lastoutdepottime = value; }
            get { return _lastoutdepottime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TRAINCLASSES
        {
            set { _trainclasses = value; }
            get { return _trainclasses; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_TIME
        {
            set { _last_time = value; }
            get { return _last_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DYNAMICINFO2
        {
            set { _dynamicinfo2 = value; }
            get { return _dynamicinfo2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DYNAMICINFO3
        {
            set { _dynamicinfo3 = value; }
            get { return _dynamicinfo3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DRIVELOCOTYPEA
        {
            set { _drivelocotypea = value; }
            get { return _drivelocotypea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LICENSEKIND
        {
            set { _licensekind = value; }
            get { return _licensekind; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WORKSHOPPLACE
        {
            set { _workshopplace = value; }
            get { return _workshopplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PROMOTEEMUSDRIVERDATE
        {
            set { _promoteemusdriverdate = value; }
            get { return _promoteemusdriverdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMUSDRIVENO
        {
            set { _emusdriveno = value; }
            get { return _emusdriveno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LICENSEDATE
        {
            set { _licensedate = value; }
            get { return _licensedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EMUSLICENSEDATE
        {
            set { _emuslicensedate = value; }
            get { return _emuslicensedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MINORLICENSEDATE
        {
            set { _minorlicensedate = value; }
            get { return _minorlicensedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CHANGELICENSEDATE
        {
            set { _changelicensedate = value; }
            get { return _changelicensedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CHANGEEMUSLICENSEDATE
        {
            set { _changeemuslicensedate = value; }
            get { return _changeemuslicensedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CHANGEMINORLICENSEDATE
        {
            set { _changeminorlicensedate = value; }
            get { return _changeminorlicensedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JL
        {
            set { _jl = value; }
            get { return _jl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CF
        {
            set { _cf = value; }
            get { return _cf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MINORLICENSEKIND
        {
            set { _minorlicensekind = value; }
            get { return _minorlicensekind; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMUSLICENSEKIND
        {
            set { _emuslicensekind = value; }
            get { return _emuslicensekind; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MONTHLYWORKTIME
        {
            set { _monthlyworktime = value; }
            get { return _monthlyworktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CONTNIGHTWORKS
        {
            set { _contnightworks = value; }
            get { return _contnightworks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ENTERRAILWAYTIME
        {
            set { _enterrailwaytime = value; }
            get { return _enterrailwaytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JOBCLASSIFICATION
        {
            set { _jobclassification = value; }
            get { return _jobclassification; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DYNAMICJCCWY
        {
            set { _dynamicjccwy = value; }
            get { return _dynamicjccwy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DYNAMIC200DCCWY
        {
            set { _dynamic200dccwy = value; }
            get { return _dynamic200dccwy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DYNAMIC300DCCWY
        {
            set { _dynamic300dccwy = value; }
            get { return _dynamic300dccwy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LICENCETYPE1
        {
            set { _licencetype1 = value; }
            get { return _licencetype1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LICENCENO
        {
            set { _licenceno = value; }
            get { return _licenceno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DCLICENCETYPE
        {
            set { _dclicencetype = value; }
            get { return _dclicencetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DCLICENCENO
        {
            set { _dclicenceno = value; }
            get { return _dclicenceno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DCLICENSEDATE
        {
            set { _dclicensedate = value; }
            get { return _dclicensedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SAFEDAYS
        {
            set { _safedays = value; }
            get { return _safedays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SALARY
        {
            set { _salary = value; }
            get { return _salary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPOUSEPOLITICAL
        {
            set { _spousepolitical = value; }
            get { return _spousepolitical; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ENCOURAGE
        {
            set { _encourage = value; }
            get { return _encourage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WORKPLACE
        {
            set { _workplace = value; }
            get { return _workplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HOUSING
        {
            set { _housing = value; }
            get { return _housing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LICENCETYPE
        {
            set { _licencetype = value; }
            get { return _licencetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? STATUSTIME
        {
            set { _statustime = value; }
            get { return _statustime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DGPOSTID
        {
            set { _dgpostid = value; }
            get { return _dgpostid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBZPER
        {
            set { _fbzper = value; }
            get { return _fbzper; }
        }
        #endregion Model

    }
}

