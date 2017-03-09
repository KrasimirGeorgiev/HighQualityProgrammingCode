// <copyright file="PeopleGeneratorTest.cs" company="SomeCompany">
//     SomeCompany. All rights reserved.
// </copyright>
// <author>Somebody</author>

namespace Telerik.Homeworks.HighQualityCode.NamingIdentifiers.Task2
{
    using System;

    /// <summary> Complimentary class for testing purposes (not a part of the homework)</summary>
    public class PeopleGeneratorTest
    {
        /// <summary>Main method of the application</summary>
        private static void Main()
        {
            AttractivePerson pesho = VirtualPeopleGenerator.Create(20);
            AttractivePerson jana = VirtualPeopleGenerator.Create(21);

            PrintResult(pesho);
            Console.WriteLine();

            PrintResult(jana);
        }

        /// <summary>Iterate properties of an instance and prints their value on the console</summary>
        /// <param name="person">An instance to iterate</param>
        private static void PrintResult(AttractivePerson person)
        {
            foreach (var prop in person.GetType().GetProperties())
            {
                Console.WriteLine("{0}: {1}", prop.Name, prop.GetValue(person, null));
            }
        }
    }
}
