namespace Telerik.Homeworks.HighQualityCode.NamingIdentifiers.Task4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Minefield
    {
        public static char[,] CreateBoard(char symbol, int rows, int columns)
        {
            int boardRows = rows;
            int boardColumns = columns;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = symbol;
                }
            }

            return board;
        }

        public static void DisplayBoard(char[,] board)
        {
            int rowsLength = board.GetLength(0);
            int columnsLength = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rowsLength; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < columnsLength; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        public static char[,] AddMines(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            char[,] minePositions = CreateBoard('-', rows, columns);

            List<int> randomNumbers = GenerateRandomNumbers(Minesweeper.MaximumMines);

            foreach (int number in randomNumbers)
            {
                int divider = columns; 

                int col = number / divider;
                int row = number % divider;

                if (row == 0 && number != 0)
                {
                    col--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                minePositions[col, row - 1] = '*';
            }

            return minePositions;
        }

        private static List<int> GenerateRandomNumbers(int count)
        {
            var random = new Random();
            List<int> randomNumbers = new List<int>();

            for (int i = 0; i < count;)
            {
                int nextRandomNumber = random.Next(50);

                if (!randomNumbers.Contains(nextRandomNumber))
                {
                    randomNumbers.Add(nextRandomNumber);
                    i++;
                }
            }

            return randomNumbers;
        }
    }
}
