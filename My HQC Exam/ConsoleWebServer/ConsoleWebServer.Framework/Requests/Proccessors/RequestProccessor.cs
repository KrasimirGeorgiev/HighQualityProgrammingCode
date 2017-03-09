namespace ConsoleWebServer.Framework.Requests.Proccessors
{
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// This Class implements the Chain of Responsibility pattern with the help of a Queue representing 
    /// the actual chain
    /// </summary>
    public class RequestProccessor : IRequestProccessor
    {
        private const string CantHandleErrorMessage = "Request cannot be handled.";

        // The queue is the actual chain, since a queue is sequential the chain can be setup to be a Hierarchy
        private Queue<IRequestHandler> handlers;

        public RequestProccessor()
        {
            this.handlers = new Queue<IRequestHandler>();

            this.handlers.Enqueue(new OptionsRequestHandler());
            this.handlers.Enqueue(new FileRequestHandler());
            this.handlers.Enqueue(new UriRequestHandler());
        }

        // Open to expansion
        public RequestProccessor(Queue<IRequestHandler> handlers)
        {
            this.handlers = handlers;
        }

        /// <summary>
        /// In this method the Liskov Substitution Principle can be observed. The method is 
        /// Proccessing request through polymorfism calling handler.Handle() where handler is 
        /// a successor of an interface 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpResponse ProccessRequest(HttpRequest request)
        {
            foreach (IRequestHandler handler in this.handlers)
            {
                handler.Handle(request);

                if (handler.IsSuccessful)
                {
                    return handler.Response;
                }
            }

            // If no handler did resolve the request an 'invalid request' response is returned
            return new HttpResponse(
                    request.ProtocolVersion,
                    HttpStatusCode.NotImplemented,
                    CantHandleErrorMessage);
        }
    }
}
