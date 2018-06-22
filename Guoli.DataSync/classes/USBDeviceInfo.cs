using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Guoli.DataSync
{
    public class USBDeviceInfo
    {
        public string Name { get; set; }
        public string VolumeName { get; set; }

        public string Directory => Name + "\\";
    }
}
