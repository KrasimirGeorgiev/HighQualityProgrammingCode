namespace Telerik.Homework.HQC.Methods.Task1
{
    using System;
    using Telerik.Homework.HQC.Methods.Task1.QualityMethods;

    public class TestHomework
    {
       private static void Main()
        {
            Console.WriteLine("Triangle Area:");
            Console.WriteLine(TriangleMethods.CalcTriangleArea(3, 4, 5));

            Console.WriteLine("\nDigit As Word:");
            Console.WriteLine(DigitMethods.DigitAsWord(5));

            Console.WriteLine("\nFind Max:");
            Console.WriteLine(NumberMethods.FindMax(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine("\nNumbers in different formats:");
            ConsolePrint.NumberInFormat(1.3, "f");
            ConsolePrint.NumberInFormat(0.75, "%");
            ConsolePrint.NumberInFormat(2.30, "r");

            Console.WriteLine("\nPoints and distance:");
            var pointFirst = new Point2D(3, -1);
            var pointLast = new Point2D(3, 2.5);

            Console.WriteLine(pointFirst.DistanceTo(pointLast));
            Console.WriteLine("Points are horizontal to each other -> {0}", pointFirst.IsHorizontalTo(pointLast));
            Console.WriteLine("Points are vertical to each other -> {0}", pointFirst.IsVerticalTo(pointLast));

            Console.WriteLine("\nStudents:");
            Student peter = new Student("Peter", "Ivanov", DateTime.Parse("17.03.1992"));
            peter.OtherInfo = "From Sofia";

            Student stella = new Student("Stella", "Markova", DateTime.Parse("03.11.1993"));
            stella.OtherInfo = "From Vidin, gamer, high results";

            Console.WriteLine("Peter's Bday: {0}", peter.BirthDay.ToShortDateString());
            Console.WriteLine("Stella's Bday: {0}", stella.BirthDay.ToShortDateString());

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
