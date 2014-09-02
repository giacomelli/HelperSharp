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
        /// <returns>The avatar URL.</returns>
        /// <param name="email">The e-mail.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        [SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
        public static string GetAvatarUrl(string email)
        {
            ExceptionHelper.ThrowIfNullOrEmpty("email", email);

            var sanitizedEmail = email.Trim().ToLowerInvariant();
            var avatarHash = MD5Helper.Encrypt(sanitizedEmail);

            return "http://www.gravatar.com/avatar/{0}.jpg".With(avatarHash);
        }
    }
}