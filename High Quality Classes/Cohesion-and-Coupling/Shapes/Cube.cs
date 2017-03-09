namespace CohesionAndCoupling.Shapes
{
    public class Cube
    {
        private double depth;

        private double height;
        private double width;

        public Cube(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                ShapeValidations.ValidateSide(value, "width");
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
                ShapeValidations.ValidateSide(value, "Height");
                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                ShapeValidations.ValidateSide(value, "Depth");
                this.depth = value;
            }
        }
    }
}