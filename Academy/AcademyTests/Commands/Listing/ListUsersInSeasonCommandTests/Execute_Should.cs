using Academy.Commands.Listing;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace AcademyTests.Commands.Listing.ListUsersInSeasonCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallListUsersMethod_WhenParametersAreCorrect()
        {
            // Arange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var seasonMock1 = new Mock<ISeason>();
            var seasonMock2 = new Mock<ISeason>();

            List<ISeason> seasons = new List<ISeason>();
            seasons.Add(seasonMock1.Object);
            seasons.Add(seasonMock2.Object);

            engineMock.Setup(m => m.Database.Seasons).Returns(seasons);


            var command = new ListUsersInSeasonCommand(factoryMock.Object, engineMock.Object);

            List<string> parameters = new List<string>()
            {
                "1"
            };

            // Act
            command.Execute(parameters);

            // Assert
            seasonMock2.Verify(x => x.ListUsers(), Times.Once);
        }
    }
}
