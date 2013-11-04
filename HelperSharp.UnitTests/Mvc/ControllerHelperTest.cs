using System;
using System.Web.Mvc;
using HelperSharp.Mvc;
using HelperSharp.UnitTests.Mvc.Stubs;
using NUnit.Framework;

namespace HelperSharp.UnitTests.Mvc
{
    [TestFixture]
    public class ControllerHelperTest
    {
        [Test]
        public void GetControllerTypes_NoArgs_AllConcreteControllers()
        {
            var actual = ControllerHelper.GetControllerTypes();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(typeof(StubConcreteController), actual[0]);
        }

        [Test]
        public void GetActionsDescriptors_NoArgs_AllActions()
        {
            var actual = ControllerHelper.GetActionsDescriptors<StubConcreteController>();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("Index", actual[0].ActionName);
            Assert.AreEqual("Create", actual[1].ActionName);
        }

        [Test]
        public void GetActionsDescriptors_WithCustomAttribute_ActionsWithCustomAttribute()
        {
            var actual = ControllerHelper.GetActionsDescriptors<StubConcreteController, AuthorizeAttribute>();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("Create", actual[0].ActionName);
        }
    }
}