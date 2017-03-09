namespace ConsoleWebServer.Framework.ContentActions
{
    using System.Linq;
    using System.Reflection;
    using ConsoleWebServer.Framework.ContentActions.Results;
    using ConsoleWebServer.Framework.Controllers;
    using ConsoleWebServer.Framework.Requests.HttpExceptions;

    public class ActionInvoker
    {
        public IActionResult InvokeAction(Controller c, ActionDescriptor ad)
        {
            var methodWithIntParameter = c.GetType()
                .GetMethods().FirstOrDefault(x => x.Name.ToLower() == ad.ActionName.ToLower() && x.GetParameters().Length == 1
                                                  && x.GetParameters()[0].ParameterType == typeof(string) && x.ReturnType == typeof(IActionResult));

            if (methodWithIntParameter == null)
            {
                throw new HttpNotFound(
                    string.Format(
                        "Expected method with signature IActionResult {0}(string) in class {1}Controller",
                        ad.ActionName,
                        ad.ControllerName));
            }

            try
            {
                var actionResult =
                    (IActionResult)methodWithIntParameter.Invoke(c, new object[] { ad.Parameter });

                return actionResult;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}