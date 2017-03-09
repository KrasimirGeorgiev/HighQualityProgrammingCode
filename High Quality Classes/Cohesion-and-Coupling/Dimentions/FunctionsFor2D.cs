namespace CohesionAndCoupling.Dimentions
{
    public static class FunctionsFor2D
    {
        public static double GetFigureDiagonal(double side1, double side2)
        {
            var distance = DistanceCalculators.Distance2D(0, 0, side1, side2);
            return distance;
        }
    }
}