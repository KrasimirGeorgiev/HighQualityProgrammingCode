using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    using System;
    using Abstractions;
    using Data.Contracts;
    using Models.Contracts;

    public class TeacherAddMarkCommand : TeacherCommand, ICommand
    {
        private readonly IRepository<IStudent> studentsRepository;

        public TeacherAddMarkCommand(
            IRepository<ITeacher> teachersRepository, IRepository<IStudent> studentsRepository)
            : base(teachersRepository)
        {
            this.ValidateNonNullParameters(studentsRepository);
            this.studentsRepository = studentsRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = this.studentsRepository.Get(studentId);
            var teacher = this.TeachersRepository.Get(teacherId);

            teacher.AddMark(student, mark);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }

        private void ValidateParameters(IList<string> parameters)
        {
            if (parameters.Count < 3)
            {
                throw new ArgumentException($"Invalid parameters count: {parameters.Count}, required 3");
            }
        }
    }
}
