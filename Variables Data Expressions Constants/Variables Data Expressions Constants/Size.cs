// Refactor the following code to use proper variable naming and simplified expressions:
namespace Homeworks.Telerik.HQC
{
    using System;

    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public static Size GetRotatedSize(Size figure, double figureAngle)
        {
            double a = RotationFormulaCosinePart(figureAngle, figure.Width);
            double b = RotationFormulaSinePart(figureAngle, figure.Height);

            double c = RotationFormulaSinePart(figureAngle, figure.Width);
            double d = RotationFormulaCosinePart(figureAngle, figure.Height);

            double width = a + b;
            double height = c + d;

            var rotatedSize = new Size(width, height);

            return rotatedSize;
        }

        private static double RotationFormulaCosinePart(double angle, double side)
        {
            double result = Math.Abs(Math.Cos(angle)) * side;
            return result;
        }

        private static double RotationFormulaSinePart(double angle, double side)
        {
            double result = Math.Abs(Math.Sin(angle)) * side;
            return result;
        }
    }
}
