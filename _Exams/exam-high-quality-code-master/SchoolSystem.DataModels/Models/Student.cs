namespace SchoolSystem.DataModels.Models
{
    using System;
    using System.Collections.Generic;
    using Abstraction;
    using Enums;

    public class Student : Person, IStudent
    {
        private readonly IList<IMark> marks;

        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.marks = new List<IMark>();
        }

        public Grade Grade { get; }

        public IList<IMark> GetMarks()
        {
            return this.marks;
        }

        public void AddMark(IMark mark)
        {
            if (this.marks.Count >= Constraints.MaxMarksCount)
            {
                throw new InvalidOperationException(
                    "The student have already reached maximum marks count");
            }

            this.marks.Add(mark);
        }
    }
}
