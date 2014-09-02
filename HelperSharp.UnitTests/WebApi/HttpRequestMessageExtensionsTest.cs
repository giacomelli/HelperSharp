using System;
using System.Net.Http;
using HelperSharp.WebApi;
using NUnit.Framework;

namespace HelperSharp.UnitTests.WebApi
{
    [TestFixture()]
    public class HttpRequestMessageExtensionsTest
    {
        [Test()]
        public void IsLocal_NoMS_IsLocalProperty_False()
        {
            var request = new HttpRequestMessage();
            Assert.IsFalse(request.IsLocal());
        }

        [Test()]
        public void IsLocal_MS_IsLocalPropertyFalse_False()
        {
            var request = new HttpRequestMessage();
            request.Properties.Add("MS_IsLocal", new Lazy<bool>(() => false));

            Assert.IsFalse(request.IsLocal());
        }

        [Test()]
        public void IsLocal_MS_IsLocalPropertyTrue_True()
        {
            var request = new HttpRequestMessage();
            request.Properties.Add("MS_IsLocal", new Lazy<bool>(() => true));


            Assert.IsTrue(request.IsLocal());
        }
    }
}
