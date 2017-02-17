

/*
 * 本文件使用代码生成器生成，随时有可能被更改
 * 若要添加新逻辑请在其他地方新建partial类
 */

using System.Configuration;
using Guoli.DbProvider;
using Guoli.Model.OracleModels;

namespace Guoli.Dal
{
    /// <summary>
    /// J_JCYY_BASEPOST表的数据访问层实现
    /// </summary>
    /// <remarks>动软生成于2017-02-16</remarks>
    public partial class J_JCYY_BASEPOSTDal : BaseDal<J_JCYY_BASEPOST>
    {
        /// <summary>
        /// 在派生类中重写时，表示当前操作的表名称
        /// </summary>
        protected override string TableName => "J_JCYY_BASEPOST";

        /// <summary>
        /// 在派生类中重写时，表示当前表的主键名称
        /// </summary>
        protected override string PrimaryKeyName => "POSTID";

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected override string ConnectionString
        {
            get
            {
                var conStr = ConfigurationManager.ConnectionStrings["ORACLE"];
                if (conStr == null)
                {
                    throw new ConfigurationErrorsException("未能获取到Oracle数据库连接字符串ORACLE");
                }

                return conStr.ToString();
            }
        }

        public J_JCYY_BASEPOSTDal()
        {

            DbHelper = DbHelperFactory.GetInstance(DatabaseType.Oracle);
        }
    }
}
