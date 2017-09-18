using Academy.Commands.Creating;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Models;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace AcademyTests.Commands.CreateCourceCommand
{
    [TestClass]
    public class Execute_Should
    {
        private Mock<IReader> readerMock;
        private Mock<IWriter> writerMock;
        private Mock<IParser> parserMock;
        private Mock<IDatabase> databaseMock;
        private Mock<ISeason> seasonMock;
        private Engine engine;
        private List<string> commandLine;

        [TestInitialize]
        public void Init()
        {
            this.commandLine = new List<string>()
            {
                "0",
                "Algo",
                "6",
                "22/12/2012"
            };

            this.readerMock = new Mock<IReader>();
            this.writerMock = new Mock<IWriter>();
            this.parserMock = new Mock<IParser>();
            this.databaseMock = new Mock<IDatabase>();
            this.seasonMock = new Mock<ISeason>();

            this.databaseMock.SetupGet(m => m.Seasons).Returns(new List<ISeason>() { new Season(2016, 2017, 0) });

            this.engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, databaseMock.Object);
        }

        [TestMethod]
        public void CreateCourseAndAddItToDatabase_WhenParametersAreCorrect()
        {
            //Arange
            var courseMock = new Mock<ICourse>();

            var factoryMock = new Mock<IAcademyFactory>();

            factoryMock.Setup(m => m.CreateCourse(It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()))
            .Returns(courseMock.Object);

            var command = new CreateCourseCommand(factoryMock.Object, engine);

            //Act
            command.Execute(commandLine);

            //Assert
            Assert.AreEqual(courseMock.Object, databaseMock.Object.Seasons[0].Courses.Single());
        }

        [TestMethod]
        public void ReturnsTheCorrectString_WhenParamsAreCorrect()
        {
            // Arange
            var courseMock = new Mock<ICourse>();

            var factoryMock = new Mock<IAcademyFactory>();

            factoryMock.Setup(m => m.CreateCourse(It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()))
            .Returns(courseMock.Object);

            seasonMock.Setup(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });

            var command = new CreateCourseCommand(factoryMock.Object, engine);

            string expectedMessage = $"Course with ID {seasonMock.Object.Courses.Count - 1} was created in Season {databaseMock.Object.Seasons.Count - 1}.";
            
            // Act && Assert
            Assert.AreEqual(expectedMessage, command.Execute(commandLine));
        }
    }
}
