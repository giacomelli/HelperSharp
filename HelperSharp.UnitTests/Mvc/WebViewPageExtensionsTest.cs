using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using HelperSharp.UnitTests.Mvc.Stubs;
using NUnit.Framework;
using HelperSharp.Mvc;

namespace HelperSharp.UnitTests.Mvc
{
    [TestFixture]
    public class WebViewPageExtensionsTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))] 
        public void GetPath_ViewContextNull_Exception()
        {
            var page = new StubPage1();
            Assert.IsNotNull(page.GetPath());
        }

        [Test]
        public void GetPath_ViewContext_Path()
        {
            var page = new StubPage1();
            page.ViewContext = new ViewContext() { View = new RazorView(new ControllerContext(), "path/view.cshtml", "", false, new string[0]) };
            Assert.AreEqual("path/view.cshtml", page.GetPath());
        }
    }
}
