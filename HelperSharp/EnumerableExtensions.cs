using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HelperSharp
{
    /// <summary>
    /// Enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Gets the types of the specified objects.
        /// </summary>
        /// <returns>The types.</returns>
        /// <param name="objects">The objects.</param>
        public static Type[] GetTypes(this IEnumerable objects)
        {
            List<Type> parametersType = new List<Type>();

            if (objects != null)
            {
                foreach (object obj in objects)
                {
                    if (obj == null)
                    {
                        parametersType.Add(null);
                    }                    
                    else
                    {
                        parametersType.Add(obj.GetType());
                    }
                }
            }

            return parametersType.ToArray();
        }

        /// <summary>
        /// Iterates in the collection calling the action for each item.
        /// </summary>
        /// <param name="self">The enumerable it self.</param>
        /// <param name="action">The each action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Each<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self)
            {
                action(item);
            }
        }

        /// <summary>
        /// Iterates in the collection calling the action for each item using index.
        /// </summary>
        /// <param name="self">The enumerable it self.</param>
        /// <param name="action">The each action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Each<T>(this IEnumerable<T> self, Action<T, int> action)
        {
            var list = self.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                action(list[i], i);
            }
        }

        /// <summary>
        /// Iterates in the collection calling the action for each item and concatenating the result.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="self">The enumerable it self.</param>
        /// <param name="function">The ToString function.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static string ToString<T>(this IEnumerable<T> self, Func<T, object> function)
        {
            var result = new StringBuilder();

            self.Each(i => result.Append(function(i)));

            return result.ToString();
        }

        /// <summary>
        /// Iterates in the collection calling the action for each item using String.Format.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="self">The enumerable it self.</param>
        /// <param name="format">The string format.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static string ToString<T>(this IEnumerable<T> self, string format)
        {
            return self.ToString(i => String.Format(CultureInfo.InvariantCulture, format, i));
        }
    }
}