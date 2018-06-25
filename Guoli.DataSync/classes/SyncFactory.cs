using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.DataSync
{
    public class SyncFactory
    {
        public ISync GetInstance(int serverType)
        {
            switch (serverType)
            {
                case 1:
                    return new ServerSync();
                case 2:
                    return new ClientSync();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
