namespace SchoolSystem.ConsoleApp.Core.Commands
{
    using System.Collections.Generic;
    using DataModels.Enums;
    using DataModels.Models;
    using Interfaces;

    internal class CreateTeacherCommand : BaseCommand, ICommand
    {
        public CreateTeacherCommand(IDataStore dataStore)
            : base(dataStore)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            string firstName = arguments[0];
            string lastName = arguments[1];
            Subject subject = (Subject)int.Parse(arguments[2]);

            var teacher = new Teacher(firstName, lastName, subject);
            int id = this.DataStore.Teachers.Add(teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {id} was created.";
        }
    }
}
