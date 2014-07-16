using System;
using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture]
    public class ExpressionHelperTest
    {
        [Test]
        public void GetMemberExpression_NotMemberExpression_Null()
        {
            var actual = ExpressionHelper.GetMemberExpression<DateTime>(d => true);
            Assert.IsNull(actual);
        }

        [Test]
        public void GetMemberExpression_PropertyExpression_MemberExpression()
        {
            var actual = ExpressionHelper.GetMemberExpression<DateTime>(d => d.Day);
            Assert.IsNotNull(actual);
            Assert.AreEqual("Day", actual.Member.Name);
        }
    }
}
