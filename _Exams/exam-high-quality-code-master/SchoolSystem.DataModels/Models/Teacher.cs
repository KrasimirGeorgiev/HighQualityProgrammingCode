namespace SchoolSystem.DataModels.Models
{
    using Abstraction;
    using Enums;

    public class Teacher : Person, ITeacher
    {
        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; private set; }

        public void AddMark(IStudent student, float value)
        {
            var mark = new Mark(this.Subject, value);
            student.AddMark(mark);
        }
    }
}
