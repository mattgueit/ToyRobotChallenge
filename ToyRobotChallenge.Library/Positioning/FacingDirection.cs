namespace ToyRobotChallenge.Library.Positioning
{
    public class FacingDirection
    {
        public CardinalPoint CardinalPoint { get; private set; }

        public FacingDirection(CardinalPoint cardinalPoint)
        {
            CardinalPoint = cardinalPoint;
        }

        public string Report()
        {
            return CardinalPoint.ToString().ToUpper();
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
