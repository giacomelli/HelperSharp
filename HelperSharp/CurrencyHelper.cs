using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HelperSharp
{
    /// <summary>
    /// Currency helper.
    /// </summary>
    public static class CurrencyHelper
    {
        #region Fields
        private static List<string> s_isoCurrencySymbols;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes static members of the <see cref="HelperSharp.CurrencyHelper"/> class.
        /// </summary>
        static CurrencyHelper()
        {
            s_isoCurrencySymbols = CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                    .Where(c => !c.IsNeutralCulture)
                    .Select(culture =>
                    {
                        try
                        {
                            return new RegionInfo(culture.LCID);
                        }
                        catch
                        {
                            return null;
                        }
                    })
                    .Where(ri => ri != null)
                    .Select(ri => ri.ISOCurrencySymbol).ToList();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Determines if is valid ISO currency symbol
        /// </summary>
        /// <returns><c>true</c> if is valid ISO currency symbol; otherwise, <c>false</c>.</returns>
        /// <param name="symbol">The symbol to validate.</param>
        public static bool IsValidISOCurrencySymbol(string symbol)
        {
            return s_isoCurrencySymbols.Count(i => i.Equals(symbol, StringComparison.InvariantCulture)) > 0;
        }
        #endregion
    }
}