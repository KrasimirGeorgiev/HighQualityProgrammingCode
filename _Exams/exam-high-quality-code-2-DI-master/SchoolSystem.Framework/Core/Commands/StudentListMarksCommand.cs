using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    using Abstractions;
    using Data.Contracts;
    using Models.Contracts;

    public class StudentListMarksCommand : StudentCommand, ICommand
    {
        public StudentListMarksCommand(IRepository<IStudent> studentsRepository)
            : base(studentsRepository)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.StudentsRepository.Get(studentId);

            return student.ListMarks();
        }
    }
}
