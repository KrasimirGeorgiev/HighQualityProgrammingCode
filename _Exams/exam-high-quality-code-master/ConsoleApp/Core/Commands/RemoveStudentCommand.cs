namespace SchoolSystem.ConsoleApp.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public class RemoveStudentCommand : BaseCommand, ICommand
    {
        public RemoveStudentCommand(IDataStore dataStore)
            : base(dataStore)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            this.DataStore.Students.Remove(id);

            return $"Student with ID {id} was sucessfully removed.";
        }
    }
}
