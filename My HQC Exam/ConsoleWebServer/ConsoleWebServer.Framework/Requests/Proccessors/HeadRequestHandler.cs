namespace ConsoleWebServer.Framework.Requests.Proccessors
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using ConsoleWebServer.Framework.ContentActions.Results;
    using ConsoleWebServer.Framework.Controllers;

    public class HeadRequestHandler : RequestHandler, IRequestHandler
    {
        public override void Handle(HttpRequest request)
        {
            // Todo Refactor...
            if (request.RequestMethod == "HEAD")
            {
                var routes =
                    Assembly.GetEntryAssembly()
                        .GetTypes()
                        .Where(x => x.Name.EndsWith("Controller") && typeof(Controller).IsAssignableFrom(x))
                        .Select(
                            x =>
                                new
                                {
                                    x.Name,
                                    Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IActionResult))
                                })
                        .SelectMany(
                            x =>
                                x.Methods.Select(
                                    m =>
                                        string.Format(
                                            "/{0}/{1}/{{parameter}}", x.Name.Replace("Controller", string.Empty), m.Name)))
                        .ToList();

                this.Response = new HttpResponse(
                    request.ProtocolVersion,
                    HttpStatusCode.OK,
                    string.Join(Environment.NewLine, routes));

                this.IsSuccessful = true;
            }
            else
            {
                this.IsSuccessful = false;
            }
        }
    }
}
