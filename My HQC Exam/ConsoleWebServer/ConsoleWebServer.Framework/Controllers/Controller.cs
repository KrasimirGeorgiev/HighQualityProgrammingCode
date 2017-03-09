namespace ConsoleWebServer.Framework.Controllers
{
    using ConsoleWebServer.Framework.ContentActions.Results;
    using ConsoleWebServer.Framework.ContentActions.Results.Json;
    using Requests;

    public abstract class Controller
    {
        protected Controller(HttpRequest r)
        {
            this.Request = r;
        }

        public HttpRequest Request { get; private set; }

        protected IActionResult Content(object model)
        {
            return new ContentActionResult(this.Request, model);
        }

        protected IActionResult Json(object model)
        {
            return new JsonActionResult(this.Request, model);
        }
    }
}
