namespace ConsoleWebServer.Framework.Requests
{
    /// <summary>
    /// This interface provides interchangeble request handler through implementation of its method
    /// </summary>
    public interface IResponseProvider
    {
        /// <summary>
        /// This method defines the way to request a response e.g. using a string which should be parsed
        /// </summary>
        /// <param name="requestAsString">The string content of the request body</param>
        /// <returns>The produced Http Response from the input string</returns>
        HttpResponse GetResponse(string requestAsString);
    }
}