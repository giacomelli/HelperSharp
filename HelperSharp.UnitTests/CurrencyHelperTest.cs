using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture()]
    public class CurrencyHelperTest
    {
        [Test()]
        public void IsValidISOCurrencySymbol_Null_False()
        {
            Assert.IsFalse(CurrencyHelper.IsValidIsoCurrencySymbol(null));
        }

        [Test()]
        public void IsValidISOCurrencySymbol_Invalid_False()
        {
            Assert.IsFalse(CurrencyHelper.IsValidIsoCurrencySymbol(""));
            Assert.IsFalse(CurrencyHelper.IsValidIsoCurrencySymbol("123"));
        }

        [Test()]
        public void IsValidISOCurrencySymbol_Valid_True()
        {
            Assert.IsTrue(CurrencyHelper.IsValidIsoCurrencySymbol("USD"));
            Assert.IsTrue(CurrencyHelper.IsValidIsoCurrencySymbol("BRL"));
        }
    }
}