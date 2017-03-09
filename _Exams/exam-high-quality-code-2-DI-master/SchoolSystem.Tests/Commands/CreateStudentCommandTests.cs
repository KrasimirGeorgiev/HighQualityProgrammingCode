namespace SchoolSystem.Tests.Commands
{
    using System;
    using System.Collections.Generic;
    using Framework.Core.Commands;
    using Framework.Core.Commands.Contracts;
    using Framework.Data.Contracts;
    using Framework.Factories.Contracts;
    using Framework.Models.Contracts;
    using Framework.Models.Enums;
    using Moq;
    using NUnit.Framework;

    public class CreateStudentCommandTests
    {
        public const int CreatedStudentId = 13;

        private Mock<IStudentFactory> factoryMock;

        private Mock<IRepository<IStudent>> repositoryMock;

        [SetUp]
        public void BeforeEach()
        {
            this.SetupMocks();
        }

        [Test]
        public void Should_ConstructCorrectly_With_ValidParameters()
        {
            Assert.DoesNotThrow(
                () => new CreateStudentCommand(this.repositoryMock.Object, this.factoryMock.Object));
        }

        [Test]
        public void Should_Throw_DuringConstruction_When_Parameter_IsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new CreateStudentCommand(null, this.factoryMock.Object));

            Assert.Throws<ArgumentNullException>(
                () => new CreateStudentCommand(this.repositoryMock.Object, null));
        }

        [TestCase("Pesho", "Peshev", "11")]
        [TestCase("Gosho", "Peshev", "9")]
        public void Execute_Should_TryToCreateStudent_Passing_CorrectlyParsedParameters(string firstName, string lastName, string grade)
        {
            var commandArgs = new List<string>() { firstName, lastName, grade };
            var parsedGrade = (Grade)int.Parse(grade);
            var command = this.GetCreateStudentCommand();

            command.Execute(commandArgs);

            this.factoryMock.Verify(
                factory => factory.CreateStudent(firstName, lastName, parsedGrade), Times.Once);
        }

        [Test]
        public void Execute_Should_Throw_Given_Less_Than_3_Parameters()
        {
            var commandArgs = new List<string>() { "Pesho", "Peshev" };
            var command = this.GetCreateStudentCommand();

            var ex = Assert.Throws<ArgumentException>(() => command.Execute(commandArgs));
            Assert.IsTrue(ex.Message.ToLower().Contains("invalid parameters"));
        }

        [Test]
        public void Execute_Should_Throw_Given_Invalid_Grade()
        {
            var commandArgs = new List<string>() { "Pesho", "Peshev", "100" };
            var command = this.GetCreateStudentCommand();

            var ex = Assert.Throws<ArgumentException>(() => command.Execute(commandArgs));
            Assert.IsTrue(ex.Message.ToLower().Contains("invalid grade"));
        }

        [Test]
        public void Execute_Should_StoreTheCreatedStudent_InTheRepository()
        {
            var commandArgs = new List<string>() { "Pesho", "Peshev", "12" };
            var command = this.GetCreateStudentCommand();

            command.Execute(commandArgs);

            this.repositoryMock.Verify(
                repository => repository.Add(It.IsAny<IStudent>()), Times.Once);
        }

        [Test]
        public void Execute_Should_ReturnStringMessage_ContainingCommandParameters_And_ID()
        {
            var firstName = "Blago";
            var lastName = "Milev";
            var grade = "12";
            var gradeAsString = ((Grade)int.Parse(grade)).ToString();

            var commandArgs = new List<string>() { firstName, lastName, grade };
            var command = this.GetCreateStudentCommand();

            var result = command.Execute(commandArgs);

            Assert.IsTrue(result.Contains(firstName), "Does not contain first name");
            Assert.IsTrue(result.Contains(lastName), "Does not contain last name");
            Assert.IsTrue(result.Contains(gradeAsString), "Does not contain grade");
            Assert.IsTrue(result.Contains(CreatedStudentId.ToString()), "Does not contain ID");
        }

        private void SetupMocks()
        {
            this.factoryMock = new Mock<IStudentFactory>();
            this.repositoryMock = new Mock<IRepository<IStudent>>();

            this.factoryMock.Setup(
                factory => factory.CreateStudent(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()))
                .Returns(new Mock<IStudent>().Object);

            this.repositoryMock.Setup(
                repository => repository.Add(It.IsAny<IStudent>()))
                .Returns(CreatedStudentId);
        }

        private ICommand GetCreateStudentCommand()
        {
            return new CreateStudentCommand(this.repositoryMock.Object, this.factoryMock.Object);
        }
    }
}