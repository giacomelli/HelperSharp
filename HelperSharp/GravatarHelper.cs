using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HelperSharp
{
    /// <summary>
    /// Gravatar helper.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gravatar")]
    public static class GravatarHelper
    {
        /// <summary>
        /// Gets the avatar URL for the specified e-mail.
        /// Original source code from: https://gist.github.com/danesparza/973923.
        /// </summary>
        /// <remarks>
        /// Take a look on https://en.gravatar.com/site/implement/images/ to see the paremeters options
        /// </remarks>
        /// <returns>The avatar URL.</returns>
        /// <param name="email">The e-mail.</param>
        /// <param name="size">The image size. Default is 80px.</param>
        /// <param name="defaultImage">The default image. See options on https://en.gravatar.com/site/implement/images/.</param>
        /// <param name="forceDefaultImage">If for some reason you wanted to force the default image to always load.</param>
        /// <param name="rating">Gravatar allows users to self-rate their images so that they can indicate if an image is appropriate for a certain audience. Default 'g'.</param>
        /// <param name="secureRequest">If you're displaying Gravatars on a page that is being served over SSL (e.g. the page URL starts with HTTPS), then you'll want to serve your Gravatars via SSL as well, otherwise you'll get annoying security warnings in most browsers.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        [SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
        public static string GetAvatarUrl(string email, int size = 80, string defaultImage = null, bool forceDefaultImage = false, string rating = "g", bool secureRequest = false)
        {
            ExceptionHelper.ThrowIfNullOrEmpty("email", email);
            ExceptionHelper.ThrowIfNullOrEmpty("rating", rating);

            var sanitizedEmail = email.Trim().ToLowerInvariant();
            var avatarHash = MD5Helper.Encrypt(sanitizedEmail);

            var url = "http://{0}.gravatar.com/avatar/{1}.jpg".With(
                secureRequest ? "secure" : "www",
                avatarHash);

            var parameters = new List<string>();

            // Size.
            if (size != 80)
            {
                parameters.Add("s={0}".With(size));
            }

            // Default image.
            if (!String.IsNullOrEmpty(defaultImage))
            {
                parameters.Add("d={0}".With(defaultImage));
            }

            // Force default image.
            if (forceDefaultImage)
            {
                parameters.Add("f=y");
            }

            // Rating.
            if (!rating.Equals("g", StringComparison.OrdinalIgnoreCase))
            {
                parameters.Add("r={0}".With(rating));
            }

            if (parameters.Count > 0)
            {
                url = "{0}?{1}".With(url, String.Join("&", parameters.ToArray()));
            }

            return url;
        }
    }
}