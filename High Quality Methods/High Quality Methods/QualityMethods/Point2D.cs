namespace Telerik.Homework.HQC.Methods.Task1.QualityMethods
{
    using System;

    public class Point2D
    {
        private double x;
        private double y;

        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public bool IsHorizontalTo(Point2D point)
        {
            if (Math.Abs(this.Y - point.Y) < 0.002)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVerticalTo(Point2D point)
        {
            if (Math.Abs(this.X - point.X) < 0.002)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double DistanceTo(Point2D point)
        {
            double x1 = this.X,
                   y1 = this.Y,
                   x2 = point.X,
                   y2 = point.Y;

            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) +
                                        Math.Pow(y2 - y1, 2));

            return distance;
        }
    }
}
