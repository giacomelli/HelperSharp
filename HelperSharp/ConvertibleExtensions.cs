using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperSharp
{
	/// <summary>
	/// Convertible extensions.
	/// </summary>
    public static class ConvertibleExtensions
    {
        /// <summary>
        /// Converts the type to specified T.
        /// </summary>
        /// <param name="self">Self.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T To<T>(this IConvertible self)
        {
            try
            {
                return (T) Convert.ChangeType(self, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
