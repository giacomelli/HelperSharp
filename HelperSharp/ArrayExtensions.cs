﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelperSharp
{
    /// <summary>
    /// Arrays extensions.
    /// </summary>
    public static class ArrayExtensions
    {
        #region Métodos
       /// <summary>
       /// Removes the duplicates.
       /// </summary>
       /// <returns>The duplicates.</returns>
       /// <param name="items">Items.</param>
       /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T[] RemoveDuplicates<T>(this T[] items)
        {
            List<T> uniqueItems = new List<T>();

            for (int i = 0; i < items.Length; i++)
            {
                if (!uniqueItems.Contains(items[i]))
                {
                    uniqueItems.Add(items[i]);
                }
            }

            return uniqueItems.ToArray();
        }
        #endregion
    }
}