namespace ConsoleWebServer.Framework.Requests.Proccessors
{
    using System;

    public class FileRequestHandler : RequestHandler, IRequestHandler
    {
        public override void Handle(HttpRequest request)
        {
            if (this.CanHandle(request))
            {
                this.Response = new StaticFileHandler().Handle(request);
                this.IsSuccessful = true;
            }
            else
            {
                this.IsSuccessful = false;
            }
        }

        public bool CanHandle(HttpRequest request)
        {
            return request.Uri.LastIndexOf(".", StringComparison.Ordinal)
                   > request.Uri.LastIndexOf("/", StringComparison.Ordinal);
        }
    }
}
