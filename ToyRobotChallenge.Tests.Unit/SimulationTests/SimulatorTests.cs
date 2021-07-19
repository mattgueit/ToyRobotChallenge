using System.Collections.Generic;
using ToyRobotChallenge.Commands;
using ToyRobotChallenge.Library.Positioning;
using ToyRobotChallenge.Library.Robot;
using ToyRobotChallenge.Simulation;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;

namespace ToyRobotChallenge.Tests.Unit.SimulationTests
{
    public class SimulatorTests
    {
        private readonly Mock<ILogger<Simulator>> _loggerMock = new Mock<ILogger<Simulator>>();
        private readonly Mock<IRobot> _robotMock = new Mock<IRobot>();

        [Fact]
        public void ExecuteRobotCommands_WhenValidMoveCommand_CallRobotMethod()
        {
            // Arrange
            var simulator = new Simulator(_loggerMock.Object, _robotMock.Object);
            var commands = new List<Command>()
            {
                new Command("MOVE")
            };

            // Act
            simulator.ExecuteRobotCommands(commands);

            // Assert
            _robotMock.Verify(r => r.Move(), Times.Once);
        }

        [Fact]
        public void ExecuteRobotCommands_WhenValidTurnLeftCommand_CallRobotMethod()
        {
            // Arrange
            var simulator = new Simulator(_loggerMock.Object, _robotMock.Object);
            var commands = new List<Command>()
            {
                new Command("LEFT")
            };

            // Act
            simulator.ExecuteRobotCommands(commands);

            // Assert
            _robotMock.Verify(r => r.TurnLeft(), Times.Once);
        }

        [Fact]
        public void ExecuteRobotCommands_WhenValidTurnRightCommand_CallRobotMethod()
        {
            // Arrange
            var simulator = new Simulator(_loggerMock.Object, _robotMock.Object);
            var commands = new List<Command>()
            {
                new Command("RIGHT")
            };

            // Act
            simulator.ExecuteRobotCommands(commands);

            // Assert
            _robotMock.Verify(r => r.TurnRight(), Times.Once);
        }

        [Fact]
        public void ExecuteRobotCommands_WhenValidReportCommand_CallRobotMethod()
        {
            // Arrange
            var simulator = new Simulator(_loggerMock.Object, _robotMock.Object);
            var commands = new List<Command>()
            {
                new Command("REPORT")
            };

            // Act
            simulator.ExecuteRobotCommands(commands);

            // Assert
            _robotMock.Verify(r => r.Report(), Times.Once);
        }

        [Fact]
        public void ExecuteRobotCommands_WhenValidPlaceCommand_CallRobotMethod()
        {
            // Arrange
            var simulator = new Simulator(_loggerMock.Object, _robotMock.Object);
            var commands = new List<Command>()
            {
                new PlaceCommand(1, 1, CardinalPoint.NORTH.ToString())
            };

            // Act
            simulator.ExecuteRobotCommands(commands);

            // Assert
            _robotMock.Verify(r => r.Place(1, 1, CardinalPoint.NORTH), Times.Once);
        }
    }
}
