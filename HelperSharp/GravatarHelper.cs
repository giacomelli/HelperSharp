using System;
using System.Security.Cryptography;
using System.Text;

namespace HelperSharp
{
	/// <summary>
	/// Gravatar helper.
	/// </summary>
    public class GravatarHelper
    {
		/// <summary>
		/// Gets the avatar URL for the specified e-mail.
		/// Original source code from: https://gist.github.com/danesparza/973923.
		/// </summary>
		/// <returns>The avatar URL.</returns>
		/// <param name="email">The e-mail.</param>
		public static string GetAvatarUrl(string email)
		{
			ExceptionHelper.ThrowIfNullOrEmpty ("email", email);

			var sanitizedEmail = email.Trim ().ToLowerInvariant ();
			var md5Hasher = MD5.Create ();

			// Convert the input string to a byte array and compute the hash.  
			byte[] data = md5Hasher.ComputeHash (Encoding.Default.GetBytes (sanitizedEmail));

			var builder = new StringBuilder ();

			// Loop through each byte of the hashed data  
			// and format each one as a hexadecimal string.  
			for (int i = 0; i < data.Length; i++) {
				builder.Append (data [i].ToString ("x2"));
			}

			var avatarHash = builder.ToString ();
	
			return "http://www.gravatar.com/avatar/{0}.jpg".With(avatarHash); 
		}
    }
}