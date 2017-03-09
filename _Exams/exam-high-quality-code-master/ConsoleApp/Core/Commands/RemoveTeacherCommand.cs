namespace SchoolSystem.ConsoleApp.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public class RemoveTeacherCommand : BaseCommand, ICommand
    {
        public RemoveTeacherCommand(IDataStore dataStore)
            : base(dataStore)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            this.DataStore.Teachers.Remove(id);

            return $"Teacher with ID {id} was sucessfully removed.";
        }
    }
}