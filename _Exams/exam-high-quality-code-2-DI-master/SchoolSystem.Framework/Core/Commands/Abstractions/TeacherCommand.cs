namespace SchoolSystem.Framework.Core.Commands.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Contracts;
    using Models.Contracts;

    public abstract class TeacherCommand : ICommand
    {
        protected TeacherCommand(
            IRepository<ITeacher> teachersRepository)
        {
            this.ValidateNonNullParameters(teachersRepository);

            this.TeachersRepository = teachersRepository;
        }

        protected IRepository<ITeacher> TeachersRepository { get; }

        public abstract string Execute(IList<string> parameters);

        protected void ValidateNonNullParameters(params object[] parameters)
        {
            if (parameters.Any(parameter => parameter == null))
            {
                throw new ArgumentNullException();
            }
        }
    }
}