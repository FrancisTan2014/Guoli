using System;
namespace Guoli.Model
{
    /// <summary>
    /// ViewAppOperateLog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ViewAppOperateLog
    {
        public ViewAppOperateLog()
        { }
        #region Model
        private DateTime _addtime;
        private int _deviceid;
        private int _id;
        private string _logcontent;
        private int _logtype;
        private int _operatorid;
        private int? _departmentid;
        private string _departmentname;
        private string _name;
        private int? _postid;
        private string _postname;
        private string _workno;
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeviceId
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
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
        public int LogType
        {
            set { _logtype = value; }
            get { return _logtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OperatorId
        {
            set { _operatorid = value; }
            get { return _operatorid; }
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
        /// <summary>
        /// 
        /// </summary>
        public int? PostId
        {
            set { _postid = value; }
            get { return _postid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostName
        {
            set { _postname = value; }
            get { return _postname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkNo
        {
            set { _workno = value; }
            get { return _workno; }
        }
        #endregion Model

    }
}

