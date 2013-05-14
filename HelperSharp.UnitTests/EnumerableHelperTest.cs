using NUnit.Framework;
using System;

namespace HelperSharp.UnitTests
{
	[TestFixture()]
	public class EnumerableHelperTest
	{
		[Test()]
		public void AreEqual_FirstSecondNulls_True ()
		{
			Assert.IsTrue(EnumerableHelper.AreEqual<string>(null, null));
		}

		[Test()]
		public void AreEqual_FirstNull_False ()
		{
			var second = new int[0];
			Assert.IsFalse(EnumerableHelper.AreEqual(null, second));
		}

		[Test()]
		public void AreEqual_SecondNull_False ()
		{
			var first = new int[0];
			Assert.IsFalse(EnumerableHelper.AreEqual(first, null));
		}

		[Test()]
		public void AreEqual_FirstAndSecondDiff_False ()
		{
			var first = new int[] { 1 };
			var second = new int[] { 1, 2 };
			Assert.IsFalse(EnumerableHelper.AreEqual(first, second));
		}

		[Test()]
		public void AreEqual_FirstAndSecondEqual_True ()
		{
			var first = new int[] { 1, 2 };
			var second = new int[] { 1, 2 };
			Assert.IsTrue(EnumerableHelper.AreEqual(first, second));
		}

		[Test()]
		public void CalculateHashCode_Null_DefaultValue ()
		{
			Assert.AreEqual(0, EnumerableHelper.CalculateHashCode(null));
		}

		[Test()]
		public void CalculateHashCode_Empty_DefaultValue ()
		{
			Assert.AreEqual(5, EnumerableHelper.CalculateHashCode(new int[0]));
		}

		[Test()]
		public void CalculateHashCode_Items_DefaultValue ()
		{
			Assert.AreNotEqual(5, EnumerableHelper.CalculateHashCode(new int[] { 1, 2 }));
		}
	}
}

