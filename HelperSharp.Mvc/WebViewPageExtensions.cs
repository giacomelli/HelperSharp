using System;
using System.Web.Mvc;

namespace HelperSharp.Mvc
{
    /// <summary>
    /// WebViewPage extensions.
    /// </summary>
    public static class WebViewPageExtensions
    {
        /// <summary>
        /// Gets the page path.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>The path.</returns>
        public static string GetPath(this WebViewPage page)
        {
            ExceptionHelper.ThrowIfNull("page", page);

            if (page.ViewContext == null)
            {
                throw new ArgumentException("ViewContext can't be null.", "page");
            }

            return ((RazorView)page.ViewContext.View).ViewPath;
        }
    }
}
