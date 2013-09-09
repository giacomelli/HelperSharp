using System;

namespace HelperSharp
{
	/// <summary>
	/// Exception helper.
	/// </summary>
	public static class ExceptionHelper
	{
		/// <summary>
		/// Throws an ArgumentNullException if argument is null.
		/// </summary>
		/// <param name="argumentName">Argument name.</param>
		/// <param name="argument">Argument.</param>
		public static void ThrowIfNull(string argumentName, object argument)
		{
			if(argument == null)
			{
				throw new ArgumentNullException(argumentName);
			}
		}

		/// <summary>
		/// Throws an ArgumentNullException if argument is null or an ArgumentException if string is empty.
		/// </summary>
		/// <param name="argumentName">Argument name.</param>
		/// <param name="argument">Argument.</param>
		public static void ThrowIfNullOrEmpty(string argumentName, string argument)
		{
			ThrowIfNull (argumentName, argument);

			if(string.IsNullOrEmpty(argument))
			{
				throw new ArgumentException ("Argument '{0}' can't be empty.".With(argumentName), argumentName);
			}
		}
	}
}