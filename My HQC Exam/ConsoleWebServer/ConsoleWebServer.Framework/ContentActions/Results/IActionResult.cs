namespace ConsoleWebServer.Framework.ContentActions.Results
{
    using Requests;

    /// <summary>
    /// This interface provides variable request - responses (JSON object, plain Text etc...)
    /// </summary>
    public interface IActionResult
    {
        /// <summary>
        /// Used for getting a HTTP response from the server 
        /// </summary>
        /// <returns>An HttpResponse Successor</returns>
        HttpResponse GetResponse();
    }
}