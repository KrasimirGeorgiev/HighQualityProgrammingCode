namespace SchoolSystem.Tests
{
    using System;
    using System.Collections;
    using System.Linq;
    using DataModels;
    using DataModels.Abstraction;
    using DataModels.Enums;
    using DataModels.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Constructing_With_Valid_Parameters_Should_Work()
        {
            string firstName = "Pesho";
            string lastName = "Petrov";

            Student student = null;

            Assert.DoesNotThrow(() => student = this.CreateStudent(firstName, lastName, Grade.Eleventh));

            Assert.NotNull(student);
            Assert.AreEqual(firstName, student.FirstName);
            Assert.AreEqual(lastName, student.LastName);
            Assert.AreEqual(Grade.Eleventh, student.Grade);
        }

        [Test]
        public void Setting_The_Id_Should_Set_The_Correct_Value()
        {
            int id = 5;
            string firstName = "Pesho";
            string lastName = "Petrov";

            var student = this.CreateStudent(firstName, lastName, Grade.Eleventh);
            student.SetId(id);

            Assert.AreEqual(id, student.Id);
        }

        [TestCase("A")]
        [TestCase("$$$")]
        public void Constructing_With_Invalid_First_Name_Should_Throw(string firstName)
        {
            string lastName = "Vesheff";

            Assert.Throws<ArgumentException>(
                () => this.CreateStudent(firstName, lastName, Grade.Eleventh));
        }

        [TestCase("A")]
        [TestCase("$$$")]
        public void Constructing_With_Invalid_Last_Name_Should_Throw(string lastName)
        {
            string firstName = "Vesheff";

            Assert.Throws<ArgumentException>(
                () => this.CreateStudent(firstName, lastName, Grade.Eleventh));
        }

        [Test]
        public void AddMark_Should_AddMark_To_The_Student_MarkCollection()
        {
            string firstName = "Pesho";
            string lastName = "Petrov";

            var student = this.CreateStudent(firstName, lastName, Grade.Eleventh);
            var fakeMark = new Mock<IMark>().Object;

            student.AddMark(fakeMark);
            ICollection marks = student.GetMarks().ToList();

            Assert.Contains(fakeMark, marks);
        }

        [Test]
        public void AddMark_Adding_More_Than_Allowed_Max_Marks_Should_Throw()
        {
            string firstName = "Pesho";
            string lastName = "Petrov";

            var student = this.CreateStudent(firstName, lastName, Grade.Eleventh);
            var fakeMark = new Mock<IMark>().Object;

            for (int i = 0; i < Constraints.MaxMarksCount; i++)
            {
                student.AddMark(fakeMark);
            }

            Assert.Throws<InvalidOperationException>(() => student.AddMark(fakeMark));
        }

        private Student CreateStudent(string firstName, string lastName, Grade grade)
        {
            return new Student(firstName, lastName, grade);
        }
    }
}