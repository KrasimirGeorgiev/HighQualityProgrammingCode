namespace SchoolSystem.ConsoleApp.Core.UserInterface
{
    using System;

    internal class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}