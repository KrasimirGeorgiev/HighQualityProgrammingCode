// <copyright file="AttractivePerson.cs" company="SomeCompany">
//     SomeCompany. All rights reserved.
// </copyright>
// <author>Somebody</author>

namespace Telerik.Homeworks.HighQualityCode.NamingIdentifiers.Task2
{
    /// <summary>Template for an Attractive Person</summary>
    public class AttractivePerson
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttractivePerson"/> class
        /// </summary>
        /// <param name="name">A string in the format "Name" or "FirstName LastName"</param>
        /// <param name="gender">One of the two available: "CoolChick" or "HotDude"</param>
        /// <param name="age">Person's age as integer</param>
        public AttractivePerson(string name, AttractiveGenders gender, int age)
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
        }

        /// <summary>Gets Person's gender</summary>
        public AttractiveGenders Gender { get; private set; }

        /// <summary>Gets or sets Person's Name</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets Person's Age</summary>
        public int Age { get; set; }
    }
}
