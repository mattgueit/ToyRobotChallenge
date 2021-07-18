using System.Collections.Generic;

namespace ToyRobotChallenge.Commands
{
    public interface ICommandParser
    {
        List<Command> RetrieveValidCommands(string fileName);
    }
}
