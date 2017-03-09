// <copyright file="StringExtensions.cs" company="Telerik">
//     Telerik. All rights reserved.
// </copyright>
// <author>SomeStudent</author>

namespace StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A class library of methods for string processing
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Message Digest 5 (MD5) hash generator
        /// </summary>
        /// <param name="input">Input is a string</param>
        /// <returns>32bit hexadecimal MD5 hash tag</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            // Convert to hex string
            foreach (byte b in data)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Checks if the given value is string representation of the boolean value: true
        /// </summary>
        /// <param name="input">Input can be one of this values: "true", "ok", "yes", "1", "да" </param>
        /// <returns>true or false</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Tries to parses a string to a short Integer
        /// </summary>
        /// <param name="input">String representation of an integer</param>
        /// <returns>16bit signed Integer or 0</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Tries to parses a string to an Integer
        /// </summary>
        /// <param name="input">String representation of an integer</param>
        /// <returns>32bit signed Integer or 0</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Tries to parses a string to a long Integer
        /// </summary>
        /// <param name="input">String representation of an integer</param>
        /// <returns>32bit signed Integer or 0</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Tries to parses a string to a DateTime value
        /// </summary>
        /// <param name="input">String in DateTime format</param>
        /// <returns>A DateTime instance</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of the given string according to current culture settings
        /// </summary>
        /// <param name="input">A non empty sting</param>
        /// <returns>The input string starting with a capital letter</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Extracts a string in between the two strings if the strings are contained in the input
        /// </summary>
        /// <param name="input">The string to work on</param>
        /// <param name="startString">Substring starts after this string</param>
        /// <param name="endString">Substring ends with arriving to this string</param>
        /// <param name="startFrom">The index of the input string from which to start looking(default value 0)</param>
        /// <returns>The text between starString and endString</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert the cyrillic characters in a given string to their latin representation
        /// </summary>
        /// <param name="input">A string containing cyrillic characters</param>
        /// <returns>A string with all cyrillic characters converted to latin characters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };
            var latinRepresentationsOfBulgarianLetters = new[]
            {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };

            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(
                    bulgarianLetters[i].ToUpper(),
                    latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convers the latin characters in a given string to their cyrillic representation
        /// </summary>
        /// <param name="input">A string containing latin characters</param>
        /// <returns>A string with all latin characters converted to cyrillic characters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            var bulgarianRepresentationOfLatinKeyboard = new[]
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                "в", "ь", "ъ", "з"
            };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts cyrillic characters to latin and removes non letter characters except digits, the underscore and the dot.
        /// </summary>
        /// <param name="input">An username</param>
        /// <returns>The processed string</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts cyrillic characters to latin, replaces spaces with dashes,
        /// removes non letter characters except digits, the underscore, the dash and the dot.
        /// </summary>
        /// <param name="input">A filename</param>
        /// <returns>The processed string</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets the first n - count characters from a string, if n is greater than the string length
        /// it gets the whole string
        /// </summary>
        /// <param name="input">The string to work with</param>
        /// <param name="charsCount">The count of characters to get</param>
        /// <returns>The n - count characters from the start</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets the file extension of filename
        /// </summary>
        /// <param name="fileName">A string representation of a filename</param>
        /// <returns>The filename file extension</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Displays the content type for the given file extension, if it is recognized (is in the dictionary)
        /// </summary>
        /// <param name="fileExtension">A file extension</param>
        /// <returns>The content type or "application/octet-stream" if it's not recognized</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
            {
                { "jpg", "image/jpeg" },
                { "jpeg", "image/jpeg" },
                { "png", "image/x-png" },
                {
                    "docx",
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                },
                { "doc", "application/msword" },
                { "pdf", "application/pdf" },
                { "txt", "text/plain" },
                { "rtf", "application/rtf" }
            };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Encodes a string to as byte array
        /// </summary>
        /// <param name="input">The string to work with</param>
        /// <returns>A byte array constructed from the string</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}