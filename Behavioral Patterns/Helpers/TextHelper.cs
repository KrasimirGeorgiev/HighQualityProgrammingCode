namespace HomeworkHelpers
{
    using System;

    public class TextHelper
    {
        public void SetupConsole(
            ConsoleColor color = ConsoleColor.White
            , ConsoleColor background = ConsoleColor.Gray
            , int windowWidth = 120)
        {
            try
            {
                Console.BackgroundColor = background;
                Console.ForegroundColor = color;
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.SetWindowSize(windowWidth, Console.WindowHeight);
            }
            catch (Exception)
            {
                // Prevent Crashing if Console can't take any of the parameters
            }
            finally
            {
                Console.Clear();
            }
        }

        public void Restart(Action restartCallback)
        {
            Console.WriteLine();
            this.PrintHeading("PRESS ANY KEY TO RESTART or Ctrl + C to exit");
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.CursorVisible = true;

            restartCallback();
        }

        public void PrintColorText(string text, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(text);

            Console.ForegroundColor = previousColor;
        }

        public void PrintColorText(string text, ConsoleColor color, ConsoleColor background)
        {
            var previousBackground = Console.BackgroundColor;
            Console.BackgroundColor = background;

            this.PrintColorText(text, color);

            Console.BackgroundColor = previousBackground;
        }

        public void PrintColorText(string text, string color)
        {
            switch (color.ToLower())
            {
                case "green":
                    this.PrintColorText(text, ConsoleColor.Green);
                    break;
                case "cyan":
                    this.PrintColorText(text, ConsoleColor.Cyan);
                    break;
                case "white":
                    this.PrintColorText(text, ConsoleColor.White);
                    break;
                case "red":
                    this.PrintColorText(text, ConsoleColor.Red);
                    break;
                case "gray":
                    this.PrintColorText(text, ConsoleColor.Gray);
                    break;
                default:
                    Console.Write(text);
                    break;
            }
        }

        public string ReadConsoleInColor(ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            string input = Console.ReadLine();

            Console.ForegroundColor = previousColor;

            return input;
        }

        public void PrintHeading(string text, ConsoleColor color = ConsoleColor.White)
        {
            int totalWidth = Console.WindowWidth;
            string format = string.Format(" {0} ", text);
            char paddingChar = ' ';
            var paddingColor = ConsoleColor.White;
            var backgorundColor = ConsoleColor.DarkGray;
            int freeWidth = totalWidth - format.Length;

            this.PrintColorText(new string(paddingChar, totalWidth), paddingColor, backgorundColor);
            this.PrintColorText(new string(paddingChar, freeWidth / 2), paddingColor, backgorundColor);
            this.PrintColorText(format, color, backgorundColor);
            this.PrintColorText(new string(paddingChar, freeWidth / 2), paddingColor, backgorundColor);
            this.PrintColorText(new string(paddingChar, totalWidth), paddingColor, backgorundColor);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
