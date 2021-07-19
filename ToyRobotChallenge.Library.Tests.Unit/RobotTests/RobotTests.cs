using ToyRobotChallenge.Library.Environment;
using ToyRobotChallenge.Library.Robot;
using ToyRobotChallenge.Library.Positioning;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ToyRobotChallenge.Tests.Unit.RobotTests
{
    public class RobotTests
    {
        private readonly Mock<ITable> _tableMock = new Mock<ITable>();
        private readonly Mock<ILogger<Robot>> _loggerMock = new Mock<ILogger<Robot>>();

        [Fact]
        public void Place_WhenValid_SetHasBeenPlacedToTrue()
        {
            // Arrange
            _tableMock.Setup(t => t.IsValidPosition(It.IsAny<Coordinates>()))
                .Returns(true);

            var robot = new Robot(_tableMock.Object, _loggerMock.Object);

            // Act
            robot.Place(1, 2, CardinalPoint.NORTH);

            // Assert
            Assert.True(robot.HasBeenPlaced);
        }

        [Fact]
        public void Place_WhenValid_SetPositionToGivenCoordinates()
        {
            // Arrange
            _tableMock.Setup(t => t.IsValidPosition(It.IsAny<Coordinates>()))
                .Returns(true);
            var coordinates = new Coordinates(1, 2);

            var robot = new Robot(_tableMock.Object, _loggerMock.Object);

            // Act
            robot.Place(coordinates.X, coordinates.Y, CardinalPoint.NORTH);

            // Assert
            Assert.Equal(coordinates.X, robot.Position.X);
            Assert.Equal(coordinates.Y, robot.Position.Y);
        }

        [Fact]
        public void Place_WhenValid_SetFacingDirectionToGivenCardinalPoint()
        {
            // Arrange
            _tableMock.Setup(t => t.IsValidPosition(It.IsAny<Coordinates>()))
                .Returns(true);

            var robot = new Robot(_tableMock.Object, _loggerMock.Object);

            // Act
            robot.Place(1, 2, CardinalPoint.NORTH);

            // Assert
            Assert.Equal(CardinalPoint.NORTH, robot.FacingDirection.CardinalPoint);
        }

        [Fact]
        public void Place_WhenInvalid_LeaveHasBeenPlacedAsFalse()
        {
            // Arrange
            _tableMock.Setup(t => t.IsValidPosition(It.IsAny<Coordinates>()))
                .Returns(false);

            var robot = new Robot(_tableMock.Object, _loggerMock.Object);

            // Act
            robot.Place(1, 2, CardinalPoint.NORTH);

            // Assert
            Assert.False(robot.HasBeenPlaced);
        }

        [Fact]
        public void Move_WhenRobotHasntBeenPlaced_DoNotCallTableForValidPosition()
        {
            // Arrange
            var robot = new Robot(_tableMock.Object, _loggerMock.Object);

            // Act
            robot.Move();

            // Assert
            _tableMock.Verify(t => t.IsValidPosition(It.IsAny<Coordinates>()), Times.Never);
        }

        [Fact]
        public void Move_WhenRobotHasntBeenPlaced_DoNotSetPosition()
        {
            // Arrange
            var robot = new Robot(_tableMock.Object, _loggerMock.Object);

            // Act
            robot.Move();

            // Assert
            Assert.Null(robot.Position);
        }

        [Fact]
        public void Move_WhenRobotHasntBeenPlaced_DoNotSetFacingDirection()
        {
            // Arrange
            var robot = new Robot(_tableMock.Object, _loggerMock.Object);

            // Act
            robot.Move();

            // Assert
            Assert.Null(robot.FacingDirection);
        }

        [Fact]
        public void Move_WhenValidAndFacingNorth_MoveUp()
        {
            // Arrange
            _tableMock.Setup(t => t.IsValidPosition(It.IsAny<Coordinates>()))
                .Returns(true);

            var startingPosition = new Coordinates(2, 2);

            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = true;
            robot.FacingDirection = new FacingDirection(CardinalPoint.NORTH);
            robot.Position = startingPosition;

            // Act
            robot.Move();

            // Assert
            Assert.Equal(startingPosition.X, robot.Position.X);
            Assert.Equal(startingPosition.Y + 1, robot.Position.Y);
        }

        [Fact]
        public void Move_WhenValidAndFacingEast_MoveRight()
        {
            // Arrange
            _tableMock.Setup(t => t.IsValidPosition(It.IsAny<Coordinates>()))
                .Returns(true);

            var startingPosition = new Coordinates(2, 2);

            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = true;
            robot.FacingDirection = new FacingDirection(CardinalPoint.EAST);
            robot.Position = startingPosition;

            // Act
            robot.Move();

            // Assert
            Assert.Equal(startingPosition.X + 1, robot.Position.X);
            Assert.Equal(startingPosition.Y, robot.Position.Y);
        }

        [Fact]
        public void Move_WhenValidAndFacingSouth_MoveDown()
        {
            // Arrange
            _tableMock.Setup(t => t.IsValidPosition(It.IsAny<Coordinates>()))
                .Returns(true);

            var startingPosition = new Coordinates(2, 2);

            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = true;
            robot.FacingDirection = new FacingDirection(CardinalPoint.SOUTH);
            robot.Position = startingPosition;

            // Act
            robot.Move();

            // Assert
            Assert.Equal(startingPosition.X, robot.Position.X);
            Assert.Equal(startingPosition.Y - 1, robot.Position.Y);
        }

        [Fact]
        public void Move_WhenValidAndFacingWest_MoveLeft()
        {
            // Arrange
            _tableMock.Setup(t => t.IsValidPosition(It.IsAny<Coordinates>()))
                .Returns(true);

            var startingPosition = new Coordinates(2, 2);

            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = true;
            robot.FacingDirection = new FacingDirection(CardinalPoint.WEST);
            robot.Position = startingPosition;

            // Act
            robot.Move();

            // Assert
            Assert.Equal(startingPosition.X - 1, robot.Position.X);
            Assert.Equal(startingPosition.Y, robot.Position.Y);
        }

        [Fact]
        public void TurnLeft_WhenRobotHasBeenPlaced_Turn()
        {
            // Arrange
            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = true;
            robot.FacingDirection = new FacingDirection(CardinalPoint.NORTH);

            // Act
            robot.TurnLeft();

            // Assert
            Assert.Equal(CardinalPoint.WEST, robot.FacingDirection.CardinalPoint);
        }

        [Fact]
        public void TurnLeft_WhenRobotHasntBeenPlaced_DoNothing()
        {
            // Arrange
            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = false;

            // Act
            robot.TurnLeft();

            // Assert
            Assert.Null(robot.FacingDirection);
        }

        [Fact]
        public void TurnRight_WhenRobotHasBeenPlaced_Turn()
        {
            // Arrange
            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = true;
            robot.FacingDirection = new FacingDirection(CardinalPoint.NORTH);

            // Act
            robot.TurnRight();

            // Assert
            Assert.Equal(CardinalPoint.EAST, robot.FacingDirection.CardinalPoint);
        }

        [Fact]
        public void TurnRight_WhenRobotHasntBeenPlaced_DoNothing()
        {
            // Arrange
            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = false;

            // Act
            robot.TurnRight();

            // Assert
            Assert.Null(robot.FacingDirection);
        }

        [Fact]
        public void Report_WhenRobotHasBeenPlaced_ReturnFormattedPositionAndFacingDirection()
        {
            // Arrange
            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = true;
            robot.Position = new Coordinates(1, 2);
            robot.FacingDirection = new FacingDirection(CardinalPoint.NORTH);

            // Act
            var result = robot.Report();

            // Assert
            Assert.Equal("1,2,NORTH", result);
        }

        [Fact]
        public void Report_WhenRobotHasntBeenPlaced_ReturnEmptyString()
        {
            // Arrange
            var robot = new Robot(_tableMock.Object, _loggerMock.Object);
            robot.HasBeenPlaced = false;

            // Act
            var result = robot.Report();

            // Assert
            Assert.Equal(string.Empty, result);
        }
    }
}
