namespace SchoolSystem.ConsoleApp.Core.UserInterface
{
    /// <summary>
    /// Provides a way to write output data to the end user
    /// </summary>
    public interface IWriter
    {
        void WriteLine(object data);

        void WriteLine(string formatString, params object[] args);
    }
}