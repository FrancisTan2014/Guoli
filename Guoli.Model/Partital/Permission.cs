using System;
namespace Guoli.Model
{
    /// <summary>
    /// 权限管理表（用户被允许访问的菜单管理）
    /// </summary>
    [Serializable]
    public partial class Permission
    {
        public Permission()
        { }
        #region Model
        private int _id;
        private int _systemuserid;
        private int _menuid;
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
        /// 用户Id，关联系统用户表主键
        /// </summary>
        public int SystemUserId
        {
            set { _systemuserid = value; }
            get { return _systemuserid; }
        }
        /// <summary>
        /// 菜单Id，关联菜单表的主键
        /// </summary>
        public int MenuId
        {
            set { _menuid = value; }
            get { return _menuid; }
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

