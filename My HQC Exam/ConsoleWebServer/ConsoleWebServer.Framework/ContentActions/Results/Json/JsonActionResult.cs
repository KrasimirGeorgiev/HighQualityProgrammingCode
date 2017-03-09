namespace ConsoleWebServer.Framework.ContentActions.Results.Json
{
    using System.Collections.Generic;
    using System.Net;
    using ConsoleWebServer.Framework.Requests;
    using Newtonsoft.Json;

    public class JsonActionResult : IActionResult
    {
        private const string ContentType = "application/json";

        public JsonActionResult(HttpRequest request, object model)
        {
            this.Model = model;
            this.Request = request;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public HttpRequest Request { get; private set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public object Model { get; private set; }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(this.Model);
        }

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(
                this.Request.ProtocolVersion, this.GetStatusCode(), this.GetContent(), ContentType);

            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}