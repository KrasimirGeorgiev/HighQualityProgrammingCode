namespace RotatingWalkInMatrix.Tests
{
    using System;
    using System.IO;
    using GameFifteen.UserInteraction;
    using NUnit.Framework;

    [TestFixture]
    public class MatrixUserInterfaceTests
    {
        [Test]
        public void Should_Delegate_UserInput_To_The_Console()
        {
            var sampleInput = "Kylo Ren";

            using (StringReader readerStream = new StringReader(sampleInput))
            {
                Console.SetIn(readerStream);

                var userInterface = MatrixUserInterface.GetInstance();
                var receivedInput = userInterface.ReadLine();

                Assert.AreEqual(sampleInput, receivedInput);
            }
        }

        [Test]
        public void Should_Write_Program_Output_Strings_To_The_Console()
        {
            var sampleOutput = "Enter a positive number between 1 and 100: ";

            using (StringWriter writeStream = new StringWriter())
            {
                Console.SetOut(writeStream);

                var userInterface = MatrixUserInterface.GetInstance();
                userInterface.Write(sampleOutput);

                Assert.AreEqual(sampleOutput, writeStream.ToString());
            }
        }

        [Test]
        public void Should_Append_New_Line_When_Using_The_WriteLine_Method()
        {
            var sampleOutput = "What gives?";

            using (StringWriter writeStream = new StringWriter())
            {
                Console.SetOut(writeStream);

                var userInterface = MatrixUserInterface.GetInstance();
                userInterface.WriteLine(sampleOutput);

                Assert.AreEqual(sampleOutput + Environment.NewLine, writeStream.ToString());
            }
        }

        [Test]
        public void Writing_Should_Work_With_Objects_Of_Any_Kind()
        {
            var objectOutput = new
            {
                Name = "Tyrion Lannister",
                Job = "Hand of the king"
            };

            using (StringWriter writeStream = new StringWriter())
            {
                Console.SetOut(writeStream);

                var userInterface = MatrixUserInterface.GetInstance();
                userInterface.Write(objectOutput);

                Assert.AreEqual(objectOutput.ToString(), writeStream.ToString());
            }
        }
    }
}
