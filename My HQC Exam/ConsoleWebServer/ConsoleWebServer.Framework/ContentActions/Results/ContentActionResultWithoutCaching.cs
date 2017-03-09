namespace ConsoleWebServer.Framework.ContentActions.Results
{
    using System.Collections.Generic;
    using ConsoleWebServer.Framework.Requests;

    public class ContentActionResultWithoutCaching : ContentActionResult
    {
        public ContentActionResultWithoutCaching(HttpRequest request, object model) : base(request, model)
        {
            ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}