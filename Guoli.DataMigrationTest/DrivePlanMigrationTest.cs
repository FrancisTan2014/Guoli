using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Guoli.Bll;
using Guoli.DataMigration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.DataMigrationTest
{
    [TestClass]
    public class DrivePlanMigrationTest
    {
        [TestMethod]
        public void TestImportNewDataAsync()
        {
            TestSuite.CleanTestDb();

            var instance = new DrivePlanMigration();
            instance.ImportNewData();

            var bll = new DrivePlanBll();
            var list = bll.QueryList(null, new[] { "Id" });
            list.Count().Should().Be(322513);
        }
    }
}
