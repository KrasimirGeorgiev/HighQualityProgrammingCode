namespace Telerik.Homework.HQC.Methods.Task1.QualityMethods
{
    using System;

    public class DigitMethods
    {
        public static string DigitAsWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentOutOfRangeException("The received value: " + " is not a digit");
        }
    }
}
