using System.Linq;

namespace HelperSharp
{
    /// <summary>
    /// Char extensions.
    /// </summary>
    public static class CharExtensions
    {
        #region Métodos
        /// <summary>
        /// Determines if char is an accent.
        /// </summary>
        /// <returns><c>true</c> if char is an accent; otherwise, <c>false</c>.</returns>
        /// <param name="value">The char.</param>
        public static bool HasAccent(this char value)
        {
            return "áàãâäéèêëíìóòõôöúùûüñçÁÀÃÂÄÉÈÊËÍÌÓÒÕÔÖÚÙÛÜÑÇ".Contains(value);
        }
        #endregion
    }
}
