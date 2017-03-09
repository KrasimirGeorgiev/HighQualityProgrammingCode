namespace SchoolSystem.ConsoleApp.Core.UserInterface
{
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object data)
        {
            Console.WriteLine(data);
        }

        public void WriteLine(string formatString, params object[] args)
        {
            Console.WriteLine(formatString, args);
        }
    }
}
