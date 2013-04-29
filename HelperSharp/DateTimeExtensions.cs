using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperSharp
{
    /// <summary>
    /// Date time extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        #region Métodos
        /// <summary>
        /// Gets the begin of month.
        /// </summary>
        /// <returns>The begin of month.</returns>
        /// <param name="value">Value.</param>
        public static DateTime GetBeginOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the end of month.
        /// </summary>
        /// <returns>The end of month.</returns>
        /// <param name="value">Value.</param>
        public static DateTime GetEndOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month), 23, 59, 59, 999);
        }
        #endregion
    }
}
