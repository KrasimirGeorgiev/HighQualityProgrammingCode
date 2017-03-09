namespace SchoolSystem.ConsoleApp
{
    using Core;
    using Core.UserInterface;

    internal class Startup
    {
        private static void Main()
        {
            var engine = CreateEngine();
            engine.Run();
        }

        private static Engine CreateEngine()
        {
            var inputReaded = new ConsoleReader();
            var outputWriter = new ConsoleWriter();
            var dataStore = new DataStore();
            var engine = new Engine(inputReaded, outputWriter, dataStore);

            return engine;
        }
    }
}
