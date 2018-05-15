using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.Bll
{
    public interface IBll
    {
        IEnumerable<object> QueryList(string condition);
    }
}
