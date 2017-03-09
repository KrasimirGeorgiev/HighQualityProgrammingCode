namespace SchoolSystem.Tests.Commands
{
    using System;
    using System.Collections.Generic;
    using Framework.Core.Commands;
    using Framework.Core.Commands.Contracts;
    using Framework.Data.Contracts;
    using Framework.Models.Contracts;
    using Framework.Models.Enums;
    using Moq;
    using NUnit.Framework;

    public class TeacherAddMarkCommandTests
    {
        private Mock<IRepository<IStudent>> studentRepositoryMock;
        private Mock<IRepository<ITeacher>> teacherRepositoryMock;
        private Mock<ITeacher> teacherModelMock;
        private Mock<IStudent> studentModelMock;

        [SetUp]
        public void BeforeEach()
        {
            this.SetupMocks();
        }

        [Test]
        public void Should_ConstructCorrectly_With_ValidParameters()
        {
            Assert.DoesNotThrow(
                () => new TeacherAddMarkCommand(this.teacherRepositoryMock.Object, this.studentRepositoryMock.Object));
        }

        [Test]
        public void Should_Throw_DuringConstruction_When_Parameter_IsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new TeacherAddMarkCommand(null, this.studentRepositoryMock.Object));

            Assert.Throws<ArgumentNullException>(
                () => new TeacherAddMarkCommand(this.teacherRepositoryMock.Object, null));
        }

        [TestCase("13")]
        [TestCase("25")]
        public void Should_FetchTeacher_From_CorrectRepository_With_CorrectId(string teacherId)
        {
            var studentId = "5";
            var mark = "4";

            var command = this.GetAddMarkCommand();
            var commandArgs = new List<string>() { teacherId, studentId, mark };

            command.Execute(commandArgs);

            this.teacherRepositoryMock.Verify(
                repository => repository.Get(int.Parse(teacherId)));
        }

        [TestCase("2")]
        [TestCase("45")]
        public void Should_FetchStudent_From_CorrectRepository_With_CorrectId(string studentId)
        {
            var teacherId = "5";
            var mark = "4";

            var command = this.GetAddMarkCommand();
            var commandArgs = new List<string>() { teacherId, studentId, mark };

            command.Execute(commandArgs);

            this.studentRepositoryMock.Verify(
                repository => repository.Get(int.Parse(studentId)));
        }

        [Test]
        public void Should_AddMark_Using_TeacherAddMark_Method_And_CorrectMarkValue()
        {
            var command = this.GetAddMarkCommand();
            var markValue = 2.33f;
            var commandArgs = new List<string>() { "5", "4", markValue.ToString("F") };

            command.Execute(commandArgs);

            this.teacherModelMock.Verify(
                teacher => teacher.AddMark(
                    It.IsAny<IStudent>(), It.Is<float>(m => m == markValue)));
        }

        [Test]
        public void Should_Return_StringContaining_SuccessMessage_And_InvolvedObjectsData()
        {
            this.studentModelMock.SetupGet(s => s.FirstName).Returns("Pesho");
            this.studentModelMock.SetupGet(s => s.LastName).Returns("Peshev");

            this.teacherModelMock.SetupGet(s => s.FirstName).Returns("Ivan");
            this.teacherModelMock.SetupGet(s => s.LastName).Returns("Ivanov");
            this.teacherModelMock.SetupGet(s => s.Subject).Returns(Subject.Math);

            var command = this.GetAddMarkCommand();
            var markValue = 2.33f;
            var commandArgs = new List<string>() { "5", "4", markValue.ToString("F") };

            var result = command.Execute(commandArgs);

            var teacher = this.teacherModelMock.Object;
            Assert.IsTrue(
                result.Contains(teacher.FirstName), "Does not contain teacher first name");
            Assert.IsTrue(
                result.Contains(teacher.LastName), "Does not contain teacher last name");
            Assert.IsTrue(
                result.Contains(teacher.Subject.ToString()), "Does not contain teacher specialty");

            var student = this.studentModelMock.Object;
            Assert.IsTrue(
                result.Contains(student.FirstName), "Does not contain student first name");
            Assert.IsTrue(
                result.Contains(student.LastName), "Does not contain student last name");

            Assert.IsTrue(
                result.Contains(markValue.ToString("F")), "Does not contain mark value");
        }

        private void SetupMocks()
        {
            this.studentRepositoryMock = new Mock<IRepository<IStudent>>();
            this.teacherRepositoryMock = new Mock<IRepository<ITeacher>>();
            this.teacherModelMock = new Mock<ITeacher>();
            this.studentModelMock = new Mock<IStudent>();

            this.studentRepositoryMock.Setup(
                repository => repository.Get(It.IsAny<int>()))
                .Returns(this.studentModelMock.Object);

            this.teacherRepositoryMock.Setup(
                repository => repository.Get(It.IsAny<int>()))
                .Returns(this.teacherModelMock.Object);
        }

        private ICommand GetAddMarkCommand()
        {
            return new TeacherAddMarkCommand(
                this.teacherRepositoryMock.Object, this.studentRepositoryMock.Object);
        }
    }
}
