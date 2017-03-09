namespace Iterator
{
    public class MatrixReverseIterator<T> : IIterator
    {
        private readonly Matrix<T> aggregate;

        private int currentRow;

        private int currentCol;

        public MatrixReverseIterator(Matrix<T> aggregate)
        {
            this.aggregate = aggregate;
            this.currentRow = aggregate.Rows - 1;
            this.currentCol = aggregate.Cols - 1;
        }

        public void Next()
        {
            if (currentCol > 0)
            {
                this.currentCol--;
            }
            else 
            {
                this.currentRow--;
                this.currentCol = this.aggregate.Cols - 1;
            }
        }

        public object CurrentItem()
        {
            return this.aggregate[this.currentRow, this.currentCol];
        }

        public bool IsDone()
        {
            return this.currentRow <= -1;
        }
    }
}
