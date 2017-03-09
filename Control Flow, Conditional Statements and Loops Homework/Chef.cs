// Task 1. Class Chef in C#
// Refactor the following class using best practices for organizing straight-line code:
namespace Homework.Telerik.HighQualityCode
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Bowl vegetablesBowl = GetBowl();

            Potato averagePotato = GetPotato();
            Peel(averagePotato);
            Cut(averagePotato);

            vegetablesBowl.Add(averagePotato);

            Carrot smallCarrot = GetCarrot();
            Peel(smallCarrot);
            Cut(smallCarrot);

            vegetablesBowl.Add(smallCarrot);
        }

        private static Potato GetPotato()
        {
            return new Potato();
        }

        private static Bowl GetBowl()
        {
            return new Bowl();
        }

        private static Carrot GetCarrot()
        {
            return new Carrot();
        }

        private static void Cut(Vegetable nextVegetable)
        {
            throw new NotImplementedException();
        }

        private static void Peel(Vegetable nextVegetable)
        {
            throw new NotImplementedException();
        }
    }
}