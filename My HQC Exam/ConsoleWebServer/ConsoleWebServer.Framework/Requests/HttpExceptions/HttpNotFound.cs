namespace ConsoleWebServer.Framework.Requests.HttpExceptions
{
    using System;

    public class HttpNotFound : Exception
    {
        public const string ClassName = "HttpNotFoundException";

        public HttpNotFound(string message) : base(message)
        {
        }
    }
}