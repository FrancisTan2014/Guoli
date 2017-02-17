using FluentAssertions;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.AdminTest.Utilities
{
    [TestClass]
    public class BllFactoryTest
    {
        [TestMethod]
        public void TestGetBllInstance()
        {
            var bllInstance = BllFactory.GetBllInstance("DepartInfo");
            bllInstance.Should().BeOfType<DepartInfoBll>("because the table name is DepartInfo");
        }
    }
}
