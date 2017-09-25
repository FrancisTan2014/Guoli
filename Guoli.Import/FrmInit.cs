using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Guoli.DbProvider;
using Guoli.Utilities.Extensions;

namespace Guoli.Import
{
    public partial class FrmInit : Form
    {
        public FrmInit()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ConnectDb();
        }

        private void ConnectDb()
        {
            cbDbList.DataSource = new List<string>();

            var model = GetModel();
            if (model.IsValid(out string msg))
            {
                List<string> dbList;
                btnTest.Text = "正在连接数据库...";
                try
                {
                    dbList = model.GetDbList();
                    cbDbList.DataSource = dbList;
                }
                catch
                {
                    MessageBox.Show("数据库连接失败(:=");
                }
                btnTest.Text = "测试连接";
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private ConnectionModel GetModel()
        {
            var model = new ConnectionModel
            {
                Server = txtServer.Text.Trim(),
                Account = txtAccount.Text.Trim(),
                Password = txtPassword.Text,
                InitialCatalog = cbDbList.SelectedValue?.ToString()
            };

            return model;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var model = GetModel();
            if (model.IsValid(out string msg))
            {
                if (model.InitialCatalog.IsNullOrEmpty())
                {
                    ConnectDb();
                    MessageBox.Show("请选择数据库(:=");
                }
                else
                {
                    if (model.InitialCatalog.IsNullOrEmpty())
                    {
                        MessageBox.Show("请选择数据库(:=");
                    }
                    else
                    {
                        try
                        {
                            var tables = model.GetTables();

                            if (tables.Contains("DriveRecords"))
                            {
                                this.Hide();
                                ChangeConfig(model.ConnectionString);
                                var frmMain = new frmImport();
                                frmMain.Show();
                            }
                            else
                            {
                                MessageBox.Show("您选择不是本系统的数据库，请重新选择(:=");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("数据库连接失败(:=");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(msg);
            }

        }

        private void ChangeConfig(string connStr)
        {
            var path = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            var doc = new XmlDocument();
            doc.Load(path);
            var node = doc.SelectSingleNode("//connectionStrings/add[@name='MainDb']");
            if (node != null)
            {
                node.Attributes["connectionString"].Value = connStr;
                doc.Save(path);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            else
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("MainDb", connStr));
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

    }

    class ConnectionModel
    {
        public string Server { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string InitialCatalog { get; set; }

        public string ConnectionString => $"Password={Password};User ID={Account};Initial Catalog={InitialCatalog};Data Source={(Server.IsNullOrEmpty() ? "master" : Server)}";

        public bool IsValid(out string msg)
        {
            msg = string.Empty;
            if (Server.IsNullOrEmpty())
            {
                msg = "服务器地址不能为空(:=";
                return false;
            }

            if (Account.IsNullOrEmpty())
            {
                msg = "登录名不能为空(:=";
                return false;
            }

            if (Password.IsNullOrEmpty())
            {
                msg = "密码不能为空";
                return false;
            }

            return true;
        }

        public List<string> GetDbList()
        {
            var sql = "select name from sysdatabases order by name";
            return GetSingleColumns(sql);
        }

        public List<string> GetTables()
        {
            var sql = "select [name] from sysobjects where xtype='U'and [name]<>'dtproperties' order by [name]";
            return GetSingleColumns(sql);
        }

        private List<string> GetSingleColumns(string sql)
        {
            var list = new List<string>();
            var sqlHelper = new SqlHelper();

            var reader = sqlHelper.ExecuteReader(ConnectionString, CommandType.Text, sql);
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }

            return list;
        }
    }
}
