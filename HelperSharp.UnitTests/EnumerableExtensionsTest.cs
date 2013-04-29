using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture()]
    public class EnumerableExtensionsTest
    {
        string[] fruitsArray = null;

        [SetUp]
        public void Initialize()
        {
            fruitsArray = new[] { "Laranja", "Banana", "Limão", "Maçã" };
        }

        [Test()]
        public void GetTypesTest()
        {
            var types = new object[] { 0, "1", 0.1, 0.1f, DateTime.Now }.GetTypes();

            Assert.AreEqual(5, types.Length);
            Assert.AreEqual(typeof(int), types[0]);
            Assert.AreEqual(typeof(string), types[1]);
            Assert.AreEqual(typeof(double), types[2]);
            Assert.AreEqual(typeof(float), types[3]);
            Assert.AreEqual(typeof(DateTime), types[4]);
        }

        [Test()]
        public void EachTest()
        {
            var fruits = String.Empty;

            fruitsArray.Each(f => fruits += f);

            Assert.AreEqual("LaranjaBananaLimãoMaçã", fruits);
        }

        [Test()]
        public void EachWithIndexTest()
        {
            var fruits = String.Empty;

            fruitsArray.Each((f, i) => fruits += fruitsArray[i]);

            Assert.AreEqual("LaranjaBananaLimãoMaçã", fruits);
        }

        [Test()]
        public void ToStringWithFunctionTest()
        {
            string fruitsUpper = fruitsArray.ToString(f => f.ToUpper());

            Assert.AreEqual("LARANJABANANALIMÃOMAÇÃ", fruitsUpper);
        }

        [Test()]
        public void ToStringWithFormat()
        {
            string fruits = fruitsArray.ToString("-{0}");

            Assert.AreEqual("-Laranja-Banana-Limão-Maçã", fruits);
        }

        [Test()]
        public void JoinTest()
        {
            string fruits = fruitsArray.Join(", ");

            Assert.AreEqual("Laranja, Banana, Limão, Maçã", fruits);
        }
    }
}
