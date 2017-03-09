namespace SchoolSystem.Tests
{
    using System.Linq;
    using ConsoleApp.Constants;
    using ConsoleApp.Core;
    using ConsoleApp.Core.Interfaces;
    using ConsoleApp.Core.UserInterface;
    using MockObjects;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class EngineTests
    {
        private Mock<IReader> mockReader;
        private Mock<IWriter> mockWriter;
        private Mock<IDataStore> mockDataStore;

        [SetUp]
        public void BeforeEach()
        {
            this.SetupMocks();
        }

        [Test]
        public void Should_Quit_On_When_The_Input_is_End()
        {
            this.mockReader.Setup(reader => reader.ReadLine()).Returns("End");

            var engine = this.CreateEngineInstance();
            engine.Run();

            this.mockWriter.Verify(writer => writer.WriteLine(It.IsAny<string>()), Times.Never);
        }

        [TestCase("CreateStudent Pesho Peshev 11")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        [TestCase("TeacherAddMark 0 0 3")]
        public void Should_Attempt_To_Create_The_Given_Command_By_Name(string commandLine)
        {
            this.SetupReaderToReturnLine(commandLine);

            var engine = this.CreateEngineInstance();
            engine.Run();

            var lastCommandCreated = FakeCommand.LastCreatedCommand;
            string expectedCommandName = commandLine.Split(' ').First();
            Assert.AreEqual(expectedCommandName, lastCommandCreated.CommandName);
        }

        [TestCase("CreateStudent Pesho Peshev 11")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        [TestCase("TeacherAddMark 0 0 3")]
        public void Should_Invoke_The_Created_Command(string commandLine)
        {
            this.SetupReaderToReturnLine(commandLine);

            var engine = this.CreateEngineInstance();
            engine.Run();

            var lastCommandCreated = FakeCommand.LastCreatedCommand;
            Assert.IsNotEmpty(lastCommandCreated.LastCallArguments);
        }

        [TestCase("CreateStudent Pesho Peshev 11")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        [TestCase("TeacherAddMark 0 0 3")]
        public void Should_Pass_Correct_ComandLine_Parameters_To_The_Created_Command(string commandLine)
        {
            this.SetupReaderToReturnLine(commandLine);

            var engine = this.CreateEngineInstance();
            engine.Run();

            var lastCommandCreated = FakeCommand.LastCreatedCommand;
            var expectedArguments = commandLine.Split(' ').Skip(1).ToList();

            for (int i = 0; i < expectedArguments.Count; i++)
            {
                Assert.AreEqual(expectedArguments[i], lastCommandCreated.LastCallArguments[i]);
            }
        }

        [Test]
        public void Should_Output_Success_Message_When_Command_Executes_Successfully()
        {
            string commandLine = "FakeCommand 1 2 3";
            this.SetupReaderToReturnLine(commandLine);

            var engine = this.CreateEngineInstance();
            engine.Run();

            this.mockWriter.Verify(writer => writer.WriteLine(FakeCommand.FakeSuccessMessage), Times.Once);
        }

        [Test]
        public void Should_Output_Error_Message_When_The_Command_Fails()
        {
            string commandLine = "FakeCommand";
            this.SetupReaderToReturnLine(commandLine);

            var engine = this.CreateEngineInstance();
            engine.Run();

            this.mockWriter.Verify(writer => writer.WriteLine(FakeCommand.FakeErrorMessage), Times.Once);
        }

        private Engine CreateEngineInstance()
        {
            var engine = new TestEngine(this.mockReader.Object, this.mockWriter.Object, this.mockDataStore.Object);

            return engine;
        }

        private void SetupMocks()
        {
            this.mockReader = new Mock<IReader>();
            this.mockWriter = new Mock<IWriter>();
            this.mockDataStore = new Mock<IDataStore>();
        }

        private void SetupReaderToReturnLine(string line)
        {
            this.mockReader.SetupSequence(reader => reader.ReadLine())
                .Returns(line)
                .Returns(InputStrings.EndOfInput);
        }
    }
}