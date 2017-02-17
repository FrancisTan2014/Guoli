using System;
namespace Guoli.Model.OracleModels
{
    /// <summary>
    /// J_JCYY_BASEPOST:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class J_JCYY_BASEPOST
    {
        public J_JCYY_BASEPOST()
        { }
        #region Model
        private string _postname;
        private string _spell;
        private string _upperpost;
        private decimal? _sign = 1M;
        private decimal? _hlevel;
        private string _postid;
        private decimal? _trainman;
        /// <summary>
        /// 
        /// </summary>
        public string POSTNAME
        {
            set { _postname = value; }
            get { return _postname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SPELL
        {
            set { _spell = value; }
            get { return _spell; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UPPERPOST
        {
            set { _upperpost = value; }
            get { return _upperpost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SIGN
        {
            set { _sign = value; }
            get { return _sign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HLEVEL
        {
            set { _hlevel = value; }
            get { return _hlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string POSTID
        {
            set { _postid = value; }
            get { return _postid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TRAINMAN
        {
            set { _trainman = value; }
            get { return _trainman; }
        }
        #endregion Model

    }
}

