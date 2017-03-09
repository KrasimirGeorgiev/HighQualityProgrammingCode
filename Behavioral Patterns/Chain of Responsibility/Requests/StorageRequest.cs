namespace ChainOfResponsibility.Requests
{
    public class StorageRequest : IStorageRequest
    {
        public StorageRequest(object request, RequestType type)
        {
            this.Body = request;
            this.Type = type;
            this.StatusCode = 0;
        }

        public object Body { get; set; }

        public string HandledBy { get; set; }

        public string Message { get; set; }

        public bool Result { get; set; }

        public int StatusCode { get; set; }

        public RequestType Type { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Request: \n\tStatus: {0};\n\tType: {1};\n\tResult: {2};\n\tMessage: {3};\n\tHandled By: {4};"
                , this.StatusCode, this.Type, this.Result ? "Success" : "Failed", this.Message, this.HandledBy);
        }
    }
}
