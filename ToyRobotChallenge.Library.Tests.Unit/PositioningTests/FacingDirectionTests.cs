using ToyRobotChallenge.Library.Positioning;
using Xunit;

namespace ToyRobotChallenge.Library.Tests.Unit.PositioningTests
{
    public class FacingDirectionTests
    {
        [Theory]
        [InlineData(CardinalPoint.NORTH, "NORTH")]
        [InlineData(CardinalPoint.EAST, "EAST")]
        [InlineData(CardinalPoint.SOUTH, "SOUTH")]
        [InlineData(CardinalPoint.WEST, "WEST")]
        public void Report_WhenCalled_ReturnCardinalPointString(CardinalPoint cardinalPoint, string expected)
        {
            // Arrange
            var facingDirection = new FacingDirection(cardinalPoint);

            // Act
            var result = facingDirection.Report();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(CardinalPoint.NORTH, CardinalPoint.WEST)]
        [InlineData(CardinalPoint.EAST, CardinalPoint.NORTH)]
        [InlineData(CardinalPoint.SOUTH, CardinalPoint.EAST)]
        [InlineData(CardinalPoint.WEST, CardinalPoint.SOUTH)]
        public void Turn_WhenLeft_ChangeCardinalPoint(CardinalPoint originalPoint, CardinalPoint expected)
        {
            // Arrange
            var facingDirection = new FacingDirection(originalPoint);

            // Act
            facingDirection.Turn(TurningDirection.LEFT);

            // Assert
            Assert.Equal(expected, facingDirection.CardinalPoint);
        }

        [Theory]
        [InlineData(CardinalPoint.NORTH, CardinalPoint.EAST)]
        [InlineData(CardinalPoint.EAST, CardinalPoint.SOUTH)]
        [InlineData(CardinalPoint.SOUTH, CardinalPoint.WEST)]
        [InlineData(CardinalPoint.WEST, CardinalPoint.NORTH)]
        public void Turn_WhenRight_ChangeCardinalPoint(CardinalPoint originalPoint, CardinalPoint expected)
        {
            // Arrange
            var facingDirection = new FacingDirection(originalPoint);

            // Act
            facingDirection.Turn(TurningDirection.RIGHT);

            // Assert
            Assert.Equal(expected, facingDirection.CardinalPoint);
        }
    }
}