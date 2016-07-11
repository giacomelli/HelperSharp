using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace HelperSharp
{
	/// <summary>
	/// String extensions.
	/// </summary>
	public static class StringExtensions
	{
		#region Fields

		#if PCL
		private static Regex s_insertUnderscoreBeforeUppercase = new Regex(@"(?<!_|^)([A-Z])");
		private static Regex s_capitalizeRegex = new Regex(@"((\s|^)\S)(\S+)");
		#else
		private static Regex s_insertUnderscoreBeforeUppercase = new Regex(@"(?<!_|^)([A-Z])", RegexOptions.Compiled);
		private static Regex s_capitalizeRegex = new Regex(@"((\s|^)\S)(\S+)", RegexOptions.Compiled);
		#endif

		#endregion

		#region GetWordFromIndex

		/// <summary>
		/// Gets the word in the specified index.
		/// </summary>
		/// <returns>The word from index.</returns>
		/// <param name="source">The source string.</param>
		/// <param name="index">The index.</param>
		public static string GetWordFromIndex(this string source, int index)
		{
			int wordStartIndex;
			return GetWordFromIndex(source, index, out wordStartIndex);
		}

		/// <summary>
		/// Gets the word in the specified index.
		/// </summary>
		/// <returns>The word from index.</returns>
		/// <param name="source">The source string.</param>
		/// <param name="index">The index.</param>
		/// <param name="wordStartIndex">Word start index.</param>
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "It's necessary for the method purpose.")]
		public static string GetWordFromIndex(this String source, int index, out int wordStartIndex)
		{
			string[] words = source.Split(new char[1] { ' ' });
			int length = words.Length;
			int indexCounter = -1;

			for (int i = 0; i < length; i++)
			{
				string currentWord = words[i];

				indexCounter += currentWord.Length;

				if (indexCounter >= index)
				{
					wordStartIndex = indexCounter - (currentWord.Length - 1);
					return currentWord;
				}

				// Soma o espaço em branco.
				indexCounter++;
				if (indexCounter == index)
				{
					wordStartIndex = indexCounter;
					return " ";
				}
			}

			wordStartIndex = 0;
			return source;
		}

		#endregion

		#region CountWords

		/// <summary>
		/// Counts the words.
		/// </summary>
		/// <returns>The words.</returns>
		/// <param name="source">The source string.</param>
		public static int CountWords(this string source)
		{
			return source.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
		}

		#endregion

		#region Removes

		#if !PCL
        /// <summary>
        /// Removes the accents.
        /// </summary>
        /// <returns>The accents.</returns>
        /// <param name="source">The source string.</param>
        public static string RemoveAccents(this string source)
        {
            var sourceNormalized = source.Normalize(NormalizationForm.FormD);
            var result = new StringBuilder();

            for (int i = 0; i < sourceNormalized.Length; i++)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(sourceNormalized[i]);

                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    result.Append(sourceNormalized[i]);
                }
            }

            return result.ToString().Normalize(NormalizationForm.FormC);
        }
		#endif
		/// <summary>
		/// Removes the non alphanumeric chars.
		/// </summary>
		/// <returns>The non alphanumeric.</returns>
		/// <param name="source">The source string.</param>
		public static string RemoveNonAlphanumeric(this string source)
		{
			return Regex.Replace(source, "[^0-9A-Za-záàãâäéèêëíìîïóòõôöúùûüñ]*", String.Empty);
		}

		/// <summary>
		/// Removes the non numeric chars.
		/// </summary>
		/// <returns>The non numeric.</returns>
		/// <param name="source">The source string.</param>
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonNumeric", Justification = "Ok.")]
		public static string RemoveNonNumeric(this string source)
		{
			return Regex.Replace(source, "[^0-9]*", String.Empty);
		}

		/// <summary>
		/// Removes the specified string from borders.
		/// </summary>
		/// <returns>The from borders.</returns>
		/// <param name="source">The source string.</param>
		/// <param name="remove">The string to remove.</param>
		public static string RemoveFromBorders(this string source, string remove)
		{
			remove = Regex.Escape(remove);
			return Regex.Replace(source, String.Format(CultureInfo.InvariantCulture, "(^{0}|{1}$)", remove, remove), String.Empty, RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// Removes the chars "remove" from source borders.
		/// </summary>
		/// <returns>The from borders.</returns>
		/// <param name="source">The source string.</param>
		/// <param name="remove">The chars to remove.</param>
		public static string RemoveFromBorders(this string source, params char[] remove)
		{
			string removeString = Regex.Escape(new String(remove));
			return Regex.Replace(source, String.Format(CultureInfo.InvariantCulture, "(^[{0}]|[{1}]$)", removeString, removeString), String.Empty);
		}

		/// <summary>
		/// Removes the punctuations.
		/// </summary>
		/// <returns>The clean string.</returns>
		/// <param name="source">The source string.</param>
		public static string RemovePunctuations(this string source)
		{
			return Regex.Replace(source, @"[!\(\)\[\]{}\:;\.,?'""]*", String.Empty);
		}

		#endregion

		#region EscapeAccentsToHex

		#if !PCL
		/// <summary>
		/// Escapes the accents to hexadecimal equivalent.
		/// </summary>
		/// <returns>The accents to hex.</returns>
		/// <param name="source">The source string.</param>
		public static string EscapeAccentsToHex(this string source)
		{
			StringBuilder builder = new StringBuilder(source.Length);

			int length = source.Length;

			for (int i = 0; i < length; i++)
			{
				char c = source[i];

				if (c.HasAccent())
				{
					builder.Append(Uri.HexEscape(source[i]));
				}
				else
				{
					builder.Append(source[i]);
				}
			}

			return builder.ToString();
		}
		#endif
		#endregion

		#region EscapeAccentsToHtmlEntities

		/// <summary>
		/// Escapes the accents to html entities.
		/// </summary>
		/// <returns>The accents to html entities.</returns>
		/// <param name="source">The source string.</param>
		public static string EscapeAccentsToHtmlEntities(this string source)
		{
			int length = source.Length;
			var escaped = new StringBuilder();

			for (int i = 0; i < length; i++)
			{
				char ch = source[i];

				if ((ch >= '\x00a0') && (ch < 'Ā'))
				{
					escaped.AppendFormat("&#{0};", ((int)ch).ToString(NumberFormatInfo.InvariantInfo));
				}
				else
				{
					escaped.Append(ch);
				}
			}

			return escaped.ToString();
		}

		#endregion

		#region EndsWith

		/// <summary>
		/// Verify if source ends the with punctuation.
		/// </summary>
		/// <returns><c>true</c>, if with punctuation was the end, <c>false</c> otherwise.</returns>
		/// <param name="source">The source string.</param>
		public static bool EndsWithPunctuation(this string source)
		{
			return Regex.IsMatch(source, @"[!\(\)\[\]{}\:;\.,?'String.Empty]$");
		}

		#endregion

		#region HasAccent

		#if !PCL
		/// <summary>
		/// Determines if has accent.
		/// </summary>
		/// <returns><c>true</c> if has accent the specified source; otherwise, <c>false</c>.</returns>
		/// <param name="source">The source string.</param>
		public static bool HasAccent(this string source)
		{
			int length = source.Length;

			for (int i = 0; i < length; i++)
			{
				if (source[i].HasAccent())
				{
					return true;
				}
			}

			return false;
		}
		#endif

		#endregion

		#region InsertUnderscore

		/// <summary>
		/// Inserts the underscore before every upper case char.
		/// </summary>
		/// <returns>The result string.</returns>
		/// <param name="input">The source string.</param>
		public static string InsertUnderscoreBeforeUppercase(this string input)
		{
			if (String.IsNullOrEmpty(input))
			{
				return input;
			}

			return s_insertUnderscoreBeforeUppercase.Replace(input, "_$1");
		}

		#endregion

		/// <summary>
		/// Format the specified string. Is a String.Format(CultureInfo.InvariantCulture,..) shortcut.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="args">The arguments.</param>
		/// <returns>The formatted string.</returns>
		public static string With(this string source, params object[] args)
		{
			return String.Format(CultureInfo.InvariantCulture, source, args);
		}

		/// <summary>
		/// Capitalize the string.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="ignoreWordsLowerThanChars">The words lower than specified chars will be ignored.</param>
		/// <returns>The capitalized string.</returns>
		[SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
		public static string Capitalize(this string source, int ignoreWordsLowerThanChars = 3)
		{
			return s_capitalizeRegex.Replace(
				source.ToLowerInvariant(),
				(m) =>
				{
					if (m.Value.Trim().Length < ignoreWordsLowerThanChars)
					{
						return m.Value;
					}
					else
					{
						return m.Groups[1].Value.ToUpperInvariant() + m.Groups[3].Value;
					}
				});
		}

		/// <summary>
		///  Returns a value indicating whether the specified substring occurs within this string 
		///  <remarks>
		///  Based on http://stackoverflow.com/a/444818/956886. 
		/// </remarks>
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="substring">The substring.</param>
		/// <returns>True se if substring occurs, otherwise false.</returns>
		public static bool ContainsIgnoreCase(this string source, string substring)
		{
			return source.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
		}
	}
}
