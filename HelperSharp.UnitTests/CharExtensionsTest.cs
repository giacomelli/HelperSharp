using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture()]
    public class CharExtensionsTest
    {
        [Test()]
        public void HasAccentTest()
        {
            Assert.IsFalse('a'.HasAccent());
            Assert.IsFalse('e'.HasAccent());
            Assert.IsFalse('i'.HasAccent());
            Assert.IsFalse('o'.HasAccent());
            Assert.IsFalse('u'.HasAccent());
            Assert.IsFalse('b'.HasAccent());

            Assert.IsTrue('á'.HasAccent());
            Assert.IsTrue('É'.HasAccent());
            Assert.IsTrue('ì'.HasAccent());
            Assert.IsTrue('Ó'.HasAccent());
            Assert.IsTrue('Ú'.HasAccent());
            Assert.IsTrue('â'.HasAccent());
            Assert.IsTrue('ã'.HasAccent());
        }
    }
}
