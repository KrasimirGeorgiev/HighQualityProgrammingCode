namespace Homeworks.Telerik.HQC
{
    public static class StatisticMethods
    {
        public static void PrintStatistics(double[] collection, int count)
        {
            double maxValue = GetMaxValue(collection);
            double minValue = GetMinValue(collection);
            double averageValue = GetAverageValue(collection);

            Print(maxValue);
            Print(minValue);
            Print(averageValue);
        }

        private static double GetMaxValue(double[] collection)
        {
            double maxValue = collection[0];

            for (int i = 1; i < collection.Length; i++)
            {
                if (collection[i] > maxValue)
                {
                    maxValue = collection[i];
                }
            }

            return maxValue;
        }

        private static double GetMinValue(double[] collection)
        {
            double minValue = collection[0];

            for (int i = 1; i < collection.Length; i++)
            {
                if (collection[i] < minValue)
                {
                    minValue = collection[i];
                }
            }

            return minValue;
        }

        private static double GetAverageValue(double[] collection)
        {
            double averageValue = collection[0];

            for (int i = 0; i < collection.Length; i++)
            {
                averageValue += collection[i];
            }

            averageValue /= collection.Length;

            return averageValue;
        }

        private static void Print(double value)
        {
            System.Console.WriteLine(value);
        }
    }
}
