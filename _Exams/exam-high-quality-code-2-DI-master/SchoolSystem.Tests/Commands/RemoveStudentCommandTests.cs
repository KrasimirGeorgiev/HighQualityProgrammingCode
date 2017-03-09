namespace SchoolSystem.Tests.Commands
{
    using System;
    using System.Collections.Generic;
    using Framework.Core.Commands;
    using Framework.Core.Commands.Contracts;
    using Framework.Data.Contracts;
    using Framework.Models.Contracts;
    using Moq;
    using NUnit.Framework;

    public class RemoveStudentCommandTests
    {
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
                () => new RemoveStudentCommand(this.repositoryMock.Object));
        }

        [Test]
        public void Should_Throw_DuringConstruction_When_Parameter_IsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new RemoveStudentCommand(null));
        }

        [TestCase("5")]
        [TestCase("15")]
        public void Execute_Should_CallCorrectRepositoryMethod_WithCorrectId(string id)
        {
            var command = this.GetRemoveStudentCommand();
            var commandArgs = new List<string>() { id };

            command.Execute(commandArgs);

            this.repositoryMock.Verify(
                repository => repository.Remove(It.Is<int>(x => x == int.Parse(id))));
        }

        [Test]
        public void Execute_Should_Throw_WhenCalled_WithEmptyList()
        {
            var command = this.GetRemoveStudentCommand();
            var commandArgs = new List<string>();

            Assert.Throws<ArgumentException>(
                () => command.Execute(commandArgs));
        }

        [TestCase("5")]
        [TestCase("15")]
        public void Execute_Should_Return_String_Containing_SuccessMessage_And_RemovedID(string id)
        {
            var command = this.GetRemoveStudentCommand();
            var commandArgs = new List<string>() { id };

            var result = command.Execute(commandArgs);

            Assert.IsTrue(result.Contains(id));
        }

        private void SetupMocks()
        {
            this.repositoryMock = new Mock<IRepository<IStudent>>();
        }

        private ICommand GetRemoveStudentCommand()
        {
            return new RemoveStudentCommand(this.repositoryMock.Object);
        }
    }
}