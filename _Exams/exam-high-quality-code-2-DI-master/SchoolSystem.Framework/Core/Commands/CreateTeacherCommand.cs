using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    using Abstractions;
    using Data.Contracts;
    using Factories.Contracts;
    using Models.Contracts;

    public class CreateTeacherCommand : TeacherCommand, ICommand
    {
        private readonly ITeacherFactory teacherFactory;
        private readonly IMarkFactory markFactory;

        public CreateTeacherCommand(
            IRepository<ITeacher> teachersRepository,
            ITeacherFactory teacherFactory,
            IMarkFactory markFactory)
            : base(teachersRepository)
        {
            this.ValidateNonNullParameters(teacherFactory, markFactory);
            this.teacherFactory = teacherFactory;
            this.markFactory = markFactory;
        }

        public override string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teacherFactory.CreateTeacher(firstName, lastName, subject, this.markFactory);

            var id = this.TeachersRepository.Add(teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {id} was created.";
        }
    }
}
