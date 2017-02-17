using System;
namespace Guoli.Model.OracleModels
{
    /// <summary>
    /// Y_JCYY_BASEDEPARTMENT:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Y_JCYY_BASEDEPARTMENT
    {
        public Y_JCYY_BASEDEPARTMENT()
        { }
        #region Model
        private string _deptid;
        private string _deptname;
        private string _spell;
        private string _upperdeptid;
        private decimal _structurelevel;
        private string _functionname;
        private string _shortname;
        private string _juid;
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
        public string DEPTNAME
        {
            set { _deptname = value; }
            get { return _deptname; }
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
        public string UPPERDEPTID
        {
            set { _upperdeptid = value; }
            get { return _upperdeptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal STRUCTURELEVEL
        {
            set { _structurelevel = value; }
            get { return _structurelevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FUNCTIONNAME
        {
            set { _functionname = value; }
            get { return _functionname; }
        }
        /// <summary>
        /// 部门简称
        /// </summary>
        public string SHORTNAME
        {
            set { _shortname = value; }
            get { return _shortname; }
        }
        /// <summary>
        /// 局部门对应ID
        /// </summary>
        public string JUID
        {
            set { _juid = value; }
            get { return _juid; }
        }
        #endregion Model

    }
}

