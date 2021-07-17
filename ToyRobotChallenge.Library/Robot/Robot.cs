using ToyRobotChallenge.Library.Environment;
using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Library.Robot
{
    public class Robot : IRobot
    {
        private bool HasBeenPlaced { get; set; } = false;
        private Coordinates Position { get; set; }
        private FacingDirection FacingDirection { get; set; }

        private readonly IBoard _board = new Board();

        public Robot()
        {
        }

        /// <summary>
        /// Let the robot sit on a valid spot on the board and face some direction.
        /// </summary>
        public void Place(Coordinates position, CardinalPoint cardinalPoint)
        {
            if (_board.IsValidPosition(position))
            {
                Position = position;
                FacingDirection = new FacingDirection(cardinalPoint);
                HasBeenPlaced = true;
            }
            else
            {
                // Perhaps a debug message here to say that the attempted placement was invalid?
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

            if (_board.IsValidPosition(nextPosition))
            {
                Position = nextPosition;
            }
        }

        /// <summary>
        /// Turn the robot either left or right.
        /// </summary>
        public void Turn(TurningDirection turningDirection)
        {
            if (!HasBeenPlaced)
                return;

            FacingDirection.Turn(turningDirection);
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

            if (FacingDirection.CardinalPoint == CardinalPoint.North)
            {
                position.Y += 1;
            }
            else if (FacingDirection.CardinalPoint == CardinalPoint.South)
            {
                position.Y -= 1;
            }
            else if (FacingDirection.CardinalPoint == CardinalPoint.East)
            {
                position.X += 1;
            }
            else if (FacingDirection.CardinalPoint == CardinalPoint.West)
            {
                position.X -= 1;
            }

            return position;
        }
    }
}
