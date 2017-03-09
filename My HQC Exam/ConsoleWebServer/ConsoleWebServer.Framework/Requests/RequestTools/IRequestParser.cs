namespace ConsoleWebServer.Framework.Requests.RequestTools
{
    public interface IRequestParser
    {
        HttpRequest Parse(string reqAsStr);

        HttpRequest CreateRequest(string requestLine);

        void AddHeaderToRequest(HttpRequest request, string headerLine);
    }
}