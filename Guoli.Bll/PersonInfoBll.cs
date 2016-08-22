using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.Bll
{
    public partial class PersonInfoBll
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        public int CountDepartPerson(int departId)
        {
            var list = DalInstance.QueryList("IsDelete=0 AND DepartmentId=" + departId, new[] {"Id"});

            return list.Count();
        }
    }
}
