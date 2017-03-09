namespace SchoolSystem.Tests.MockObjects
{
    using ConsoleApp.Core;
    using ConsoleApp.Core.Interfaces;
    using ConsoleApp.Core.UserInterface;

    internal class TestEngine : Engine
    {
        public TestEngine(IReader inputReaded, IWriter outputWriter, IDataStore dataStore)
            : base(inputReaded, outputWriter, dataStore)
        {
        }

        protected override ICommand CreateCommand(string commandName)
        {
            return new FakeCommand(commandName);
        }
    }
}