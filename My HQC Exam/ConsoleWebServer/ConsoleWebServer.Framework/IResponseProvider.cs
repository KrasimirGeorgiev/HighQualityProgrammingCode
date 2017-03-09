using ConsoleWebServer.Framework.TransferProtocols;

public interface IResponseProvider
{
    HttpResponse GetResponse(string requestAsString);
}



