using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Guoli.DataSync
{
    internal class Utils
    {
        public static string MakeSyncDir(string origin)
        {
            return Path.Combine(origin, "__sync");
        }
    }
}
