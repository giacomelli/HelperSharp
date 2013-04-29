using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture()]
    public class ArrayExtensionsTest
    {
        [Test()]
        public void RemoveDuplicatesTest()
        {
            DateTime d = DateTime.Now;
            var objs = new object[] {0, "1", 0.1, 0.1f, d, "1", 1, 0.2, 0.2, 0.1f}.RemoveDuplicates();
           
            Assert.AreEqual(7, objs.Length);
            Assert.AreEqual(0, objs[0]);
            Assert.AreEqual("1", objs[1]);
            Assert.AreEqual(0.1, objs[2]);
            Assert.AreEqual(0.1f, objs[3]);
            Assert.AreEqual(d, objs[4]);
            Assert.AreEqual(1, objs[5]);
            Assert.AreEqual(0.2, objs[6]);
        }
    }
}
