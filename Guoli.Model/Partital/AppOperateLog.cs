using System;
namespace Guoli.Model
{
    /// <summary>
    /// App操作日志
    /// </summary>
    [Serializable]
    public partial class AppOperateLog
    {
        public AppOperateLog()
        { }
        #region Model
        private int _id;
        private int _logtype;
        private string _logcontent;
        private int _operatorid;
        private int _deviceid;
        private DateTime _addtime = DateTime.Now;
        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 操作类型（1.登录系统; 2.退出系统;）
        /// </summary>
        public int LogType
        {
            set { _logtype = value; }
            get { return _logtype; }
        }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogContent
        {
            set { _logcontent = value; }
            get { return _logcontent; }
        }
        /// <summary>
        /// 操作者Id
        /// </summary>
        public int OperatorId
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        /// <summary>
        /// 设备Id，关联设备表的主键
        /// </summary>
        public int DeviceId
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}

