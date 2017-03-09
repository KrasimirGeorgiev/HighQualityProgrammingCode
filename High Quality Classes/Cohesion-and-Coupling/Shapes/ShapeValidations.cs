namespace CohesionAndCoupling.Shapes
{
    using System;

    public static class ShapeValidations
    {
        public static void ValidateSide(double side, string name)
        {
            if (side <= 0)
            {
                throw new ArgumentException(name + " must be higher than zero");
            }
        }
    }
}