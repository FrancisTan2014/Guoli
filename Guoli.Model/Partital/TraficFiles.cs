/**  版本信息模板在安装目录下，可自行修改。
* TraficFiles.cs
*
* 功 能： N/A
* 类 名： TraficFiles
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:28   N/A    初版
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
	/// 行车资料文件管理表
	/// </summary>
	[Serializable]
	public partial class TraficFiles
	{
        public TraficFiles()
        { }
        #region Model
        private int _id;
        private int _typeid;
        private string _filename;
        private string _fileextension;
        private long _filesize;
        private string _originFilePath = string.Empty;
        private string _filepath;
        private int _creatorid = 0;
        private int _departmentid = 0;
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
        /// 文件分类Id，关联行车资料分类表的主键
        /// </summary>
        public int TypeId
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 文件类型（扩展名）
        /// </summary>
        public string FileExtension
        {
            set { _fileextension = value; }
            get { return _fileextension; }
        }
        /// <summary>
        /// 文件大小（单位：KB）
        /// </summary>
        public long FileSize
        {
            set { _filesize = value; }
            get { return _filesize; }
        }
        /// <summary>
        /// 原始文件地址
        /// </summary>
        public string OriginFilePath
        {
            set { _originFilePath = value; }
            get { return _originFilePath; }
        }
        /// <summary>
        /// 文件地址，文件在服务器存放的相对路径
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 创建者管理员Id（关联SystemUser表的主键）
        /// </summary>
        public int CreatorId
        {
            set { _creatorid = value; }
            get { return _creatorid; }
        }
        /// <summary>
        /// 所属部门Id
        /// </summary>
        public int DepartmentId
        {
            set { _departmentid = value; }
            get { return _departmentid; }
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

