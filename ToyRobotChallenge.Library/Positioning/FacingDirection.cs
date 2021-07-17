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
            if (direction == TurningDirection.Left)
            {
                TurnLeft();
            }
            else if (direction == TurningDirection.Right)
            {
                TurnRight();
            }
        }

        private void TurnLeft()
        {
            if (CardinalPoint == CardinalPoint.North)
            {
                CardinalPoint = CardinalPoint.West;
            }
            else if (CardinalPoint == CardinalPoint.East)
            {
                CardinalPoint = CardinalPoint.North;
            }
            else if (CardinalPoint == CardinalPoint.South)
            {
                CardinalPoint = CardinalPoint.East;
            }
            else if (CardinalPoint == CardinalPoint.West)
            {
                CardinalPoint = CardinalPoint.South;
            }
        }

        private void TurnRight()
        {
            if (CardinalPoint == CardinalPoint.North)
            {
                CardinalPoint = CardinalPoint.East;
            }
            else if (CardinalPoint == CardinalPoint.East)
            {
                CardinalPoint = CardinalPoint.South;
            }
            else if (CardinalPoint == CardinalPoint.South)
            {
                CardinalPoint = CardinalPoint.West;
            }
            else if (CardinalPoint == CardinalPoint.West)
            {
                CardinalPoint = CardinalPoint.North;
            }
        }
    }
}
