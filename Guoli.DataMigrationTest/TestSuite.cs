using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guoli.DbProvider;
using System.Data;

namespace Guoli.DataMigrationTest
{
    public class TestSuite
    {
        private static readonly string SqlConnectionString = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;

        public static void CleanTestDb()
        {
            var sql = @"
TRUNCATE TABLE DEPARTINFO;
TRUNCATE TABLE POSTS;
TRUNCATE TABLE PERSONINFO;
TRUNCATE TABLE DBUPDATELOG;
TRUNCATE TABLE OracleTableMaxId;
TRUNCATE TABLE PrimaryIdRelation;
TRUNCATE TABLE DRIVEPLAN;";

            var sqlHelper = DbHelperFactory.GetInstance(DatabaseType.SqlServer);
            sqlHelper.ExecuteNonQuery(SqlConnectionString, CommandType.Text, sql);
        }
    }
}
