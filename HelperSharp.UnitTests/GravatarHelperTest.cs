using NUnit.Framework;
using System;

namespace HelperSharp.UnitTests
{
    [TestFixture ()]
    public class GravatarHelperTest
    {
        [Test ()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetAvatarUrl_NullOrEmpty_Exception ()
        {
			GravatarHelper.GetAvatarUrl (null);
        }

		[Test ()]
		public void GetAvatarUrl_ManyEmailFormats_Url ()
		{
			var expected = GravatarHelper.GetAvatarUrl ("giacomelli@gmail.com");
			Assert.AreEqual ("http://www.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg", expected);

			expected = GravatarHelper.GetAvatarUrl ("GIACOMELLI@gmail.com");
			Assert.AreEqual ("http://www.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg", expected);

			expected = GravatarHelper.GetAvatarUrl (" GIACOMELLI@gmail.com ");
			Assert.AreEqual ("http://www.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg", expected);
		}
    }
}

