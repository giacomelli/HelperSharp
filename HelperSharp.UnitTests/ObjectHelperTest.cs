using System;
using System.Collections.Generic;
using HelperSharp.UnitTests.Stubs;
using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture]
    public class ObjectHelperTest
    {
        [Test]
        public void IsNullOrDefault_Null_True()
        {
            Assert.IsTrue(ObjectHelper.IsNullOrDefault((string)null));
        }

        [Test]
        public void IsNullOrDefault_IsNotNull_False()
        {
            Assert.IsFalse(ObjectHelper.IsNullOrDefault("1"));
        }

        [Test]
        public void IsNullOrDefault_Default_True()
        {
            Assert.IsTrue(ObjectHelper.IsNullOrDefault(0));
            Assert.IsTrue(ObjectHelper.IsNullOrDefault(false));
            Assert.IsTrue(ObjectHelper.IsNullOrDefault(0.0));            
        }

        [Test]
        public void IsNullOrDefault_IsNotDefault_False()
        {
            Assert.IsFalse(ObjectHelper.IsNullOrDefault(1));
            Assert.IsFalse(ObjectHelper.IsNullOrDefault(true));
            Assert.IsFalse(ObjectHelper.IsNullOrDefault(0.1));
        }

        [Test]
        public void IsNullOrDefault_NullNullables_True()
        {
            int? i = null;
            bool? b = null; 
            Assert.IsTrue(ObjectHelper.IsNullOrDefault(i));
            Assert.IsTrue(ObjectHelper.IsNullOrDefault(b));
        }

        [Test]
        public void IsNullOrDefault_IsNotNullNullables_False()
        {
            int? i = 1;
            bool? b = true;
            Assert.IsFalse(ObjectHelper.IsNullOrDefault(i));
            Assert.IsFalse(ObjectHelper.IsNullOrDefault(b));
        }

        [Test]
        public void IsNullOrDefault_EmptyString_True()
        {
            Assert.IsTrue(ObjectHelper.IsNullOrDefault(""));
        }

        [Test]
        public void IsNullOrDefault_EmptyCollection_True()
        {
            Assert.IsTrue(ObjectHelper.IsNullOrDefault(new List<int>()));
        }

        [Test]
        public void IsNullOrDefault_IsNotEmptyCollection_False()
        {
            Assert.IsFalse(ObjectHelper.IsNullOrDefault(new int[] { 1 }));
        }

        [Test]
        public void IsNullOrDefault_EnumDefaultValue_True()
        {
            Assert.IsTrue(ObjectHelper.IsNullOrDefault(DayOfWeek.Sunday));
        }

        [Test]
        public void IsNullOrDefault_EnumIsNotDefaultValue_True()
        {
            Assert.IsFalse(ObjectHelper.IsNullOrDefault(DayOfWeek.Monday));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateShallowCopy_Null_Exception()
        {
            ObjectHelper.CreateShallowCopy(null);
        }

        [Test]
        public void CreateShallowCopy_Source_OnlyWritablePropertiesCopied()
        {
            var source = new Stub1() {
                Property1 = 11,
                Property3 = 33
            };

            var actual = ObjectHelper.CreateShallowCopy(source) as Stub1;
            Assert.IsNotNull(actual);
            Assert.IsFalse(Object.ReferenceEquals(source, actual));
            Assert.AreEqual(11, actual.Property1);
            Assert.AreEqual(33, actual.Property3);
        }
    }
}