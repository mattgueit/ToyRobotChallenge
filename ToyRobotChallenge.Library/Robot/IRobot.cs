using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Library.Robot
{
    public interface IRobot
    {
        void Place(int x, int y, CardinalPoint direction);
        void Move();
        void TurnLeft();
        void TurnRight();
        string Report();
    }
}