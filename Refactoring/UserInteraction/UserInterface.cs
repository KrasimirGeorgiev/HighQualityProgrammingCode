namespace GameFifteen.UserInteraction
{
    public abstract class UserInterface : IReader, IWriter
    {
        public abstract string ReadLine();

        public abstract void Write(object data, params object[] arguments);

        public abstract void WriteLine(object data, params object[] arguments);
    }
}
