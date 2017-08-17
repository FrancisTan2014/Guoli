/**  版本信息模板在安装目录下，可自行修改。
* OperateLog.cs
*
* 功 能： N/A
* 类 名： OperateLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:25   N/A    初版
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
	/// 后台操作日志表
	/// </summary>
	[Serializable]
	public partial class OperateLog
	{
        public OperateLog()
        { }
        #region Model
        private int _id;
        private string _logcontent;
        private int _systemuserid;
        private DateTime _operatetime;
        private int _operatetype;
        private string _targettable;
        private int _targetid;
        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string LogContent
        {
            set { _logcontent = value; }
            get { return _logcontent; }
        }
        /// <summary>
        /// 管理员Id，关联管理人员账户表主键
        /// </summary>
        public int SystemUserId
        {
            set { _systemuserid = value; }
            get { return _systemuserid; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        /// <summary>
        /// 操作类型（1 Insert； 2 Update； 3 Delete）
        /// </summary>
        public int OperateType
        {
            set { _operatetype = value; }
            get { return _operatetype; }
        }
        /// <summary>
        /// 所操作的表名
        /// </summary>
        public string TargetTable
        {
            set { _targettable = value; }
            get { return _targettable; }
        }
        /// <summary>
        /// 所操作的数据的主键
        /// </summary>
        public int TargetId
        {
            set { _targetid = value; }
            get { return _targetid; }
        }
        #endregion Model

    }
}

