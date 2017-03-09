namespace GameFifteen.UserInteraction
{
    public interface IWriter
    {
        void Write(object data, params object[] arguments);

        void WriteLine(object data, params object[] arguments);
    }
}