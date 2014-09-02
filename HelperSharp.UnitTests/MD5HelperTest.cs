using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture()]
    public class MD5HelperTest
    {
        [Test]
        public void Encrypt_NewOriginalString_Encrypted()
        {
            var actual = MD5Helper.Encrypt("abc123*");
            Assert.AreNotEqual("abc123*", actual);
            Assert.AreEqual(actual, MD5Helper.Encrypt("abc123*")); // Should generate the same value.
        }

        [Test]
        public void Encrypt_AlreadyEncryptedString_DoNothing()
        {
            var actual = MD5Helper.Encrypt("abc123*");
            Assert.AreEqual(actual, MD5Helper.Encrypt(actual)); // Can encrypt again.
        }

        [Test]
        public void IsEncrypted_NoEncryptedString_False()
        {
            Assert.IsFalse(MD5Helper.IsEncrypted("abc123*"));
        }

        [Test]
        public void IsEncrypted_EncryptedString_True()
        {
            var value = MD5Helper.Encrypt("abc123*");
            Assert.IsTrue(MD5Helper.IsEncrypted(value));
        }
    }
}