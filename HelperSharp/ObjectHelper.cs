using System;
using System.Collections;

namespace HelperSharp
{
    /// <summary>
    /// Object helper.
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// Check if argument is null or default value of T type.
        /// <remarks>
        /// Original source code from: http://stackoverflow.com/a/6553276/956886 .
        /// </remarks>
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="argument">The argument value.</param>
        /// <returns>True if is null or default.</returns>
        public static bool IsNullOrDefault<T>(T argument)
        {
            // Deal with normal scenarios.
            if (argument == null)
            {
                return true;
            }

            if (object.Equals(argument, default(T)))
            {
                return true;
            }

            // Deal with non-null nullables
            var methodType = typeof(T);
            if (Nullable.GetUnderlyingType(methodType) != null)
            {
                return false;
            }

            var argumentType = argument.GetType();

            // Deal with strings.
            if (argumentType == typeof(string) && (argument as string) == String.Empty)
            {
                return true;
            }

            // Deal with collections.
            if (typeof(ICollection).IsAssignableFrom(argumentType) && (argument as ICollection).Count == 0)
            {
                return true;
            }

            // Deal with boxed value types            
            if (argumentType.IsValueType && argumentType != methodType)
            {
                object obj = Activator.CreateInstance(argument.GetType());
                return obj.Equals(argument);
            }

            return false;
        }
    }
}
