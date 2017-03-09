namespace CohesionAndCoupling
{
    using System;
    using Dimentions;
    using FileMethods;
    using Shapes;

    public class HomeworkTests
    {
        private static void Main()
        {
            // Console.WriteLine(File.GetExtension("example"));
            Console.WriteLine(File.GetExtension("example.pdf"));
            Console.WriteLine(File.GetExtension("example.new.pdf"));

            // Console.WriteLine(File.GetName("example"));
            Console.WriteLine(File.GetName("example.pdf"));
            Console.WriteLine(File.GetName("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                DistanceCalculators.Distance2D(1, -2, 3, 4));

            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                DistanceCalculators.Distance3D(5, 2, -1, 3, -6, 4));

            var cube = new Cube(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", FunctionsFor3D.CalculateVolume(cube.Width, cube.Height, cube.Depth));

            Console.WriteLine(
                "Diagonal XYZ = {0:f2}",
                FunctionsFor3D.GetShapeDiagonalXYZ(cube.Width, cube.Height, cube.Depth));

            Console.WriteLine("Diagonal XY = {0:f2}", FunctionsFor2D.GetFigureDiagonal(cube.Width, cube.Height));

            Console.WriteLine("Diagonal XZ = {0:f2}", FunctionsFor2D.GetFigureDiagonal(cube.Width, cube.Depth));

            Console.WriteLine("Diagonal YZ = {0:f2}", FunctionsFor2D.GetFigureDiagonal(cube.Height, cube.Depth));
        }
    }
}