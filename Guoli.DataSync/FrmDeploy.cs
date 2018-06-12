using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
using System.IO;

namespace Guoli.DataSync
{
    public partial class FrmDeploy : Form
    {
        public FrmDeploy()
        {
            InitializeComponent();
        }

        private void btnInitUsb_Click(object sender, EventArgs e)
        {
            var devices = GetUsbDevices();
            if (devices.Any())
            {
                Console.WriteLine(devices.Count());
            }
            else
            {
                MessageBox.Show("没有检测到 USB 设备，请检查您的设备是否正常连接至电脑");
            }
        }

        private IEnumerable<USBDeviceInfo> GetUsbDevices()
        {
            foreach (var device in new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive WHERE InterfaceType LIKE 'USB%'").Get())
            {
                foreach (var partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value
                    + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                {
                    foreach (var disk in new ManagementObjectSearcher(
                                "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                                    + partition["DeviceID"]
                                    + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                    {
                        var dir = disk["Name"].ToString();
                        var volume = disk["VolumeName"].ToString();
                        yield return new USBDeviceInfo { Name = dir, VolumeName = volume };
                    }
                }
            }
        }
    }
}
