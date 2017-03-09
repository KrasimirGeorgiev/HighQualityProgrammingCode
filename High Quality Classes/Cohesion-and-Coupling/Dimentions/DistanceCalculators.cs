namespace CohesionAndCoupling.Dimentions
{
    using System;

    public static class DistanceCalculators
    {
        public static double Distance2D(double x1, double y1, double x2, double y2)
        {
            var distance = Math.Sqrt(
                Math.Pow(x2 - x1, 2) +
                Math.Pow(y2 - y1, 2));

            return distance;
        }

        public static double Distance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            var distance = Math.Sqrt(
                Math.Pow(x2 - x1, 2) +
                Math.Pow(y2 - y1, 2) +
                Math.Pow(z2 - z1, 2));

            return distance;
        }
    }
}