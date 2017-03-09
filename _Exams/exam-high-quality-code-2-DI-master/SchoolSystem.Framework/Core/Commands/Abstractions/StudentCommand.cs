namespace SchoolSystem.Framework.Core.Commands.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Contracts;
    using Models.Contracts;

    public abstract class StudentCommand : ICommand
    {
        protected StudentCommand(IRepository<IStudent> studentsRepository)
        {
            this.ValidateNonNullParameters(studentsRepository);

            this.StudentsRepository = studentsRepository;
        }

        protected IRepository<IStudent> StudentsRepository { get; }

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
