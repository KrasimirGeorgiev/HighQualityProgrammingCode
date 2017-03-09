namespace Telerik.Homework.HQC.Methods.Task1.QualityMethods
{
    using System;

    public static class TriangleMethods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            bool allSidesArePositive = a > 0 && b > 0 && c > 0;
            if (!allSidesArePositive)
            {
                throw new ArgumentOutOfRangeException("All sides must be of positive value");
            }

            bool inequalityTheoremPassed = (a + b > c) && (a + c > b) && (b + c > a);
            if (!inequalityTheoremPassed)
            {
                throw new ArgumentException("Invalid triangle side length");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }
    }
}
