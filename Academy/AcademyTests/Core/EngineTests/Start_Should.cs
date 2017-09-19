using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Text;

namespace Academy.Core.Tests
{
    [TestClass]
    public class Start_Should
    {
        private Mock<IWriter> writerMock;
        private Mock<IReader> readerMock;
        private Mock<IParser> parserMock;
        private Mock<IDatabase> databaseMock;

        private Engine engine;

        [TestInitialize]
        public void Init()
        {
            readerMock = new Mock<IReader>();
            writerMock = new Mock<IWriter>();
            parserMock = new Mock<IParser>();
            databaseMock = new Mock<IDatabase>();

            engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, databaseMock.Object);
        }

        [TestMethod]
        public void WriteCustomExceptionMessage_WhenArgumentsAreInvalidButNotNullOrEmpty()
        {
            // Arange
            readerMock.SetupSequence(m => m.ReadLine()).Returns("listuser").Returns("Exit");
            parserMock.Setup(m => m.ParseCommand(It.IsAny<string>())).Throws<ArgumentOutOfRangeException>();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
            string expectedMessage = builder.ToString();

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.Write(expectedMessage), Times.Once);
        }

        [TestMethod]
        public void WriteCustomExceptionMessage_WhenCommandIsNullOrEmpty()
        {
            // Arange
            readerMock.SetupSequence(m => m.ReadLine()).Returns(String.Empty).Returns(null).Returns("Exit");

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Command cannot be null or empty.");
            builder.AppendLine("Command cannot be null or empty.");

            string expectedErrorMessage = builder.ToString();
            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.Write(expectedErrorMessage), Times.Once);
        }
    }
}