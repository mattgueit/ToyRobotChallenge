using ToyRobotChallenge.Library.Environment;
using ToyRobotChallenge.Library.Positioning;
using Microsoft.Extensions.Logging;

namespace ToyRobotChallenge.Library.Robot
{
    public class Robot : IRobot
    {
        private bool HasBeenPlaced { get; set; } = false;
        private Coordinates Position { get; set; }
        private FacingDirection FacingDirection { get; set; }

        private readonly ITable _table;
        private readonly ILogger<Robot> _logger;

        public Robot(ITable table, ILogger<Robot> logger)
        {
            _table = table;
            _logger = logger;
        }

        /// <summary>
        /// Let the robot sit on a valid spot on the board and face some direction.
        /// </summary>
        public void Place(int x, int y, CardinalPoint cardinalPoint)
        {
            _logger.LogDebug($"Placing the robot in position: ({x},{y}) facing {cardinalPoint}");

            var position = new Coordinates(x, y);

            if (_table.IsValidPosition(position))
            {
                Position = position;
                FacingDirection = new FacingDirection(cardinalPoint);
                HasBeenPlaced = true;
            }
            else
            {
                _logger.LogDebug("Ignored attempt to place the robot out of bounds ({x},{y})", x, y);
            }
        }

        /// <summary>
        /// Move the positioned Robot one pace from the position it sits, in the direction it is facing.
        /// </summary>
        public void Move()
        {
            if (!HasBeenPlaced)
                return;

            var nextPosition = DetermineNextPosition();

            if (_table.IsValidPosition(nextPosition))
            {
                Position = nextPosition;
            }
        }

        /// <summary>
        /// Turn the robot in the left direction.
        /// </summary>
        public void TurnLeft()
        {
            if (!HasBeenPlaced)
                return;

            FacingDirection.Turn(TurningDirection.LEFT);
        }
        
        /// <summary>
        /// Turn the robot in the right direction.
        /// </summary>
        public void TurnRight()
        {
            if (!HasBeenPlaced)
                return;

            FacingDirection.Turn(TurningDirection.RIGHT);
        }

        /// <summary>
        /// Report the Robot's position.
        /// </summary>
        public string Report()
        {
            if (!HasBeenPlaced)
                return string.Empty;

            // TODO: consider whether or not the formatting belongs here
            return $"{Position.X},{Position.Y},{FacingDirection.Report()}"; 
        }


        /// <summary>
        /// Where will the Robot be if it moves?
        /// </summary>
        private Coordinates DetermineNextPosition()
        {
            var position = new Coordinates(Position.X, Position.Y);

            if (FacingDirection.CardinalPoint == CardinalPoint.NORTH)
            {
                position.Y += 1;
            }
            else if (FacingDirection.CardinalPoint == CardinalPoint.SOUTH)
            {
                position.Y -= 1;
            }
            else if (FacingDirection.CardinalPoint == CardinalPoint.EAST)
            {
                position.X += 1;
            }
            else if (FacingDirection.CardinalPoint == CardinalPoint.WEST)
            {
                position.X -= 1;
            }

            return position;
        }
    }
}
