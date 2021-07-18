using System.Collections.Generic;
using ToyRobotChallenge.Commands;

namespace ToyRobotChallenge.Simulation
{
    public interface ISimulator
    {
        void ExecuteRobotCommands(List<Command> commands);
    }
}
