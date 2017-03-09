namespace SchoolSystem.ConsoleApp.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Constants;
    using Interfaces;

    internal class StudentListMarksCommand : BaseCommand, ICommand
    {
        public StudentListMarksCommand(IDataStore dataStore)
            : base(dataStore)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            var student = this.DataStore.Students.Get(id);
            var marks = student.GetMarks();

            if (marks.Count > 0)
            {
                var stringBuilder = new StringBuilder();
                var formattedMarks = marks.Select(m => $"{m.Subject} => {m.Value}").ToList();

                stringBuilder.AppendLine("The student has these marks:")
                    .AppendLine(string.Join("\n", formattedMarks));

                return stringBuilder.ToString();
            }
            else
            {
                return ErrorMessages.NoMarks;
            }
        }
    }
}
