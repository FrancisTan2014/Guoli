

/*
 * 本文件使用代码生成器生成，随时有可能被更改
 * 若要添加新逻辑请在其他地方新建partial类
 */

using Guoli.Model;

namespace Guoli.Dal  

{
	/// <summary>
    /// TraficSearchRecord表的数据访问层实现
    /// </summary>
    /// <remarks>动软生成于2016-07-14</remarks>
	public partial class TraficSearchRecordDal : BaseDal<TraficSearchRecord>
	{
		/// <summary>
        /// 在派生类中重写时，表示当前操作的表名称
        /// </summary>
		protected override string TableName { get { return "TraficSearchRecord"; } }
		
		/// <summary>
        /// 在派生类中重写时，表示当前表的主键名称
        /// </summary>
		protected override string PrimaryKeyName { get { return "Id"; } }		
	}
}
