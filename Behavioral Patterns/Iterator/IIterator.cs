namespace Iterator
{
    public interface IIterator
    {
        void Next();

        bool IsDone();

        object CurrentItem();
    }
}
