namespace ConsoleWebServer.Framework.Requests.Proccessors
{
    public interface IRequestHandler
    {
        bool IsSuccessful { get; }

        HttpResponse Response { get; }

        void Handle(HttpRequest request);
    }
}
