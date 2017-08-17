using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.Model
{
    /// <summary>
	/// ViewOperateLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class ViewOperateLog
    {
        public ViewOperateLog()
        { }
        #region Model
        private int _id;
        private string _logcontent;
        private DateTime _operatetime;
        private int _operatetype;
        private int _systemuserid;
        private int _targetid;
        private string _targettable;
        private string _account;
        private int? _departmentid;
        private string _departmentname;
        private string _name;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogContent
        {
            set { _logcontent = value; }
            get { return _logcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OperateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OperateType
        {
            set { _operatetype = value; }
            get { return _operatetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SystemUserId
        {
            set { _systemuserid = value; }
            get { return _systemuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TargetId
        {
            set { _targetid = value; }
            get { return _targetid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TargetTable
        {
            set { _targettable = value; }
            get { return _targettable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DepartmentId
        {
            set { _departmentid = value; }
            get { return _departmentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName
        {
            set { _departmentname = value; }
            get { return _departmentname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        #endregion Model
    }
}
