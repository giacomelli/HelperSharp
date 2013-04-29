using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;
using System.Globalization;

namespace HelperSharp
{
    /// <summary>
    /// Enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        #region GetTypes
		/// <summary>
		/// Gets the types of the specified objects.
		/// </summary>
		/// <returns>The types.</returns>
		/// <param name="objects">Objects.</param>
        public static Type[] GetTypes(this IEnumerable objects)
        {
            // Coleta os tipos dos objetos.
            List<Type> parametersType = new List<Type>();

            // Se a lista de objetos não for nula.
            if (objects != null)
            {
                foreach (object obj in objects)
                {
                    // Se for null, então não tem tipo.
                    if (obj == null)
                    {
                        parametersType.Add(null);
                    }
                    // Adiciona o tipo para o array de retorno.
                    else
                    {
                        parametersType.Add(obj.GetType());
                    }
                }
            }

            // Retorna o array de tipos.
            return parametersType.ToArray();
        }
        #endregion

        #region Each
		/// <summary>
		/// Iterates in the collection calling the action for each item.
		/// </summary>
		/// <param name="self">Self.</param>
		/// <param name="action">Action.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Each<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self) action(item);
        }

        #endregion

        #region Each (with index)
		/// <summary>
		/// Iterates in the collection calling the action for each item using index.
		/// </summary>
		/// <param name="self">Self.</param>
		/// <param name="action">Action.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Each<T>(this IEnumerable<T> self, Action<T, int> action)
        {
            var list = self.ToList();

            for (int i = 0; i < list.Count; i++) action(list[i], i);
        }

        #endregion

        #region ToString (function)
		/// <summary>
		/// Iterates in the collection calling the action for each item and concatenating the result.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="self">Self.</param>
		/// <param name="function">Function.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
        public static string ToString<T>(this IEnumerable<T> self, Func<T, object> function)
        {
            var result = new StringBuilder();

            self.Each(i => result.Append(function(i)));

            return result.ToString();
        }

        #endregion

        #region ToString (format)
		/// <summary>
		/// Iterates in the collection calling the action for each item using String.Format.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="self">Self.</param>
		/// <param name="format">Format.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
        public static string ToString<T>(this IEnumerable<T> self, string format)
        {
            return self.ToString(i => String.Format(CultureInfo.InvariantCulture, format, i));
        }

        #endregion

        #region Join
       /// <summary>
		/// Iterates in the collection calling the action for each item concatenating a separator.
       /// </summary>
       /// <param name="self">Self.</param>
       /// <param name="separator">Separator.</param>
       /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static string Join<T>(this IEnumerable<T> self, string separator)
        {
            return String.Join(separator, values: self.ToArray());
        }
        #endregion
    }
}
