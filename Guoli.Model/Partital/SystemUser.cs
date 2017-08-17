/**  版本信息模板在安装目录下，可自行修改。
* SystemUser.cs
*
* 功 能： N/A
* 类 名： SystemUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:27   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Guoli.Model
{
	/// <summary>
	/// 后台管理人员账户表
	/// </summary>
	[Serializable]
	public partial class SystemUser
	{
        public SystemUser()
        { }
        #region Model
        private int _id;
        private string _account;
        private string _password;
        private string _name;
        private int _departmentid = 0;
        private string _departmentname = "";
        private DateTime _createtime = DateTime.Now;
        private int _creatorid;
        private bool _isdelete;
        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 部门Id
        /// </summary>
        public int DepartmentId
        {
            set { _departmentid = value; }
            get { return _departmentid; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName
        {
            set { _departmentname = value; }
            get { return _departmentname; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 创建者
        /// </summary>
        public int CreatorId
        {
            set { _creatorid = value; }
            get { return _creatorid; }
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

