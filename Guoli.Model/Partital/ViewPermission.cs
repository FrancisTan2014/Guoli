using System;
namespace Guoli.Model
{
    /// <summary>
    /// ViewPermission:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ViewPermission
    {
        public ViewPermission()
        { }
        #region Model
        private int _id;
        private DateTime _addtime;
        private bool _isdelete;
        private int _menuid;
        private int _systemuserid;
        private string _name;
        private int? _parentid;
        private string _path;
        private DateTime? _menuaddtime;
        private bool _ismenudeleted;
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
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MenuId
        {
            set { _menuid = value; }
            get { return _menuid; }
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MenuAddTime
        {
            set { _menuaddtime = value; }
            get { return _menuaddtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsMenuDeleted
        {
            set { _ismenudeleted = value; }
            get { return _ismenudeleted; }
        }
        #endregion Model

    }
}

