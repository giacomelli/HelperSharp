using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

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
        /// <param name="self">The convertible it self.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>The converted.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static T To<T>(this IConvertible self)
        {
            try
            {
                return (T)Convert.ChangeType(self, typeof(T), CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(T);
            }
        }
    }
}
