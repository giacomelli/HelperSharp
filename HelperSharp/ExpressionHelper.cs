using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace HelperSharp
{
    /// <summary>
    /// Expression helpers.
    /// </summary>
    public static class ExpressionHelper
    {
        /// <summary>
        /// Gets a member expression from the expression.
        /// </summary>
        /// <sample>
        /// This method is useful when we want to map a property from a type, like this:
        /// var expression = ExpressionHelper.GetMemberExpression&lt;DateTime&gt;>(d => d.Day);
        /// var memberName = expression.Member.Name; // "Day";
        /// </sample>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="expression">The expression to get the member.</param>
        /// <returns>The MemberExpression if the specified expression is a MemberExpression, otherwise false.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static MemberExpression GetMemberExpression<TTarget>(Expression<Func<TTarget, object>> expression)
        {
            var result = expression.Body as MemberExpression;

            if (result == null)
            {
                var convertExpression = expression.Body as UnaryExpression;

                if (convertExpression != null)
                {
                    result = convertExpression.Operand as MemberExpression;
                }
            }

            return result;
        }
    }
}
