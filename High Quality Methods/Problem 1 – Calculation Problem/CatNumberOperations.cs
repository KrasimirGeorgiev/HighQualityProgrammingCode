namespace Telerik.Exams.CSharp2
{
    using System;
    using System.Text;

    public class CatNumberOperations
    {
        private const int NumeralSystemBase = 23;

        public static double ConvertToBase10(string catNumber)
        {
            int power = 1;
            double result = catNumber[catNumber.Length - 1] - 'a';

            for (int i = catNumber.Length - 2; i >= 0; i--)
            {
                int nextPartOfNumber = catNumber[i] - 'a';
                result += nextPartOfNumber * Math.Pow(NumeralSystemBase, power);
                power++;
            }

            return result;
        }

        public static string ConvertToCatNumber(double number)
        {
            var strBuilder = new StringBuilder();

            while (number > 1)
            {
                double reminder = number % NumeralSystemBase;
                char asCatNumber = (char)(reminder + 'a');
                strBuilder.Insert(0, asCatNumber);

                number /= NumeralSystemBase;
            }

            string result = strBuilder.ToString();

            return result;
        }

        public static double Base10Sum(string[] catNumbers)
        {
            double result = 0;
            foreach (string number in catNumbers)
            {
                result += ConvertToBase10(number);
            }

            return result;
        }
    }
}
