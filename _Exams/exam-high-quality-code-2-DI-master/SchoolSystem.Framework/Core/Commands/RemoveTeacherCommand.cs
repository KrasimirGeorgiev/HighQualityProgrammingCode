using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    using Abstractions;
    using Data.Contracts;
    using Models.Contracts;

    public class RemoveTeacherCommand : TeacherCommand, ICommand
    {
        public RemoveTeacherCommand(IRepository<ITeacher> teachersRepository)
            : base(teachersRepository)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            try
            {
                this.TeachersRepository.Remove(teacherId);
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
