namespace ToyRobotChallenge.Library.Positioning
{
    /// <summary>
    /// Simple pair of X and Y points
    /// </summary>
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
