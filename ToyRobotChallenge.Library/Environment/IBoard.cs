using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Library.Environment
{
    public interface IBoard
    {
        bool IsValidPosition(Coordinates position);
    }
}
