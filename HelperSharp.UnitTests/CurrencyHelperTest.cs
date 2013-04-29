using NUnit.Framework;
using System;

namespace HelperSharp.UnitTests
{
	[TestFixture()]
	public class CurrencyHelperTest
	{
		[Test()]
		public void IsValidISOCurrencySymbol_Null_False ()
		{
			Assert.IsFalse(CurrencyHelper.IsValidISOCurrencySymbol(null));
		}

		[Test()]
		public void IsValidISOCurrencySymbol_Invalid_False ()
		{
			Assert.IsFalse(CurrencyHelper.IsValidISOCurrencySymbol(""));
			Assert.IsFalse(CurrencyHelper.IsValidISOCurrencySymbol("123"));
		}

		[Test()]
		public void IsValidISOCurrencySymbol_Valid_True ()
		{
			Assert.IsTrue(CurrencyHelper.IsValidISOCurrencySymbol("USD"));
			Assert.IsTrue(CurrencyHelper.IsValidISOCurrencySymbol("BRL"));
		}
	}
}