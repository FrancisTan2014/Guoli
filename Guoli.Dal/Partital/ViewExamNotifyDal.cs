﻿

/*
 * 本文件使用代码生成器生成，随时有可能被更改
 * 若要添加新逻辑请在其他地方新建partial类
 */

using Guoli.Model;

namespace Guoli.Dal  

{
	/// <summary>
    /// ViewExamNotify表的数据访问层实现
    /// </summary>
    /// <remarks>动软生成于2016-08-16</remarks>
	public partial class ViewExamNotifyDal : BaseDal<ViewExamNotify>
	{
		/// <summary>
        /// 在派生类中重写时，表示当前操作的表名称
        /// </summary>
		protected override string TableName { get { return "ViewExamNotify"; } }
		
		/// <summary>
        /// 在派生类中重写时，表示当前表的主键名称
        /// </summary>
		protected override string PrimaryKeyName { get { return "Id"; } }		
	}
}
