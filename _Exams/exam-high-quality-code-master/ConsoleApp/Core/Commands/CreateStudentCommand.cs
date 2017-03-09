namespace SchoolSystem.ConsoleApp.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using DataModels;
    using DataModels.Enums;
    using DataModels.Models;
    using Interfaces;

    internal class CreateStudentCommand : BaseCommand, ICommand
    {
        public CreateStudentCommand(IDataStore dataStore)
            : base(dataStore)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            string firstName = arguments[0];
            string lastName = arguments[1];
            int gradeValue = int.Parse(arguments[2]);
            this.ValidateGrade(gradeValue);

            Grade grade = (Grade)gradeValue;
            var student = new Student(firstName, lastName, grade);
            int id = this.DataStore.Students.Add(student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {id} was created.";
        }

        private void ValidateGrade(int grade)
        {
            if (grade < Constraints.MinGrade || grade > Constraints.MaxGrade)
            {
                throw new ArgumentException("Invalid Grade");
            }
        }
    }
}
