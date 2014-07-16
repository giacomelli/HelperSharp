using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HelperSharp
{
    /// <summary>
    /// Enumerable helper.
    /// </summary>
    public static class EnumerableHelper
    {
        /// <summary>
        /// Verify if collections are equal comparing each item. Order is considered.
        /// </summary>
        /// <returns><c>true</c>, if are equal, <c>false</c> otherwise.</returns>
        /// <param name="first">The first enumerable to compare.</param>
        /// <param name="second">The second enumerable to compare..</param>
        /// <typeparam name="TType">The 1st type parameter.</typeparam>
        public static bool AreEqual<TType>(IEnumerable<TType> first, IEnumerable<TType> second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            return first.SequenceEqual(second);
        }

        /// <summary>
        /// Calculates the hash code using all items.
        /// </summary>
        /// <returns>The hash code.</returns>
        /// <param name="items">The items.</param>
        public static int CalculateHashCode(IEnumerable items)
        {
            unchecked
            {
                int hash = 0;

                if (items != null)
                {
                    hash = 5;

                    foreach (var item in items)
                    {
                        hash = (hash * 29) + item.GetHashCode();
                    }
                }

                return hash;
            }
        }
    }
}
