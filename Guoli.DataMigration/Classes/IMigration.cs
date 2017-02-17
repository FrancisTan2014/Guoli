using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guoli.DataMigration
{
    /// <summary>
    /// 提供数据迁移的操作规范
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2017-02-10</since>
    public interface IMigration
    {
        /// <summary>
        /// 从数据源导入新增数据
        /// </summary>
        /// <author>FrancisTan</author>
        /// <since>2017-02-10</since>
        void ImportNewData();

        /// <summary>
        /// 从数据源获取被编辑（修改/删除）过的数据更新
        /// </summary>
        /// <author>FrancisTan</author>
        /// <since>2017-02-10</since>
        void UpdateEditedData();
    }
}
