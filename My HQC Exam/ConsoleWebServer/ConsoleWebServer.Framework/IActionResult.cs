using ConsoleWebServer.Framework.TransferProtocols;

public interface IActionResult
{
    HttpResponse GetResponse();
}