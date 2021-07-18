using System.Collections.Generic;

namespace ToyRobotChallenge.Commands
{
    public class Command
    {
        public string CommandName { get; set; }

        public Command(string commandName)
        {
            CommandName = commandName;
        }
    }
}
