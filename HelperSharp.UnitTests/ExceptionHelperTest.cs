using NUnit.Framework;
using System;

namespace HelperSharp.UnitTests
{
	[TestFixture()]
	public class ExceptionHelperTest
	{
		[Test()]
		public void ThrowIfNull_NotNull_NoException ()
		{
			ExceptionHelper.ThrowIfNull ("one", 1);
		}

		[Test()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ThrowIfNull_Null_Exception ()
		{
			ExceptionHelper.ThrowIfNull ("one", null);
		}
	}
}

