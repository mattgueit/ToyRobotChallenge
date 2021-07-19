using ToyRobotChallenge.Library.Environment;
using ToyRobotChallenge.Library.Positioning;
using Xunit;

namespace ToyRobotChallenge.Library.Tests.Unit.EnvironmentTests
{
    public class TableTests
    {

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        public void IsValidPosition_WhenPositionedInside_ReturnTrue(int x, int y)
        {
            // Arrange
            var coordinates = new Coordinates(x, y);
            var table = new Table(5, 5);

            // Act
            var result = table.IsValidPosition(coordinates);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 0)]
        [InlineData(1, 4)]
        [InlineData(2, 4)]
        [InlineData(3, 4)]
        [InlineData(4, 1)]
        [InlineData(4, 2)]
        [InlineData(4, 3)]
        public void IsValidPosition_WhenPositedOnTheBorder_ReturnTrue(int x, int y)
        {
            // Arrange
            var coordinates = new Coordinates(x, y);
            var table = new Table(5, 5);

            // Act
            var result = table.IsValidPosition(coordinates);

            // Assert
            Assert.True(result);
        }


        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 4)]
        [InlineData(4, 0)]
        [InlineData(4, 4)]
        public void IsValidPosition_WhenPositedOnTheCorner_ReturnTrue(int x, int y)
        {
            // Arrange
            var coordinates = new Coordinates(x, y);
            var table = new Table(5, 5);

            // Act
            var result = table.IsValidPosition(coordinates);

            // Assert
            Assert.True(result);
        }
    }
}
