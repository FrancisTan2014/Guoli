using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.Model
{
    /// <summary>
	/// 应用更新表
	/// </summary>
	[Serializable]
    public partial class AppUpdate
    {
        public AppUpdate()
        { }
        #region Model
        private int _id;
        private string _version;
        private string _updatelog;
        private string _url;
        private string _hashcode;
        private string _token;
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
        /// 版本号
        /// </summary>
        public string Version
        {
            set { _version = value; }
            get { return _version; }
        }
        /// <summary>
        /// 更新日志
        /// </summary>
        public string UpdateLog
        {
            set { _updatelog = value; }
            get { return _updatelog; }
        }
        /// <summary>
        /// 文件地址（相对路径）
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 文件Hash值
        /// </summary>
        public string HashCode
        {
            set { _hashcode = value; }
            get { return _hashcode; }
        }
        /// <summary>
        /// 验证令牌（验证app是否由正常渠道上传的）
        /// </summary>
        public string Token
        {
            set { _token = value; }
            get { return _token; }
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
