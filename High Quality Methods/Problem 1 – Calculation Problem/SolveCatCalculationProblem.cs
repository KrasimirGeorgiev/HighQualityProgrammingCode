// C# Part 2 - 2015/2016 @ 5 March 2015 - Evening
namespace Telerik.Exams.CSharp2
{
    using System;

    public class SolveCatCalculationProblem
    {
        private static void Main()
        {
            string[] catNumbers = ParseInput(Console.ReadLine());

            double sumOfCatNumbersToDecimal = CatNumberOperations.Base10Sum(catNumbers);
            string sumOfCatNumbers = CatNumberOperations.ConvertToCatNumber(sumOfCatNumbersToDecimal);

            Console.WriteLine("{0} = {1}", sumOfCatNumbers, sumOfCatNumbersToDecimal);
        }

        private static string[] ParseInput(string input)
        {
            var result = input.Split(' ');
            return result;
        }
    }
}
