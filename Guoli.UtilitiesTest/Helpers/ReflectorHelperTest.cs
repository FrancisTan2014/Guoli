using System;
using FluentAssertions;
using Guoli.Utilities.FileUpload;
using Guoli.Utilities.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.UtilitiesTest.Helpers
{
    [TestClass]
    public class ReflectorHelperTest
    {
        [TestMethod]
        public void TestGetInstance()
        {
            var instance = ReflectorHelper.GetInstance("Guoli.UtilitiesTest", "Guoli.UtilitiesTest.Helpers.TestClass");
            instance.Should()
                .BeOfType<TestClass>("because the fullname of the class is Guoli.UtilitiesTest.Helpers.TestClass");
        }

        [TestMethod]
        public void TestGetPropertyValue()
        {
            var testInstance = new TestClass { TestProp = "test success" };
            var propValue = ReflectorHelper.GetPropertyValue(testInstance, "TestProp");

            propValue.Should().NotBeNull("because I've given a value when create the instance")
                .And.Subject.ToString().Should().BeEquivalentTo("test success");
        }
    }
}
