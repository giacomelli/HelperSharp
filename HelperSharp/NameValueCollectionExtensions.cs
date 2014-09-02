using System;
using System.Collections.Specialized;
using System.Globalization;

namespace HelperSharp
{
    /// <summary>
    /// NameValueCollection extensions.
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Gets a boolean value with the specified name.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The name of value.</param>
        /// <returns>The boolean value.</returns>
        public static bool GetBoolean(this NameValueCollection collection, string name)
        {
            return Convert.ToBoolean(collection[name], CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets a integer value with the specified name.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The name of value.</param>
        /// <returns>The integer value.</returns>
        public static int GetInt32(this NameValueCollection collection, string name)
        {
            return Convert.ToInt32(collection[name], CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets a single value with the specified name.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The name of value.</param>
        /// <returns>The single value.</returns>
        public static float GetSingle(this NameValueCollection collection, string name)
        {
            return Convert.ToSingle(collection[name], CultureInfo.InvariantCulture);
        }
    }
}
