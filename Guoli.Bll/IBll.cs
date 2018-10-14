using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.Bll
{
    public interface IBll
    {
        IEnumerable<object> QueryList(string condition);

        void BulkInsert(string json);

        object GetMaxId();

        int ExecuteSql(string sql);

        bool Update(object model);
    }
}
