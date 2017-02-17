

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
    /// Y_JCYY_BASEDEPARTMENT表的数据访问层实现
    /// </summary>
    /// <remarks>动软生成于2017-02-09</remarks>
	public partial class Y_JCYY_BASEDEPARTMENTDal : BaseDal<Y_JCYY_BASEDEPARTMENT>
	{
		/// <summary>
        /// 在派生类中重写时，表示当前操作的表名称
        /// </summary>
		protected override string TableName { get { return "Y_JCYY_BASEDEPARTMENT"; } }
		
		/// <summary>
        /// 在派生类中重写时，表示当前表的主键名称
        /// </summary>
		protected override string PrimaryKeyName { get { return "DEPTID"; } }

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

	    public Y_JCYY_BASEDEPARTMENTDal()
	    {
	        DbHelper = DbHelperFactory.GetInstance(DatabaseType.Oracle);
	    }
    }
}
