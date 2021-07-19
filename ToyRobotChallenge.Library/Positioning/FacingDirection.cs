namespace ToyRobotChallenge.Library.Positioning
{
    /// <summary>
    /// Given a direction that I am facing, what direction will I be looking if I turn left or right?
    /// </summary>
    public class FacingDirection
    {
        public CardinalPoint CardinalPoint { get; private set; }

        public FacingDirection(CardinalPoint cardinalPoint)
        {
            CardinalPoint = cardinalPoint;
        }

        public string Report()
        {
            return CardinalPoint.ToString();
        }

        public void Turn(TurningDirection direction)
        {
            if (direction == TurningDirection.LEFT)
            {
                TurnLeft();
            }
            else if (direction == TurningDirection.RIGHT)
            {
                TurnRight();
            }
        }

        private void TurnLeft()
        {
            if (CardinalPoint == CardinalPoint.NORTH)
            {
                CardinalPoint = CardinalPoint.WEST;
            }
            else if (CardinalPoint == CardinalPoint.EAST)
            {
                CardinalPoint = CardinalPoint.NORTH;
            }
            else if (CardinalPoint == CardinalPoint.SOUTH)
            {
                CardinalPoint = CardinalPoint.EAST;
            }
            else if (CardinalPoint == CardinalPoint.WEST)
            {
                CardinalPoint = CardinalPoint.SOUTH;
            }
        }

        private void TurnRight()
        {
            if (CardinalPoint == CardinalPoint.NORTH)
            {
                CardinalPoint = CardinalPoint.EAST;
            }
            else if (CardinalPoint == CardinalPoint.EAST)
            {
                CardinalPoint = CardinalPoint.SOUTH;
            }
            else if (CardinalPoint == CardinalPoint.SOUTH)
            {
                CardinalPoint = CardinalPoint.WEST;
            }
            else if (CardinalPoint == CardinalPoint.WEST)
            {
                CardinalPoint = CardinalPoint.NORTH;
            }
        }
    }
}
