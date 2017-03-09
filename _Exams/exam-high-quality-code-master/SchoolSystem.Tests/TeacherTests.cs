namespace SchoolSystem.Tests
{
    using System;
    using DataModels.Abstraction;
    using DataModels.Enums;
    using DataModels.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void Constructing_With_Valid_Parameters_Should_Work()
        {
            string firstName = "Gosho";
            string lastName = "Vesheff";

            Teacher teacher = null;

            Assert.DoesNotThrow(() => teacher = this.CreateTeacher(firstName, lastName, Subject.Math));

            Assert.NotNull(teacher);
            Assert.AreEqual(firstName, teacher.FirstName);
            Assert.AreEqual(lastName, teacher.LastName);
            Assert.AreEqual(Subject.Math, teacher.Subject);
        }

        [TestCase("A")]
        [TestCase("$$$")]
        public void Constructing_With_Invalid_First_Name_Should_Throw(string firstName)
        {
            string lastName = "Vesheff";

            Assert.Throws<ArgumentException>(
                () => this.CreateTeacher(firstName, lastName, Subject.Math));
        }

        [TestCase("A")]
        [TestCase("$$$")]
        public void Constructing_With_Invalid_Last_Name_Should_Throw(string lastName)
        {
            string firstName = "Vesheff";

            Assert.Throws<ArgumentException>(
                () => this.CreateTeacher(firstName, lastName, Subject.Math));
        }

        [Test]
        public void AddMark_Should_Add_Mark_To_The_Provided_Student()
        {
            float grade = 5.5f;

            IMark assignedMark = null;
            var studentMock = new Mock<IStudent>();
            studentMock.Setup(s => s.AddMark(It.IsAny<IMark>()))
                .Callback((IMark mark) => assignedMark = mark);

            var studentInstance = studentMock.Object;

            string firstName = "Gosho";
            string lastName = "Vesheff";

            Teacher teacher = this.CreateTeacher(firstName, lastName, Subject.Math);
            teacher.AddMark(studentInstance, grade);

            studentMock.Verify(s => s.AddMark(It.IsAny<IMark>()), Times.Once);
            Assert.NotNull(assignedMark);
            Assert.AreEqual(grade, assignedMark.Value);
            Assert.AreEqual(Subject.Math, assignedMark.Subject);
        }

        [Test]
        public void Setting_The_Id_Should_Set_The_Correct_Value()
        {
            int id = 5;
            string firstName = "Gosho";
            string lastName = "Vesheff";

            Teacher teacher = this.CreateTeacher(firstName, lastName, Subject.Math);
            teacher.SetId(id);

            Assert.AreEqual(id, teacher.Id);
        }

        private Teacher CreateTeacher(string firstName, string lastName, Subject subject)
        {
            return new Teacher(firstName, lastName, subject);
        }
    }
}
