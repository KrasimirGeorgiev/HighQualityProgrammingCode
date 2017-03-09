// <copyright file="VirtualPeopleGenerator.cs" company="SomeCompany">
//     SomeCompany. All rights reserved.
// </copyright>
// <author>Somebody</author>

namespace Telerik.Homeworks.HighQualityCode.NamingIdentifiers.Task2
{
    /// <summary>Initializes instances of AttractivePerson based on different criteria</summary>
    public class VirtualPeopleGenerator
    {
        /// <summary>
        /// Creates a person and assigns him/her a gender using a complex 
        /// calculation based on his/hers age
        /// </summary>
        /// <param name="age">An integer value for age, preferably positive</param>
        /// <returns>A new person</returns>
        public static AttractivePerson Create(int age)
        {
            AttractivePerson person;

            if (age % 2 == 0)
            {
                person = new AttractivePerson("Cool Guy", AttractiveGenders.HotDude, age);
            }
            else
            {
                person = new AttractivePerson("Hot Babe", AttractiveGenders.CoolChick, age);
            }

            return person;
        }
    }
}
