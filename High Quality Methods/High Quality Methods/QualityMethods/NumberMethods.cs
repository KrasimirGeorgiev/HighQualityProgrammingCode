namespace Telerik.Homework.HQC.Methods.Task1.QualityMethods
{
    using System;

    public static class NumberMethods
    {
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("No arguments passed");
            }
            else if (elements.Length == 1)
            {
                throw new ArgumentException("Only one element passed, expecting at least 2 elements");
            }

            int max = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }
    }
}