namespace ConsoleWebServer.Framework.ContentActions.Results
{
    using System.Collections.Generic;
    using ConsoleWebServer.Framework.Requests;

    public class ContentActionResultWithCors<TResult> : ContentActionResult
    {
        public ContentActionResultWithCors(HttpRequest request, object model, string corsSettings)
            : base(request, model)
        {
            ResponseHeaders
                .Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        }
    }
}