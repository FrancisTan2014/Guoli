using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;

namespace Guoli.DataSync
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var devices = Utils.GetUsbDevices();
            if (!devices.Any())
            {
                MessageBox.Show("没有找到可用于同步数据的 USB 设备，请检查您的设备是否已连接至电脑");
                return;
            }

            var initializedUsb = Utils.GetInitializedUsb(devices);
            var usbSync = new USBSync(initializedUsb);
            if (usbSync.DeviceReady)
            {
                // 确定本机连接的服务器的身份（服务端或者客户端）
                var serverType = Utils.GetCurrentServerType();
                if (serverType == 0)
                {
                    // 服务端的数据库标识数据在部署时已手动添加
                    // 在此，第一次在客户端进行初始化时，将生成
                    // 一条数据库标识数据，插入数据库中
                    Utils.AddDbIdentity();
                    serverType = 2;
                }

                // 根据身份启动相应的程序进行数据同步
                usbSync.DoSync(serverType);
            }
            else
            {
                MessageBox.Show("没有找到可用于同步数据的 USB 设备，您的 USB 设备没有经过“USB 初始化工具”初始化");
            }
        }
    }
}
