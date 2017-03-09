namespace Iterator
{
    using System;

    public class Matrix<T> : Aggregate
    {
        private readonly T[,] matrix;

        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        public override IIterator GetIterator()
        {
            return new MatrixReverseIterator<T>(this);
        }
    }
}
