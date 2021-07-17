using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Library.Robot
{
    public interface IRobot
    {
        void Place(Coordinates position, CardinalPoint direction);
        void Move();
        void Turn(TurningDirection direction);
        string Report();
    }
}