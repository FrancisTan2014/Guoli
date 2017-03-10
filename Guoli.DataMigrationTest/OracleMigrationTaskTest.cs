using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guoli.DataMigration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.DataMigrationTest
{
    [TestClass]
    public class OracleMigrationTaskTest
    {
        [TestMethod]
        public void TestExecuteDataSynchronization()
        {
            TestSuite.CleanTestDb();

            OracleMigrationTask.ExecuteDataSynchronization();
        }
    }
}
