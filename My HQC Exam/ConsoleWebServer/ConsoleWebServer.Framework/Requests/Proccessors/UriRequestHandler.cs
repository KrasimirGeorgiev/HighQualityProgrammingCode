namespace ConsoleWebServer.Framework.Requests.Proccessors
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using ConsoleWebServer.Framework.ContentActions;
    using ConsoleWebServer.Framework.Controllers;
    using ConsoleWebServer.Framework.Requests.HttpExceptions;

    public class UriRequestHandler : RequestHandler, IRequestHandler
    {
        public override void Handle(HttpRequest request)
        {
            if (request.ProtocolVersion.Major <= 3)
            {
                HttpResponse response;
                try
                {
                    var controller = this.CreateController(request);
                    var actionInvoker = new NewActionInvoker();
                    var actionResult = actionInvoker.InvokeAction(controller, request.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpNotFound exception)
                {
                    response = new HttpResponse(
                        request.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    response = new HttpResponse(
                        request.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
                }

                this.Response = response;
                this.IsSuccessful = true;
            }
            else
            {
                this.IsSuccessful = false;
            }
        }

        private Controller CreateController(HttpRequest request)
        {
            var controllerClassName = request.Action.ControllerName + "Controller";
            var type =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(
                        x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));
            if (type == null)
            {
                throw new HttpNotFound(
                    string.Format("Controller with name {0} not found!", controllerClassName));
            }

            var instance = (Controller)Activator.CreateInstance(type, request);

            return instance;
        }
    }
}
