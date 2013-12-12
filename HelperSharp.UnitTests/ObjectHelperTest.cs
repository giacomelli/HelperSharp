using System;
using System.Collections.Generic;
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
    }
}