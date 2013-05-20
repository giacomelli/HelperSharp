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
	}
}