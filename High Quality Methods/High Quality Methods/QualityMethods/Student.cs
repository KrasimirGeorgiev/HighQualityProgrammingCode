namespace Telerik.Homework.HQC.Methods.Task1.QualityMethods
{
    using System;

    public class Student
    {
        private readonly DateTime birthday;

        public Student(string firstName, string lastName, DateTime bornOn)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.birthday = bornOn;
            this.OtherInfo = null;
        }

        public Student(string firstName, string lastName, DateTime bornOn, string otherInfo)
            : this(firstName, lastName, bornOn)
        {
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public DateTime BirthDay
        {
            get
            {
                return this.birthday;
            }
        }

        public bool IsOlderThan(Student other)
        {
            return this.BirthDay < other.BirthDay;
        }
    }
}
