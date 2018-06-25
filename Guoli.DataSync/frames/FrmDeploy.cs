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
using System.Text.RegularExpressions;

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
            var devices = Utils.GetUsbDevices();
            if (devices.Any())
            {
                ShowVolumes(devices);
            }
            else
            {
                MessageBox.Show("没有检测到 USB 设备，请检查您的设备是否正常连接至电脑");
            }
        }

        private void ShowVolumes(IEnumerable<USBDeviceInfo> devices)
        {
            foreach (var d in devices)
            {
                var btn = new Button();
                btn.Text = $"{d.VolumeName}({d.Name})";
                btn.Click += VolumeClick;
                this.Controls.Add(btn);
            }
        }

        private void VolumeClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var t = btn.Text;
            var start = t.LastIndexOf("(") + 1;
            // 从像 xxx(x:) 的字符串中提取盘符
            var dir = t.Substring(start, t.Length - start - 1);
            
            var usbSync = new USBSync(dir);
            if (usbSync.Match())
            {
                MessageBox.Show("此 U 盘已被正确初始化，可以正常使用");
            }
            else
            {
                usbSync.InitUsb();
                this.Controls.Remove(btn);
                MessageBox.Show("初始化成功");
            }
        }
    }
}
