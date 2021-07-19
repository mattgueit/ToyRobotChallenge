using System.Collections.Generic;

namespace ToyRobotChallenge.Data
{
    public interface ICommandDataReader
    {
        List<string> RetrieveCommands(string fileName);
    }
}
