using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Guoli.DbProvider;

namespace Guoli.WebTest.DbProviderTest
{
    public partial class connect_db : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region SqlServer
            //var dbHelper = new DbHelper(DatabaseType.SqlServer);
            //var connectionString = ConfigurationManager.ConnectionStrings["MSSQLSERVER"].ToString();
            //var cmdText = "SELECT * FROM Articles";
            //var dataTable = dbHelper.ExecuteDataTable(connectionString, CommandType.Text, cmdText);

            //TestDb.DataSource = dataTable;
            //TestDb.DataBind(); 
            #endregion

            #region Oracle

            var dbHelper = DbHelperFactory.GetInstance(DatabaseType.Oracle);
            var connectionString = ConfigurationManager.ConnectionStrings["ORACLE"].ToString();
            var cmdText = "SELECT * FROM v计划";
            var dataTable = dbHelper.ExecuteDataTable(connectionString, CommandType.Text, cmdText);

            TestDb.DataSource = dataTable;
            TestDb.DataBind();
            #endregion
        }
    }
}