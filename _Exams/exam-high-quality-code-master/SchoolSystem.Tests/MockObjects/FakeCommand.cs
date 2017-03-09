namespace SchoolSystem.Tests.MockObjects
{
    using System;
    using System.Collections.Generic;
    using ConsoleApp.Core.Interfaces;

    public class FakeCommand : ICommand
    {
        public const string FakeSuccessMessage = "FakeCommand Executed with Successfully";

        public const string FakeErrorMessage = "Ne stana";

        public FakeCommand(string name)
        {
            this.CommandName = name;
            LastCreatedCommand = this;
        }

        public static FakeCommand LastCreatedCommand { get; private set; }

        public string CommandName { get; set; }

        public IList<string> LastCallArguments { get; set; }

        public string Execute(IList<string> arguments)
        {
            if (arguments.Count > 0)
            {
                this.LastCallArguments = arguments;
                return FakeSuccessMessage;
            }
            else
            {
                throw new ArgumentException(FakeErrorMessage);
            }
        }
    }
}