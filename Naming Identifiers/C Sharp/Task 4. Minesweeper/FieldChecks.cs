namespace Telerik.Homeworks.HighQualityCode.NamingIdentifiers.Task4
{
    using System;

    public static class FieldChecks
    {
        public static char CountMinesAround(char[,] minePositions, int row, int column)
        {
            string[] sides = 
                            {
                                 "left",
                                 "right",
                                 "top",
                                 "bottom", 
                                 "top-left",
                                 "bottom-left",
                                 "top-right", 
                                 "bottom-right"
                             };

            int minesCounted = 0;

            foreach (var side in sides)
            {
                bool hasMine = CheckSide(side, minePositions, row, column);
                if (hasMine)
                {
                    minesCounted++;
                }
            }

            return char.Parse(minesCounted.ToString());
        }

        private static bool CheckSide(string side, char[,] board, int row, int column)
        {
            int columnForTest;
            int rowForTest;

            switch (side)
            {
                case "left":
                    columnForTest = column;
                    rowForTest = row - 1;
                    break;
                case "right":
                    columnForTest = column;
                    rowForTest = row + 1;
                    break;
                case "top":
                    columnForTest = column - 1;
                    rowForTest = row;
                    break;
                case "bottom":
                    columnForTest = column + 1;
                    rowForTest = row;
                    break;
                case "top-left":
                    columnForTest = column - 1;
                    rowForTest = row - 1;
                    break;
                case "bottom-left":
                    columnForTest = column + 1;
                    rowForTest = row - 1;
                    break;
                case "top-right":
                    columnForTest = column - 1;
                    rowForTest = row + 1;
                    break;
                case "bottom-right":
                    columnForTest = column + 1;
                    rowForTest = row + 1;
                    break;
                default:
                    throw new ArgumentException("Unexpected swich case for Check Side");
            }

            try
            {
                if (board[rowForTest, columnForTest] == '*')
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

            return false;
        }
    }
}
