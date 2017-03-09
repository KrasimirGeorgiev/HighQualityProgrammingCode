namespace ConsoleWebServer.Framework.Requests
{
    using System;
    using System.Net;
    using ConsoleWebServer.Framework.Requests.HttpExceptions;
    using ConsoleWebServer.Framework.Requests.Proccessors;
    using ConsoleWebServer.Framework.Requests.RequestTools;

    public class ResponseProvider : IResponseProvider
    {
        private const string CantHandleErrorMessage = "Request cannot be handled.";

        private readonly IRequestParser requestParser;

        private IRequestProccessor requestProccessor;

        // Poor Man's Inversion of control
        public ResponseProvider() : this(new RequestParser(), new RequestProccessor())
        {
        }

        // Dependency Inversion and Liskov Substitution Principles
        public ResponseProvider(
            IRequestParser requestParser, IRequestProccessor requestProccessor)
        {
            this.requestParser = requestParser;
            this.requestProccessor = requestProccessor;
        }

        public HttpResponse GetResponse(string requestAsString)
        {
            HttpRequest request;

            try
            {
                request = this.requestParser.Parse(requestAsString);
            }
            catch (ParserException ex)
            {
                // Changed the caught to concrete exception
                return new HttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }

            var response = this.requestProccessor.ProccessRequest(request);

            return response;
        }
    }
}