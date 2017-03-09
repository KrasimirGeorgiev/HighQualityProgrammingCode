namespace Telerik.Homeworks.HighQualityCode.NamingIdentifiers.Task4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Minesweeper
    {
        public const int MaximumMines = 14;

        private static char[,] minefield = Minefield.CreateBoard('?', 5, 10);
        private static char[,] minePositions = Minefield.AddMines(minefield);
        private static int maximumScore =
            (minefield.GetLength(0) * minefield.GetLength(1)) - MaximumMines;

        private static int turnsCounter = 0;
        private static bool steppedOnMine = false;
        private static int row;
        private static int column;
        private static bool newGameIsStarting = true;
        private static bool topScoreReached = false;

        private static void Main()
        {
            string command = string.Empty;

            do
            {
                if (newGameIsStarting)
                {
                    Console.WriteLine(
                        "Lets play 'Minesweeper'.Try to find the fileds without mines." +
                        " Each turn input a row and a column to check for mines" +
                        " Input 'top' to show the top scores, 'restart' to start a new game, 'exit' to exit the game!");

                    Minefield.DisplayBoard(minefield);
                    newGameIsStarting = false;
                }

                Console.Write("Enter row and column : ");
                string userInput = Console.ReadLine().Trim();

                command = ParseCommand(userInput);

                switch (command)
                {
                    case "top":
                        Score.ShowScores();
                        break;

                    case "restart":
                        ResetGame();
                        break;

                    case "exit":
                        Console.WriteLine("\nGoodbye!");
                        break;

                    case "turn":
                        MakeTurn();
                        break;

                    default:
                        Console.WriteLine("\nError, invalid input\n");
                        break;
                }

                if (steppedOnMine)
                {
                    Minefield.DisplayBoard(minePositions);

                    Console.WriteLine("\nYou encountered a mine, your score: {0}.", turnsCounter);

                    SaveScore();

                    ResetGame();
                }

                if (topScoreReached)
                {
                    Console.WriteLine("\nCongratulations! You solved the minefield.");
                    Minefield.DisplayBoard(minePositions);

                    SaveScore();

                    Score.ShowScores();

                    ResetGame();
                }
            } 
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria");
            Console.WriteLine("Press any key . . .");
            Console.Read();
        }

        private static string ParseCommand(string command)
        {
            // Special case if the player inputs "turn" 
            // it interferes with the swich case for command
            if (command == "turn")
            {
                return "default";
            }

            try
            {
                int[] commandAsArray = command
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                if (commandAsArray.Length != 2)
                {
                    return command;
                }

                row = commandAsArray[0];
                column = commandAsArray[1];

                int rowLimit = minefield.GetLength(0);
                int columnLimit = minefield.GetLength(1);

                if (column >= 0 && column < columnLimit &&
                        row >= 0 && row < rowLimit)
                {
                    return "turn";
                }
            }
            catch (FormatException)
            {
                return command;
            }
            catch (ArgumentException)
            {
                return command;
            }           

            return command;
        }

        private static void SaveScore()
        {
            Console.Write("Enter your nickname: ");
            string nick = Console.ReadLine();

            var playerScore = new Score(nick, turnsCounter);
            Score.Add(playerScore);
        }

        private static void ResetGame()
        {
            minefield = Minefield.CreateBoard('?', 5, 10);
            minePositions = Minefield.AddMines(minefield);
            turnsCounter = 0;
            steppedOnMine = false;
            newGameIsStarting = true;
            Console.WriteLine("\n");
        }

        private static void MakeTurn()
        {
            if (minePositions[row, column] != '*')
            {
                if (minePositions[row, column] == '-')
                {
                    RevealSquareInformation();
                    turnsCounter++;
                }

                if (maximumScore == turnsCounter)
                {
                    topScoreReached = true;
                }
                else
                {
                    Minefield.DisplayBoard(minefield);
                }
            }
            else
            {
                steppedOnMine = true;
            }
        }

        private static void RevealSquareInformation()
        {
            char minesAroundCurrentPosition = FieldChecks
                .CountMinesAround(minePositions, row, column);

            minePositions[row, column] = minesAroundCurrentPosition;
            minefield[row, column] = minesAroundCurrentPosition;
        }
    }
}
