// <copyright file="Methods.cs" company="SomeCompany">
//     SomeCompany. All rights reserved.
// </copyright>
// <author>Somebody</author>

namespace Telerik.Homeworks.HighQualityCode.NamingIdentifiers.Task1
{
    using System;

    /// <summary>A class containing methods to use with the PrintResults console application</summary>
    public class Methods
    {
        /// <summary>
        /// Converts a boolean value to string and prints it on the console
        /// </summary>
        /// <param name="value">The boolean value to be converted</param>
        public static void PrintBoolAsString(bool value)
        {
            string boolAsString = value.ToString();
            Console.WriteLine(boolAsString);
        }
    }
}
