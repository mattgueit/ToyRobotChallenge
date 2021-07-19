using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Library.Environment
{
    /// <summary>
    /// A table with a fixed size where robots roam.
    /// </summary>
    public class Table : ITable
    {
        private readonly int minX = 0;
        private readonly int minY = 0;
        private readonly int maxX = 4;
        private readonly int maxY = 4;

        public Table()
        {
            // default size: 5 x 5 - restricted from (0,0) to (4,4)
        }

        public Table(int x, int y)
        {
            maxX = x - 1;
            maxY = y - 1;
        }

        /// <summary>
        /// Will the robot stay on the table?
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
