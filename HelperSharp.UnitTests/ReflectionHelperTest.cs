using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using System.Globalization;
using HelperSharp.UnitTests.Stubs;

namespace HelperSharp.UnitTests
{
    [TestFixture]
    public class ReflectionHelperTest
    {        
        #region Instância
        [Test]
        public void GetPropertyTest()
        {
            PropertyInfo p = ReflectionHelper.GetProperty(typeof(DateTime), "Hour");

            Assert.AreEqual("Hour", p.Name);
            Assert.AreEqual(typeof(int), p.PropertyType);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "The property 'Agora' was not found on type 'System.DateTime'.", MatchType = MessageMatch.Contains)]
        public void GetPropertyNotFoundTest()
        {
            ReflectionHelper.GetProperty(typeof(DateTime), "Agora");
        }

        [Test]
        public void GetPropertyValueTest()
        {
            object value = ReflectionHelper.GetPropertyValue(DateTime.Now, "Year");

            Assert.AreEqual(DateTime.Now.Year, value);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvokeMethodNotFoundMethodTest()
        {
            ReflectionHelper.InvokeMethod(DateTime.Now, "ToText");
        }

        [Test]
        public void InvokeMethodTest()
        {
            var date = DateTime.Now;
            var actual = ReflectionHelper.InvokeMethod(DateTime.Now, "ToShortDateString");
            Assert.AreEqual(date.ToShortDateString(), actual);

            actual = ReflectionHelper.InvokeMethod(DateTime.Now, "ToString", "dd/MM/yyyy", CultureInfo.CurrentCulture);
            Assert.AreEqual(date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture), actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetSubclassesOf_NullType_Exception()
        {
            ReflectionHelper.GetSubclassesOf(null);
        }

        [Test]
        public void GetSubclassesOf_TypeAndOnlyConcreteTrue_OnlyConcreteSubclasses()
        {            
            var actual = ReflectionHelper.GetSubclassesOf(typeof(IStub), true);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(typeof(Stub1), actual[0]);
            Assert.AreEqual(typeof(Stub2), actual[1]);

            actual = ReflectionHelper.GetSubclassesOf(typeof(StubBase), true);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(typeof(Stub1), actual[0]);            
        }

        [Test]
        public void GetSubclassesOf_TypeAndOnlyConcreteFalse_AllSubclasses()
        {
            var actual = ReflectionHelper.GetSubclassesOf(typeof(IStub), false);
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(typeof(Stub1), actual[0]);
            Assert.AreEqual(typeof(Stub2), actual[1]);
            Assert.AreEqual(typeof(StubBase), actual[2]);

            actual = ReflectionHelper.GetSubclassesOf(typeof(StubBase), false);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(typeof(Stub1), actual[0]);            
        }
        #endregion
    }
}
