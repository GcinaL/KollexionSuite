using System.Globalization;
using System.Text.RegularExpressions;

namespace KollexionSuite.Services.Shared.Common.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes special characters from a string, leaving only letters, numbers, and spaces
        /// </summary>
        private static string RemoveSpecialCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Keep letters, numbers, and spaces
            return Regex.Replace(input, @"[^a-zA-Z0-9\s]", "");
        }

        /// <summary>
        /// Converts a string to sentence case after removing special characters
        /// </summary>
        public static string ToSentenceCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            value = RemoveSpecialCharacters(value).Trim();

            if (string.IsNullOrEmpty(value))
                return value;

            return char.ToUpper(value[0], CultureInfo.CurrentCulture) +
                   value.Substring(1).ToLower(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts any object to string, removes special characters, and converts to sentence case
        /// </summary>
        public static string ToSentenceCase(this object value)
        {
            if (value == null)
                return string.Empty;

            return (value.ToString() ?? "").ToSentenceCase();
        }
    }
}
