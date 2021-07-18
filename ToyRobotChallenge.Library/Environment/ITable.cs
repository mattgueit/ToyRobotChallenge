using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Library.Environment
{
    public interface ITable
    {
        bool IsValidPosition(Coordinates position);
    }
}
