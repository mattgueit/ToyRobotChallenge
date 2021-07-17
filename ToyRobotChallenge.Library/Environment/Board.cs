using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Library.Environment
{
    public class Board : IBoard
    {
        private readonly int minX = 0;
        private readonly int minY = 0;
        private readonly int maxX = 5;
        private readonly int maxY = 5;

        public Board()
        {
            // default size: 5 x 5
        }

        public Board(int x, int y)
        {
            maxX = x;
            maxY = y;
        }

        /// <summary>
        /// Will the robot stay on the board?
        /// </summary>
        public bool IsValidPosition(Coordinates position)
        {
            if (position.X < minX || position.Y < minY)
                return false;

            if (position.X > maxX || position.Y > maxY)
                return false;

            return true;
        }
    }
}
