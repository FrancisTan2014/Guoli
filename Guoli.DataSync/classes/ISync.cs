using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.DataSync
{
    public interface ISync
    {
        SyncInfo Import(SyncInfo syncInfo);

        SyncInfo Export(SyncInfo syncInfo);
    }
}
