using System.Collections.Generic;

namespace ToyRobotChallenge.Commands
{
    public interface ICommandParser
    {
        List<string> RetrieveValidCommands(string fileName);
    }
}
