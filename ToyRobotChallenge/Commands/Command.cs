using System.Collections.Generic;

namespace ToyRobotChallenge.Commands
{
    /// <summary>
    /// Basic command - all commands have a name.
    /// </summary>
    public class Command
    {
        public string CommandName { get; set; }

        public Command(string commandName)
        {
            CommandName = commandName;
        }
    }
}
