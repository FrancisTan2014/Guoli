using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;

namespace Guoli.DataSync
{
    public partial class FrmMain : Form
    {
        private FrmDeploy initFrm;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void ScanSyncDevice()
        {
            var devices = Utils.GetUsbDevices();
            if (devices.Any())
            {
                var d = Utils.GetInitializedUsb(devices);
                if (d == null)
                {
                    var serverType = Utils.GetCurrentServerType();
                    if (serverType == 1)
                    {
                        MessageBox.Show("您的 USB 设备没有在客户端电脑进行过初始化，将无法在服务器端使用");
                    }
                    else if (serverType == 0)
                    {
                        Hide();
                        MessageBox.Show("您的 USB 设备还没有经过初始化，请先初始化您的设备");
                        initFrm = FrmDeploy.GetForm(this);
                        initFrm.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("没有找到移动存储设备（USB），请检查您的设备是否连接到这台电脑");
                this.Close();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStart.Text = "数据同步中，请稍后！";
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

                //string webAppDir = Utils.GetWebAppDir();
                //string webAppDir = Utils.GetServerUrl();

                //try
                //{
                //    //var port = Utils.GetWebAppPort();
                //    //webAppDir = Utils.GetWebAppDirectoryByPort(port);
                //    var appName = Utils.GetWebAppName();
                //    webAppDir = Utils.GetWebAppDirectoryByAppName(appName);
                //}
                //catch (COMException)
                //{
                //    MessageBox.Show("获取 webapp 目录失败，请尝试“关闭程序，然后以管理员身份运行此程序”");
                //    return;
                //}

                // 根据身份启动相应的程序进行数据同步
                usbSync.DoSync(serverType);
                MessageBox.Show("数据同步成功");
            }
            else
            {
                MessageBox.Show("没有找到可用于同步数据的 USB 设备，您的 USB 设备没有经过“USB 初始化工具”初始化");
            }
        }
        
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            ScanSyncDevice();
        }
    }
}
