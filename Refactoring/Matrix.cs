namespace GameFifteen
{
    using System;
    using System.Text;

    public class Matrix
    {
        public const int DimentionMaxValue = 100;

        public const int DimentionMinValue = 1;

        private const int PossibleDirections = 8;

        private readonly int dimensions;

        private readonly Position currentPosition = new Position(0, 0);

        private int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };

        private int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public Matrix(int dimensions)
        {
            this.ValidateDimensions(dimensions);

            this.dimensions = dimensions;

            this.Content = new int[dimensions, dimensions];

            this.GetNextAvailableCell();

            this.FillAvailableCells();
        }

        public int[,] Content { get; private set; }

        public override string ToString()
        {
            StringBuilder strContent = new StringBuilder();

            for (int row = 0; row < this.dimensions; row++)
            {
                for (int col = 0; col < this.dimensions; col++)
                {
                    strContent.AppendFormat("{0,3}", this.Content[row, col]);
                }

                strContent.Append("\r\n");
            }

            return strContent.ToString();
        }

        private void ValidateDimensions(int dimensions)
        {
            if (dimensions < DimentionMinValue || DimentionMaxValue < dimensions)
            {
                throw new ArgumentOutOfRangeException(nameof(dimensions), "The given matrix dimensions are outside the allowed range");
            }
        }

        private void GetNextAvailableCell()
        {
            this.currentPosition.SetRowAndCol(0, 0);

            for (int currentRow = 0; currentRow < this.dimensions; currentRow++)
            {
                for (int currentCol = 0; currentCol < this.dimensions; currentCol++)
                {
                    if (this.Content[currentRow, currentCol] == 0)
                    {
                        this.currentPosition.SetRowAndCol(currentRow, currentCol);
                        return;
                    }
                }
            }
        }

        private void FillAvailableCells()
        {
            int cellValue = 1;

            Position direction = new Position(1, 1);

            while (true)
            {
                int currentRow = this.currentPosition.Row;
                int currentCol = this.currentPosition.Col;

                this.Content[currentRow, currentCol] = cellValue;

                if (!this.IsCellAvailable(this.currentPosition))
                {
                    this.GetNextAvailableCell();
                    currentRow = this.currentPosition.Row;
                    currentCol = this.currentPosition.Col;

                    if (this.IsCellAvailable(this.currentPosition))
                    {
                        cellValue++;
                        this.Content[currentRow, currentCol] = cellValue;
                        direction.SetRowAndCol(1, 1);
                    }
                    else
                    {
                        break;
                    }
                }

                int nextRow = currentRow + direction.Row;
                int nextCol = currentCol + direction.Col;

                while (!this.IsInRange(nextRow) || !this.IsInRange(nextCol))
                {
                    direction = this.GetDirection(direction);

                    nextRow = currentRow + direction.Row;
                    nextCol = currentCol + direction.Col;
                }

                this.currentPosition.SetRowAndCol(nextRow, nextCol);

                cellValue++;
            }
        }

        private bool IsCellAvailable(Position position)
        {
            for (int dirIndex = 0; dirIndex < PossibleDirections; dirIndex++)
            {
                int nextRow = position.Row + this.directionRow[dirIndex];

                if (!this.IsInRange(nextRow))
                {
                    this.directionRow[dirIndex] = 0;
                }

                int nextCol = position.Col + this.directionCol[dirIndex];

                if (!this.IsInRange(nextCol))
                {
                    this.directionCol[dirIndex] = 0;
                }
            }

            for (int dirIndex = 0; dirIndex < PossibleDirections; dirIndex++)
            {
                int nextRow = position.Row + this.directionRow[dirIndex];
                int nextCol = position.Col + this.directionCol[dirIndex];

                if (this.Content[nextRow, nextCol] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInRange(int next)
        {
            if (0 > next || next >= this.dimensions)
            {
                return false;
            }

            return true;
        }

        private Position GetDirection(Position prevDirection)
        {
            int currentDirection = 0;

            for (int dirIndex = 0; dirIndex < PossibleDirections; dirIndex++)
            {
                if (this.directionRow[dirIndex] == prevDirection.Row && this.directionCol[dirIndex] == prevDirection.Col)
                {
                    currentDirection = dirIndex;
                    break;
                }
            }

            if (currentDirection == PossibleDirections - 1)
            {
                return new Position(this.directionRow[0], this.directionCol[0]);
            }

            return new Position(
                this.directionRow[currentDirection + 1],
                this.directionCol[currentDirection + 1]);
        }
    }
}
