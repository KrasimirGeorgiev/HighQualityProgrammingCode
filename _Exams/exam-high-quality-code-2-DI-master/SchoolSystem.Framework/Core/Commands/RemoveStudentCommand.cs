using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    using System;
    using Abstractions;
    using Data.Contracts;
    using Models.Contracts;

    public class RemoveStudentCommand : StudentCommand, ICommand
    {
        public RemoveStudentCommand(IRepository<IStudent> studentsRepository)
            : base(studentsRepository)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count == 0)
            {
                throw new ArgumentException("Called with empty arguments list");
            }

            var studentId = int.Parse(parameters[0]);
            this.StudentsRepository.Remove(studentId);

            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
