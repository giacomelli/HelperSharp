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
		private static Regex s_insertUnderscoreBeforeUpperCase = new Regex(@"(?<!_|^)([A-Z])", RegexOptions.Compiled);
		#endregion

        #region GetWordFromIndex
		/// <summary>
		/// Gets the index of the word from the source.
		/// </summary>
		/// <returns>The word from index.</returns>
		/// <param name="source">Source.</param>
		/// <param name="index">Index.</param>
        public static string GetWordFromIndex(this string source, int index)
        {
            int wordStartIndex;
            return GetWordFromIndex(source, index, out wordStartIndex);
        }

		/// <summary>
		/// Gets the index of the word from source.
		/// </summary>
		/// <returns>The word from index.</returns>
		/// <param name="source">Source.</param>
		/// <param name="index">Index.</param>
		/// <param name="wordStartIndex">Word start index.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#")]
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
        /// <param name="source">Source.</param>
        public static int CountWords(this string source)
        {
            return source.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        #endregion

        #region Removes
        /// <summary>
        /// Removes the accents.
        /// </summary>
        /// <returns>The accents.</returns>
        /// <param name="source">Source.</param>
        public static string RemoveAccents(this string source)
        {
			var sourceNormalized = source.Normalize(NormalizationForm.FormD);
			var result = new StringBuilder();

			for(int i = 0; i < sourceNormalized.Length; i++) {
				var uc = CharUnicodeInfo.GetUnicodeCategory(sourceNormalized[i]);

				if(uc != UnicodeCategory.NonSpacingMark) {
					result.Append(sourceNormalized[i]);
				}
			}

			return(result.ToString().Normalize(NormalizationForm.FormC));
        }
     

        /// <summary>
        /// Removes the non alphanumeric chars.
        /// </summary>
        /// <returns>The non alphanumeric.</returns>
        /// <param name="source">Source.</param>
        public static string RemoveNonAlphanumeric(this string source)
        {
			return Regex.Replace(source, "[^0-9A-Za-záàãâäéèêëíìîïóòõôöúùûüñ]*", "");
        }

		/// <summary>
		/// Removes the non numeric chars.
		/// </summary>
		/// <returns>The non numeric.</returns>
		/// <param name="source">Source.</param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonNumeric")]        
        public static string RemoveNonNumeric(this string source)
        {
            return Regex.Replace(source, "[^0-9]*", "");
        }

		/// <summary>
		/// Removes the string "remove" from source borders.
		/// </summary>
		/// <returns>The from borders.</returns>
		/// <param name="source">Source.</param>
		/// <param name="remove">Remove.</param>
        public static string RemoveFromBorders(this string source, string remove)
        {            
            remove = Regex.Escape(remove);
            return Regex.Replace(source, String.Format(CultureInfo.InvariantCulture, "(^{0}|{1}$)", remove, remove), "", RegexOptions.IgnoreCase);
        }

        /// <summary>
		/// Removes the chars "remove" from source borders.
        /// </summary>
        /// <returns>The from borders.</returns>
        /// <param name="source">Source.</param>
        /// <param name="remove">Remove.</param>
        public static string RemoveFromBorders(this string source, params char[] remove)
        {
            string removeString = Regex.Escape(new String(remove));
            return Regex.Replace(source, String.Format(CultureInfo.InvariantCulture, "(^[{0}]|[{1}]$)", removeString, removeString), "");
        }

        /// <summary>
        /// Removes the pontuactions.
        /// </summary>
        /// <returns>The pontuactions.</returns>
        /// <param name="source">Source.</param>
        public static string RemovePontuactions(this string source)
        {
            return Regex.Replace(source, @"[!\(\)\[\]{}\:;\.,?'""]*", "");
        }
        #endregion

        #region EscapeAccentsToHex
		/// <summary>
		/// Escapes the accents to hexadecimal equivalent.
		/// </summary>
		/// <returns>The accents to hex.</returns>
		/// <param name="source">Source.</param>
        public static string EscapeAccentsToHex(this string source)
        {
            StringBuilder builder = new StringBuilder(source.Length);

            int length = source.Length;

            for(int i = 0; i < length; i++)
            {
                char c = source[i];

                if(c.HasAccent())
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
        #endregion

        #region EscapeAccentsToHtmlEntities
        /// <summary>
        /// Escapes the accents to html entities.
        /// </summary>
        /// <returns>The accents to html entities.</returns>
        /// <param name="source">Source.</param>
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
        /// Verify if source ends the with pontuaction.
        /// </summary>
        /// <returns><c>true</c>, if with pontuaction was endsed, <c>false</c> otherwise.</returns>
        /// <param name="source">Source.</param>
        public static bool EndsWithPontuaction(this string source)
        {
            return Regex.IsMatch(source, @"[!\(\)\[\]{}\:;\.,?'""]$");
        }
        #endregion

        #region HasAccent
        /// <summary>
        /// Determines if has accent.
        /// </summary>
        /// <returns><c>true</c> if has accent the specified source; otherwise, <c>false</c>.</returns>
        /// <param name="source">Source.</param>
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
        #endregion

		#region InsertUnderscore
		/// <summary>
		/// Inserts the underscore before every upper case char.
		/// </summary>
		/// <returns>The result string.</returns>
		/// <param name="input">Input.</param>
		public static string InsertUnderscoreBeforeUpperCase(this string input)
		{
			if(String.IsNullOrEmpty(input))
			{
				return input;
			}

			return s_insertUnderscoreBeforeUpperCase.Replace(input, "_$1");
		}
		#endregion

		/// <summary>
		/// Format the specified string.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="args">Arguments.</param>
		public static string With(this string source, params object[] args)
		{
			return String.Format (CultureInfo.InvariantCulture, source, args);
		}
    }
}
