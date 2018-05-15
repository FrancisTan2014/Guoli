using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.Model
{
    /// <summary>
    /// 用于标识数据的身份（主或副），记录其唯一标识等信息
    /// </summary>
    [Serializable]
    public partial class DbIdentity
    {
        public DbIdentity()
        { }
        #region Model
        private int _id;
        private int _identity;
        private Guid _uniqueid;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 身份标识（1 服务端数据库； 2 客户端数据库；）
        /// </summary>
        public int Identity
        {
            set { _identity = value; }
            get { return _identity; }
        }
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid UniqueId
        {
            set { _uniqueid = value; }
            get { return _uniqueid; }
        }
        #endregion Model

    }
}
