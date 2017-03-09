namespace GameFifteen
{
    public class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public void SetRowAndCol(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
