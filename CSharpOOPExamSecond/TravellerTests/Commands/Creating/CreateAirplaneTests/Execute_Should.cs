using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Traveller.Commands.Creating;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace TravellerTests.Commands.Creating.CreateAirplaneTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateAirplaneAndAddItToDatabase_WhenParametersAreCorrect()
        {
            // Arange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();
            var planeMock = new Mock<IAirplane>();

            var vehicleMock1 = new Mock<IVehicle>();
            var vehicleMock2 = new Mock<IVehicle>();
            List<IVehicle> vehicles = new List<IVehicle>()
            { vehicleMock1.Object, vehicleMock2.Object };

            databaseMock.SetupGet(m => m.Vehicles).Returns(vehicles);
            factoryMock.Setup(m => m.CreateAirplane(It.IsAny<int>(),
                It.IsAny<decimal>(),
                It.IsAny<bool>()))
                .Returns(planeMock.Object);

            List<string> commandParams = new List<string>()
            {
                "250",
                "1",
                "true"
            };

            var command = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);
            // Act
            command.Execute(commandParams);

            // Assert
            Assert.AreEqual(planeMock.Object, databaseMock.Object.Vehicles[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_WhenParsingCapacityFails()
        {
            // Arange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();

            List<string> commandParams = new List<string>()
            {
                "12.1",
                "1",
                "true"
            };

            var command = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            command.Execute(commandParams);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_WhenParsingPriceFails()
        {
            // Arange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();

            List<string> commandParams = new List<string>()
            {
                "12",
                "manja",
                "true"
            };

            var command = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            command.Execute(commandParams);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_WhenParsingFreeFoodBoolFails()
        {
            // Arange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();

            List<string> commandParams = new List<string>()
            {
                "12",
                "1",
                "maikoo"
            };

            var command = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            command.Execute(commandParams);
        }
    }
}
