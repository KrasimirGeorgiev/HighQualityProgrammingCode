namespace Telerik.Homework.HQC.Methods.Task1.QualityMethods
{
    using System;

    public static class ConsolePrint
    {
        public static void NumberInFormat<T>(T number, string format) where T : IComparable, IConvertible, IFormattable
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Received unsuported format");
            }
        }
    }
}
