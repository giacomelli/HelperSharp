using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace HelperSharp
{
    /// <summary>
    /// MD5 cryptography algorithm helpers.
    /// </summary>
    public static class MD5Helper
    {
        #region Fields
        private static Regex s_md5Regex = new Regex("[0-9a-f]{32}", RegexOptions.Compiled);
        #endregion

        /// <summary>
        /// Encrypt the specified string using MD5 algorithm.
        /// </summary>
        /// <param name="original">The string to be encrypt.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string original)
        {
            var result = original;

            if (!String.IsNullOrEmpty(original) && !IsEncrypted(original))
            {
                using (var md5 = MD5.Create())
                {
                    var data = md5.ComputeHash(Encoding.Default.GetBytes(original));

                    var builder = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                    {
                        builder.Append(data[i].ToString("x2", CultureInfo.InvariantCulture));
                    }

                    result = builder.ToString();
                }
            }

            return result;
        }

        /// <summary>
        /// Check if the specified string is encrypted using MD5.
        /// </summary>
        /// <param name="value">The encrypted string.</param>
        /// <returns>True if is MD5 encrypted, false otherwise.</returns>
        public static bool IsEncrypted(string value)
        {
            return s_md5Regex.IsMatch(value);
        }
    }
}
