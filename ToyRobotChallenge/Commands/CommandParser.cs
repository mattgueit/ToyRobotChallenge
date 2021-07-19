using System.Collections.Generic;
using System.Linq;
using ToyRobotChallenge.Data;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace ToyRobotChallenge.Commands
{
    public class CommandParser : ICommandParser
    {
        private readonly ILogger<CommandParser> _logger;
        private readonly ICommandDataReader _commandDataReader;

        public CommandParser(ILogger<CommandParser> logger, ICommandDataReader commandDataReader)
        {
            _logger = logger;
            _commandDataReader = commandDataReader;
        }

        public List<Command> RetrieveValidCommands(string fileName)
        {
            var validCommands = new List<Command>();

            var commands = _commandDataReader.RetrieveCommands(fileName);

            if (!commands.Any())
            {
                _logger.LogDebug("No commands found for file {fileName}.", fileName);
                return validCommands;
            }

            validCommands = CreateValidCommands(commands);

            return validCommands;
        }

        /// <summary>
        /// We should expect invalid commands, but ignore them. So let's just pick out the valid ones.
        /// </summary>
        /// <param name="commandNames"></param>
        /// <returns></returns>
        private List<Command> CreateValidCommands(List<string> commandNames)
        {
            var validCommands = new List<Command>();

            // the amount of indentation here isn't clean - consider refactoring.
            for (int index = 0; index < commandNames.Count; index++)
            {
                var commandName = commandNames[index];

                if (commandName.Length >= 5 && commandName.Substring(0, 5) == ValidCommands.PlaceCommandName)
                {
                    if (index + 1 < commandNames.Count)
                    {
                        var commandParameters = commandNames[index + 1];

                        if (CommandValidator.PlaceParametersAreValid(commandParameters))
                        {
                            validCommands.Add(CreatePlaceCommand(commandParameters));
                        }
                    }
                }
                else
                {
                    if (CommandValidator.IsCommandValid(commandName))
                    {
                        validCommands.Add(CreateCommand(commandName));
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
