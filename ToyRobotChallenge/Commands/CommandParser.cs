using System.Collections.Generic;
using ToyRobotChallenge.Data;
using Microsoft.Extensions.Logging;

namespace ToyRobotChallenge.Commands
{
    /// <summary>
    /// Retrieves valid commmands.
    /// </summary>
    public class CommandParser : ICommandParser
    {
        private readonly ILogger<CommandParser> _logger;
        private readonly ICommandDataReader _commandDataReader;

        public CommandParser(ILogger<CommandParser> logger, ICommandDataReader commandDataReader)
        {
            _logger = logger;
            _commandDataReader = commandDataReader;
        }

        /// <summary>
        /// Uses the command data reader to retrieve all commands, then create commands for all of those that are valid.
        /// </summary>
        public List<Command> RetrieveValidCommands(string fileName)
        {
            var rawCommands = _commandDataReader.RetrieveCommands(fileName);

            var validCommands = CreateValidCommands(rawCommands);

            return validCommands;
        }

        /// <summary>
        /// We should expect invalid commands and ignore them. So just pick out the valid ones.
        /// </summary>
        private List<Command> CreateValidCommands(List<string> rawCommands)
        {
            var validCommands = new List<Command>();

            // the amount of indentation here isn't clean - consider refactoring.
            for (int index = 0; index < rawCommands.Count; index++)
            {
                var command = rawCommands[index];

                if (command.Length >= 5 && command.Substring(0, 5) == ValidCommands.PlaceCommandName)
                {
                    if (index + 1 < rawCommands.Count) // lets not throw an IndexOutOfRangeException
                    {
                        var commandParameters = rawCommands[index + 1];

                        if (CommandValidator.PlaceParametersAreValid(commandParameters))
                        {
                            validCommands.Add(CreatePlaceCommand(commandParameters));
                        }
                    }
                }
                else
                {
                    if (CommandValidator.IsCommandValid(command))
                    {
                        validCommands.Add(CreateCommand(command));
                    }
                }
            }

            return validCommands;
        }

        /// <summary>
        /// Pretty simple, creates a generic command (anything but PLACE) .
        /// </summary>
        private Command CreateCommand(string commandName)
        {
            return new Command(commandName);
        }

        /// <summary>
        /// Creates a PLACE command.
        /// </summary>
        private PlaceCommand CreatePlaceCommand(string commandParameters)
        {
            var commandParameterList = commandParameters.Split(",");

            return new PlaceCommand(
                int.Parse(commandParameterList[0]),    // X
                int.Parse(commandParameterList[1]),    // Y
                commandParameterList[2]                // CardinalPoint
            );
        }
    }
}
