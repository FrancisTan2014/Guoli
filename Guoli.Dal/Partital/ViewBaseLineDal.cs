

/*
 * 本文件使用代码生成器生成，随时有可能被更改
 * 若要添加新逻辑请在其他地方新建partial类
 */

using Guoli.Model;

namespace Guoli.Dal  

{
	/// <summary>
    /// ViewBaseLine表的数据访问层实现
    /// </summary>
    /// <remarks>动软生成于2016-08-19</remarks>
	public partial class ViewBaseLineDal : BaseDal<ViewBaseLine>
	{
		/// <summary>
        /// 在派生类中重写时，表示当前操作的表名称
        /// </summary>
		protected override string TableName { get { return "ViewBaseLine"; } }
		
		/// <summary>
        /// 在派生类中重写时，表示当前表的主键名称
        /// </summary>
		protected override string PrimaryKeyName { get { return "Id"; } }		
	}
}
