namespace ConsoleWebServer.Framework.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ConsoleWebServer.Framework.ContentActions;

    public class HttpRequest
    {
        public HttpRequest(string requestMethod, string uri, string httpVersion)
        {
            this.ProtocolVersion = Version.Parse(
                httpVersion.ToLower().Replace("HTTP/".ToLower(), string.Empty));

            this.Headers = new SortedDictionary<string, ICollection<string>>();

            this.Uri = uri;

            // Todo Extract Different Requests Based on Method
            this.RequestMethod = requestMethod;

            this.Action = new ActionDescriptor(uri);
        }

        public Version ProtocolVersion { get; protected set; }

        // Create Headers Class
        public IDictionary<string, ICollection<string>> Headers { get; protected set; }

        public string Uri { get; private set; }

        public string RequestMethod { get; private set; }

        public ActionDescriptor Action { get; private set; }

        public void AddHeader(string name, string content)
        {
            if (!this.Headers.ContainsKey(name))
            {
                this.Headers.Add(name, new HashSet<string>(new List<string>()));
            }

            this.Headers[name].Add(content);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(
                string.Format(
                    "{0} {1} {2}{3}",
                    this.RequestMethod,
                    this.Action,
                    "HTTP/",
                    this.ProtocolVersion));

            var headerStringBuilder = new StringBuilder();

            foreach (var key in this.Headers.Keys)
            {
                headerStringBuilder.AppendLine(
                    string.Format(
                        "{0}: {1}",
                        key,
                        string.Join("; ", this.Headers[key])));
            }

            sb.AppendLine(headerStringBuilder.ToString());

            return sb.ToString();
        }
    }
}