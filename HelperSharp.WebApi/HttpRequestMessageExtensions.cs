using System;
using System.Net.Http;

namespace HelperSharp.WebApi
{
    /// <summary>
    /// HttpRequestMessage extension methods.
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        /// Check if is a local request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>True if is a local request.</returns>
        public static bool IsLocal(this HttpRequestMessage request)
        {
            var properties = request.Properties;
            var localFlag = properties.ContainsKey("MS_IsLocal") ? properties["MS_IsLocal"] as Lazy<bool> : null;

            return localFlag != null && localFlag.Value;
        }
    }
}
