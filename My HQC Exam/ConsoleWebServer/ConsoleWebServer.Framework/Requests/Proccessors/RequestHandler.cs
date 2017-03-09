namespace ConsoleWebServer.Framework.Requests.Proccessors
{
    public abstract class RequestHandler : IRequestHandler
    {
        public bool IsSuccessful { get; protected set; }

        public HttpResponse Response { get; protected set; }

        public abstract void Handle(HttpRequest request);
    }
}
