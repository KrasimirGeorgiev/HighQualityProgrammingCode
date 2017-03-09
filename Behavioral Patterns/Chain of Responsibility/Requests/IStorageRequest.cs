namespace ChainOfResponsibility.Requests
{
    public interface IStorageRequest
    {
        int StatusCode { get; }

        object Body { get; }

        string Message { get; }
    }
}
