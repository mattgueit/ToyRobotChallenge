using ToyRobotChallenge.Data;
using Xunit;
using Moq;
using ToyRobotChallenge.Commands;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobotChallenge.Tests.Unit.CommandTests
{
    public class CommandParserTests
    {
        private readonly Mock<ICommandDataReader> _commandDataReaderMock = new Mock<ICommandDataReader>();

        [Fact]
        public void RetrieveValidCommands_WhenValidMove_AddToValidCommands()
        {
            // Arrange
            _commandDataReaderMock.Setup(c => c.RetrieveCommands(It.IsAny<string>()))
                .Returns(new List<string>() { "MOVE" });

            var commandParser = new CommandParser(_commandDataReaderMock.Object);

            // Act
            var result = commandParser.RetrieveValidCommands(It.IsAny<string>());

            // Assert
            Assert.Equal("MOVE", result.First().CommandName);
        }

        [Fact]
        public void RetrieveValidCommands_WhenValidLEFT_AddToValidCommands()
        {
            // Arrange
            _commandDataReaderMock.Setup(c => c.RetrieveCommands(It.IsAny<string>()))
                .Returns(new List<string>() { "LEFT" });

            var commandParser = new CommandParser(_commandDataReaderMock.Object);

            // Act
            var result = commandParser.RetrieveValidCommands(It.IsAny<string>());

            // Assert
            Assert.Equal("LEFT", result.First().CommandName);
        }

        [Fact]
        public void RetrieveValidCommands_WhenValidRight_AddToValidCommands()
        {
            // Arrange
            _commandDataReaderMock.Setup(c => c.RetrieveCommands(It.IsAny<string>()))
                .Returns(new List<string>() { "RIGHT" });

            var commandParser = new CommandParser(_commandDataReaderMock.Object);

            // Act
            var result = commandParser.RetrieveValidCommands(It.IsAny<string>());

            // Assert
            Assert.Equal("RIGHT", result.First().CommandName);
        }

        [Fact]
        public void RetrieveValidCommands_WhenValidReport_AddToValidCommands()
        {
            // Arrange
            _commandDataReaderMock.Setup(c => c.RetrieveCommands(It.IsAny<string>()))
                .Returns(new List<string>() { "REPORT" });

            var commandParser = new CommandParser(_commandDataReaderMock.Object);

            // Act
            var result = commandParser.RetrieveValidCommands(It.IsAny<string>());

            // Assert
            Assert.Equal("REPORT", result.First().CommandName);
        }

        [Fact]
        public void RetrieveValidCommands_WhenValidPlace_AddToValidCommands()
        {
            // Arrange
            _commandDataReaderMock.Setup(c => c.RetrieveCommands(It.IsAny<string>()))
                .Returns(new List<string>() { "PLACE", "0,0,NORTH" });

            var commandParser = new CommandParser(_commandDataReaderMock.Object);

            // Act
            var result = commandParser.RetrieveValidCommands(It.IsAny<string>());

            // Assert
            var placeCommand = (PlaceCommand)result.First();
            Assert.Equal("PLACE", placeCommand.CommandName);
            Assert.Equal(0, placeCommand.X);
            Assert.Equal(0, placeCommand.Y);
        }

        [Fact]
        public void RetrieveValidCommands_WhenUnrecognisedCommand_Ignore()
        {
            // Arrange
            _commandDataReaderMock.Setup(c => c.RetrieveCommands(It.IsAny<string>()))
                .Returns(new List<string>() { "ATTACK" });

            var commandParser = new CommandParser(_commandDataReaderMock.Object);

            // Act
            var result = commandParser.RetrieveValidCommands(It.IsAny<string>());

            // Assert
            Assert.Empty(result);
        }

    }
}
