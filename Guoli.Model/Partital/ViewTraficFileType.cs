using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.Model
{
    /// <summary>
	/// ViewTraficFileType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class ViewTraficFileType
    {
        public ViewTraficFileType()
        { }
        #region Model
        private int _id;
        private DateTime _createtime;
        private int _creatorid;
        private int _departmentid;
        private bool _isdelete;
        private bool _ispublic;
        private int _parentid;
        private string _typename;
        private string _departmentname;
        private string _creatorname;
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
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CreatorId
        {
            set { _creatorid = value; }
            get { return _creatorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DepartmentId
        {
            set { _departmentid = value; }
            get { return _departmentid; }
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
        public bool IsPublic
        {
            set { _ispublic = value; }
            get { return _ispublic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
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
        public string CreatorName
        {
            set { _creatorname = value; }
            get { return _creatorname; }
        }
        #endregion Model

    }
}
