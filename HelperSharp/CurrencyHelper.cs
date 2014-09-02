using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
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
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);

                            return null;
                        }
                    })
                    .Where(ri => ri != null)
                    .Select(ri => ri.ISOCurrencySymbol).ToList();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Determines if is valid ISO currency symbol.
        /// </summary>
        /// <returns><c>true</c> if is valid ISO currency symbol; otherwise, <c>false</c>.</returns>
        /// <param name="symbol">The symbol to validate.</param>
        public static bool IsValidIsoCurrencySymbol(string symbol)
        {
            return s_isoCurrencySymbols.Count(i => i.Equals(symbol, StringComparison.Ordinal)) > 0;
        }
        #endregion
    }
}