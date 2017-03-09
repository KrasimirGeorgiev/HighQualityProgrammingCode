namespace ConsoleWebServer.Framework.Requests.Proccessors
{
    public interface IRequestProccessor
    {
        HttpResponse ProccessRequest(HttpRequest request);
    }
}