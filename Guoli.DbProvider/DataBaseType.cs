using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guoli.DbProvider
{
    /// <summary>
    /// 定义描述数据库类型（如MsSql,Mysql,Oracle等）的枚举类型
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-06-29</since>
    public enum DatabaseType
    {
        SqlServer = 1,
        Oracle = 2,
        MySql = 3
    }
}
