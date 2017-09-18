using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Academy.Commands.Listing;
using Moq;
using Academy.Core.Contracts;

namespace AcademyTests.Commands.Listing.ListUsersInSeasonCommandTests
{
    [TestClass]
    public class Contructor_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowException_WhenFactoryIsNull()
        {
            // Arange
            var engineMock = new Mock<IEngine>();

            // Act && Assert
            var command = new ListUsersInSeasonCommand(null, engineMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowException_WhenEngineIsNull()
        {
            // Arange
            var factoryMock = new Mock<IAcademyFactory>();

            // Act && Assert
            var command = new ListUsersInSeasonCommand(factoryMock.Object, null);
        }
    }
}
