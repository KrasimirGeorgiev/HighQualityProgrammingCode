﻿using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Providers
{
    using Factories.Contracts;

    public class CommandParserProvider : IParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParserProvider(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var command = this.commandFactory.CreateCommand(commandName);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return null;
            }

            return commandParts;
        }
    }
}
