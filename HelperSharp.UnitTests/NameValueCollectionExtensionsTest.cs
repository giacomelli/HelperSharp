using System;
using System.Collections.Specialized;
using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture]
    public class NameValueCollectionExtensionsTest
    {
        #region Fields
        private NameValueCollection m_target;
        #endregion

        #region Initialize
        [TestFixtureSetUp]
        public void InitializeFixture()
        {
            m_target = new NameValueCollection();
            m_target.Add("booleanTrue", "true");
            m_target.Add("booleanFalse", "false");
            m_target.Add("int32", "123");
            m_target.Add("single", "1.23");
        }
        #endregion


        #region Tests
        [Test]
        public void GetBoolean_Name_Boolean()
        {
            Assert.IsTrue(m_target.GetBoolean("booleanTrue"));
            Assert.IsFalse(m_target.GetBoolean("booleanFalse"));
        }

        [Test]
        public void GetInt32_Name_Int32()
        {
            Assert.AreEqual(123, m_target.GetInt32("int32"));
        }

        [Test]
        public void GetSingle_Name_Single()
        {
            Assert.AreEqual(1.23f, m_target.GetSingle("single"));
        }
        #endregion
    }
}