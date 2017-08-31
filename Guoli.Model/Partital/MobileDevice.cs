using System;
namespace Guoli.Model
{
    /// <summary>
    /// 移动终端设备表
    /// </summary>
    [Serializable]
    public partial class MobileDevice
    {
        public MobileDevice()
        { }
        #region Model
        private int _id;
        private string _uniqueid;
        private string _devicetype = "";
        private string _osversion = "";
        private DateTime _addtime = DateTime.Now;
        private bool _isdelete = false;
        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 设备唯一标识
        /// </summary>
        public string UniqueId
        {
            set { _uniqueid = value; }
            get { return _uniqueid; }
        }
        /// <summary>
        /// 设备型号
        /// </summary>
        public string DeviceType
        {
            set { _devicetype = value; }
            get { return _devicetype; }
        }
        /// <summary>
        /// 系统版本
        /// </summary>
        public string OsVersion
        {
            set { _osversion = value; }
            get { return _osversion; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

