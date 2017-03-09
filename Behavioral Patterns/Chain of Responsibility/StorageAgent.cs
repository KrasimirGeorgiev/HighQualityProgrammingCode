namespace ChainOfResponsibility
{
    using System.Collections.Generic;
    using ChainOfResponsibility.Requests;

    public class StorageAgent
    {
        public StorageAgent(Queue<IHandle> chainOfResponse) 
        {
            this.Chain = chainOfResponse;
        }
     
        public string Handle(object request, RequestType type)
        {
            var currentRequest = new StorageRequest(request, type);
            
            foreach (var handler in this.Chain)
            {
                handler.Handle(currentRequest);
                if (currentRequest.Result)
                {
                    break;
                }
            }

            return currentRequest.ToString();
        }

        public Queue<IHandle> Chain { get; set; }
    }
}
