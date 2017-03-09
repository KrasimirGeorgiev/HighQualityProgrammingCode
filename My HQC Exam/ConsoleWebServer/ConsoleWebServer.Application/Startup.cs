// TODO: Describe patterns, SOLID, bugs and bottleneck in Documentation.txt

using System;
using System.Text;
using ConsoleWebServer.Framework.Requests;

public static class Startup
{
    public static void Main()
    {
        var responseProvider = new ResponseProvider();

        var requestBuilder = new StringBuilder();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != null)
        {
            // Smells
            if (string.IsNullOrWhiteSpace(inputLine))
            {
                HttpResponse response = responseProvider.GetResponse(requestBuilder.ToString());

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(response);
                Console.ResetColor();

                requestBuilder.Clear();

                continue;
            }

            requestBuilder.AppendLine(inputLine);
        }
    }
}
