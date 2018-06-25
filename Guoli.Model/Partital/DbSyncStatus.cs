using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.Model
{
    /// <summary>
    /// 记录副数据库上次从主数据库同步数据的状态信息
    /// </summary>
    [Serializable]
    public partial class DbSyncStatus
    {
        public DbSyncStatus()
        { }
        #region Model
        private int _id;
        private string _dbidentity;
        private string _tablename;
        private int _position;
        private DateTime _lasttime;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 数据库唯一标识
        /// </summary>
        public string DbIdentity
        {
            set { _dbidentity = value; }
            get { return _dbidentity; }
        }
        /// <summary>
        /// 所同步的表名
        /// </summary>
        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }
        /// <summary>
        /// 上次同步的位置
        /// </summary>
        public int Position
        {
            set { _position = value; }
            get { return _position; }
        }

        public DateTime LastTime
        {
            set { _lasttime = value; }
            get { return _lasttime; }
        }
        #endregion Model

    }
}
