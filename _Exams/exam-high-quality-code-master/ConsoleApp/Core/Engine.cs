namespace SchoolSystem.ConsoleApp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Constants;
    using Interfaces;
    using UserInterface;

    internal class Engine
    {
        private readonly IReader inputReaded;
        private readonly IWriter outputWriter;
        private readonly IDataStore dataStore;

        public Engine(IReader inputReaded, IWriter outputWriter, IDataStore dataStore)
        {
            this.inputReaded = inputReaded;
            this.outputWriter = outputWriter;
            this.dataStore = dataStore;
        }

        public void Run()
        {
            string commandLine;
            while ((commandLine = this.inputReaded.ReadLine()) != InputStrings.EndOfInput)
            {
                try
                {
                    IList<string> arguments = this.ParseArguments(commandLine);
                    ICommand command = this.CreateCommand(arguments[0]);
                    IList<string> commandParameters = arguments.Skip(1).ToList();

                    string result = command.Execute(commandParameters);
                    this.outputWriter.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.outputWriter.WriteLine(ex.Message);
                }
            }
        }

        // Method is protected to be exposed in testing through override
        protected virtual ICommand CreateCommand(string commandName)
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;

            var typeInfo = assembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .FirstOrDefault(type => type.Name.ToLower().Contains(commandName.ToLower()));

            if (typeInfo == null)
            {
                throw new ArgumentException(ErrorMessages.CommandNotFound);
            }

            var command = Activator.CreateInstance(typeInfo, this.dataStore) as ICommand;
            return command;
        }

        private IList<string> ParseArguments(string commandLine)
        {
            var arguments = commandLine.Split(' ').ToList();
            return arguments;
        }
    }
}
