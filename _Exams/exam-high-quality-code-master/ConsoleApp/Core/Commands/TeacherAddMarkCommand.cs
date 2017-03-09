namespace SchoolSystem.ConsoleApp.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    internal class TeacherAddMarkCommand : BaseCommand, ICommand
    {
        public TeacherAddMarkCommand(IDataStore dataStore)
            : base(dataStore)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            var teacherId = int.Parse(arguments[0]);
            var studentId = int.Parse(arguments[1]);

            var student = this.DataStore.Students.Get(studentId);
            var teacher = this.DataStore.Teachers.Get(teacherId);
            var markValue = float.Parse(arguments[2]);

            teacher.AddMark(student, markValue);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
