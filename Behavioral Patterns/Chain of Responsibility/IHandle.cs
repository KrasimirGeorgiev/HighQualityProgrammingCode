namespace ChainOfResponsibility
{
    using ChainOfResponsibility.Requests;

    public interface IHandle
    {
        void Handle(StorageRequest request);
    }
}
