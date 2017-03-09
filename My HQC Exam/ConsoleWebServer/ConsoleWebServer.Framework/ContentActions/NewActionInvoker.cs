namespace ConsoleWebServer.Framework.ContentActions
{
    using ConsoleWebServer.Framework.ContentActions.Results;
    using ConsoleWebServer.Framework.Controllers;

    public class NewActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }
    }
}
