namespace ConsoleWebServer.Framework.ContentActions.Results
{
    using System.Collections.Generic;
    using ConsoleWebServer.Framework.Requests;

    public class ContentActionResultWithCorsWithoutCaching : ContentActionResult
    {
        public ContentActionResultWithCorsWithoutCaching(HttpRequest request, object model, string corsSettings)
            : base(request, model)
        {
            ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
            ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}