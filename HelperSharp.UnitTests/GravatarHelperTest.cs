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

        [Test()]
        public void GetAvatarUrl_OnlyEmail_Url()
        {
            var expected = GravatarHelper.GetAvatarUrl("giacomelli@gmail.com");
            Assert.AreEqual("http://www.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg", expected);
        }

        [Test()]
        public void GetAvatarUrl_EmailAndSize_Url()
        {
            var expected = GravatarHelper.GetAvatarUrl("giacomelli@gmail.com", 32);
            Assert.AreEqual("http://www.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg?s=32", expected);
        }

        [Test()]
        public void GetAvatarUrl_EmailAndDefaultImage_Url()
        {
            var expected = GravatarHelper.GetAvatarUrl("giacomelli@gmail.com", defaultImage: "blank");
            Assert.AreEqual("http://www.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg?d=blank", expected);
        }

        [Test()]
        public void GetAvatarUrl_EmailAndForceDefaultImage_Url()
        {
            var expected = GravatarHelper.GetAvatarUrl("giacomelli@gmail.com", forceDefaultImage: true);
            Assert.AreEqual("http://www.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg?f=y", expected);
        }

        [Test()]
        public void GetAvatarUrl_EmailAndRating_Url()
        {
            var expected = GravatarHelper.GetAvatarUrl("giacomelli@gmail.com", rating: "pg");
            Assert.AreEqual("http://www.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg?r=pg", expected);
        }

        [Test()]
        public void GetAvatarUrl_EmailAndSecureRequest_Url()
        {
            var expected = GravatarHelper.GetAvatarUrl("giacomelli@gmail.com", secureRequest: true);
            Assert.AreEqual("http://secure.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg", expected);
        }

        [Test()]
        public void GetAvatarUrl_EmailAndAllOptions_Url()
        {
            var expected = GravatarHelper.GetAvatarUrl("giacomelli@gmail.com", 64, "mm", true, "x", true);
            Assert.AreEqual("http://secure.gravatar.com/avatar/c5c70a93a2b605756df1af5da0dd413f.jpg?s=64&d=mm&f=y&r=x", expected);
        }
    }
}

