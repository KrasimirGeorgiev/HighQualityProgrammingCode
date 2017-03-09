namespace Abstraction
{
    using System;

    public class Rectangle : IShape
    {
        private double height;
        private double width;

        public Rectangle(double side)
        {
            this.Width = side;
            this.Height = side;
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.ValidateSide(value, "Width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.ValidateSide(value, "Height");
                this.height = value;
            }
        }

        public double CalculatePerimeter()
        {
            var perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalculateSurface()
        {
            var surface = this.Width * this.Height;
            return surface;
        }

        private void ValidateSide(double side, string name)
        {
            if (side <= 0)
            {
                throw new ArgumentException(name + " must be greater than zero");
            }
        }
    }
}