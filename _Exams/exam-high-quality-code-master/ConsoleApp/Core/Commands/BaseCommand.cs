namespace SchoolSystem.ConsoleApp.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(IDataStore dataStore)
        {
            this.DataStore = dataStore;
        }

        protected IDataStore DataStore { get; }

        public abstract string Execute(IList<string> arguments);
    }
}