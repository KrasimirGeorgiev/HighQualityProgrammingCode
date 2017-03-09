namespace ConsoleWebServer.Framework.Requests.RequestTools
{
    using System.IO;
    using ConsoleWebServer.Framework.Requests.HttpExceptions;

    /// <summary>
    /// A Request Factory Class
    /// </summary>
    public class RequestParser : IRequestParser
    {
        private const string ParseErrorMessage =
            "Invalid format for the first request line. Expected format: [RequestMethod] [Uri] HTTP/[Version]";

        private StringReader textReader;

        public HttpRequest Parse(string reqAsStr)
        {
            this.textReader = new StringReader(reqAsStr);

            var requestLine = this.textReader.ReadLine();

            HttpRequest requestObject;

            requestObject = this.CreateRequest(requestLine);

            // Reads to the end of the request string, very nice while condition :*
            string line;
            while ((line = this.textReader.ReadLine()) != null)
            {
                this.AddHeaderToRequest(requestObject, line);
            }

            return requestObject;
        }

        public HttpRequest CreateRequest(string requestLine)
        {
            // Bug Fix NullReferenceException
            if (requestLine == null)
            {
                throw new ParserException(ParseErrorMessage);
            }

            var firstRequestLineParts = requestLine.Split(' ');

            if (firstRequestLineParts.Length != 3)
            {
                throw new ParserException(ParseErrorMessage);
            }

            var requestObject = new HttpRequest(
                firstRequestLineParts[0],
                firstRequestLineParts[1],
                firstRequestLineParts[2]);

            return requestObject;
        }

        public void AddHeaderToRequest(HttpRequest request, string headerLine)
        {
            var headerParts = headerLine.Split(new[] { ':' }, 2);

            var headerName = headerParts[0].Trim();

            var headerValue = headerParts.Length == 2 ? headerParts[1].Trim() : string.Empty;

            request.AddHeader(headerName, headerValue);
        }
    }
}
