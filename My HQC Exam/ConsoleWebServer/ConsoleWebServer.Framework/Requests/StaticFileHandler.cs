﻿namespace ConsoleWebServer.Framework.Requests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class StaticFileHandler
    {
        // Extract check elsewhere
        public bool CanHandle(HttpRequest request)
        {
            return request.Uri.LastIndexOf(".", StringComparison.Ordinal)
                   > request.Uri.LastIndexOf("/", StringComparison.Ordinal);
        }

        public HttpResponse Handle(HttpRequest request)
        {
            string filePath = Environment.CurrentDirectory + "/" + request.Uri;

            if (!this.FileExists("C:\\", filePath, 3))
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, "File not found");
            }

            string fileContents = File.ReadAllText(filePath);

            var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);

            return response;
        }

        private bool FileExists(string path, string filePath, int depth)
        {
            if (depth <= 0)
            {
                return File.Exists(filePath);
            }

            try
            {
                var f = Directory.GetFiles(path);
                if (f.Contains(filePath))
                {
                    return true;
                }

                var d = Directory.GetDirectories(path);

                foreach (var dd in d)
                {
                    if (this.FileExists(dd, filePath, depth - 1))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}