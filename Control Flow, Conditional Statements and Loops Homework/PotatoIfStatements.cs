// Task 2. Refactor the following if statements
namespace Homework.Telerik.HighQualityCode
{
    using System;

    public class PotatoIfStatements
    {
        public static void PrepareMeal()
        {
            var potato = GetPotato();
            potato = CheckPotato(potato);
            Cook(potato);
        }

        private static Potato CheckPotato(Potato potato) 
        {
            if (potato == null)
            {
                throw new ArgumentNullException();
            }
            else if (potato.IsRotten)
            {
                throw new PotatoRottenException();
            }
            else if (!potato.IsPeeled)
            {
                throw new PotatoNotPeeledException();
            }
            else
            {
                return potato;
            }
        }

        private static Product Cook(Product product)
        {
            throw new NotImplementedException();
        }

        private static Potato GetPotato()
        {
            throw new NotImplementedException();
        }
    }
}
