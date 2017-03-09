namespace ConsoleWebServer.Framework.Requests.HttpExceptions
{
    using System;
    using ConsoleWebServer.Framework.ContentActions;

    public class ParserException : Exception
    {
        public ParserException(string message, ActionDescriptor request = null)
            : base(message)
        {
        }
    }
}