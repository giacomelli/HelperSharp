using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using HelperSharp;

namespace HelperSharp.UnitTests
{
    [TestFixture()]
    public class DateTimeExtensionsTest
    {
        [Test()]
        public void GetBeginOfMonthTest()
        {
            var expected = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date;
            Assert.AreEqual(expected, DateTime.Now.GetBeginOfMonth());

            expected = new DateTime(2011, 07, 1, 0, 0, 0, 0);
            Assert.AreEqual(expected, new DateTime(2011, 07, 28, 15, 21, 1, 2).GetBeginOfMonth());
        }

        [Test()]
        public void GetEndOfMonthTest()
        {
            var y = DateTime.Now.Year;
            var m = DateTime.Now.Month;
            var expected = new DateTime(y, m, DateTime.DaysInMonth(y, m), 23, 59, 59, 999);
            Assert.AreEqual(expected, DateTime.Now.GetEndOfMonth());

            expected = new DateTime(2011, 07, 31, 23, 59, 59, 999);
            Assert.AreEqual(expected, new DateTime(2011, 07, 28, 15, 21, 1, 2).GetEndOfMonth());
        }

        [Test()]
        public void GetBeginOfDayTest()
        {
            Assert.AreEqual(new DateTime(1981, 3, 27, 0, 0, 0, 0), new DateTime(1981, 3, 27, 3, 3, 3, 999).GetBeginOfDay());
        }

        [Test()]
        public void GetEndOfDayTest()
        {
            Assert.AreEqual(new DateTime(1981, 3, 28, 0, 0, 0, 0).AddTicks(-1), new DateTime(1981, 3, 27, 3, 3, 3, 999).GetEndOfDay());
        }
    }
}
