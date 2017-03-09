using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    using System;
    using Abstractions;
    using Data;
    using Data.Contracts;
    using DataModels;
    using Factories.Contracts;
    using Models.Contracts;

    public class CreateStudentCommand : StudentCommand, ICommand
    {
        private readonly IStudentFactory studentFactory;

        public CreateStudentCommand(IRepository<IStudent> studentsRepository, IStudentFactory studentFactory)
            : base(studentsRepository)
        {
            this.ValidateNonNullParameters(studentFactory);
            this.studentFactory = studentFactory;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = this.GetGrade(parameters[2]);

            var student = this.studentFactory.CreateStudent(firstName, lastName, grade);
            var id = this.StudentsRepository.Add(student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {id} was created.";
        }

        private void ValidateParameters(IList<string> parameters)
        {
            if (parameters.Count < 3)
            {
                throw new ArgumentException($"Invalid parameters count: {parameters.Count}, required 3");
            }
        }

        private Grade GetGrade(string gradeString)
        {
            var gradeValue = int.Parse(gradeString);

            if (gradeValue < Constraints.MinGrade || gradeValue > Constraints.MaxGrade)
            {
                throw new ArgumentException("Invalid Grade");
            }

            return (Grade)gradeValue;
        }
    }
}
