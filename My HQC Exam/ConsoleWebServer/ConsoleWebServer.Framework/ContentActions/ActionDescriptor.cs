namespace ConsoleWebServer.Framework.ContentActions
{
    using System;
    using System.Linq;

    public class ActionDescriptor
    {
        public ActionDescriptor(string uri)
        {
            uri = uri ?? string.Empty;

            var uriParts = uri.Split(
                new[] { '/', '/', '/', '/', '/' }
                    .ToList()
                    .AsEnumerable()
                    .AsQueryable()
                    .ToArray(),
                StringSplitOptions.RemoveEmptyEntries);

            this.ControllerName = uriParts.Length >
                             0
                ? uriParts[0]
                : "Home";

            this.ActionName = uriParts.Length >
                         1
                ? uriParts[1]
                : "Index";

            this.Parameter = uriParts.Length >
                        2
                ? uriParts[2]
                : "Param";
        }

        public string ActionName { get; }

        public string ControllerName { get; }

        public string Parameter { get; }

        public override string ToString()
        {
            return string.Format(
                "/{0}/{1}/{2}",
                this.ControllerName, 
                this.ActionName,
                this.Parameter);
        }
    }
}