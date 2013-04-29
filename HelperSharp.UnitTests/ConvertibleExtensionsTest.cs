using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture()]
    public class ConvertibleExtensions
    {
        [Test()]
        public void ConvertToAnotherTypeTest()
        {
            Assert.AreEqual(318, "318".To<int>());

            Assert.AreEqual(DateTime.Today, DateTime.Today.ToShortDateString().To<DateTime>());
        }
    }
}