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

            validCommands = PickOutValidCommands(commands);

            return validCommands;
        }

        /// <summary>
        /// We should expect invalid commands, but ignore them. So let's just pick out the valid ones.
        /// </summary>
        /// <param name="commandNames"></param>
        /// <returns></returns>
        private List<Command> PickOutValidCommands(string[] commandNames)
        {
            var validCommands = new List<Command>();

            foreach (var commandName in commandNames)
            {
                var formattedCommand = FormatCommand(commandName);

                if (formattedCommand.Length >= 5 && formattedCommand.Substring(0, 5) == ValidCommands.PlaceCommandName)
                {
                    if (CommandValidator.PlaceParametersAreValid(formattedCommand))
                    {
                        validCommands.Add(CreatePlaceCommand(formattedCommand));
                    }
                }
                else
                {
                    if (CommandValidator.IsCommandValid(formattedCommand))
                    {
                        validCommands.Add(CreateCommand(formattedCommand));
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
        private PlaceCommand CreatePlaceCommand(string commandString)
        {
            var commandParameters = commandString.Substring(ValidCommands.PlaceCommandName.Length);

            var commandParameterList = commandParameters.Split(",");

            return new PlaceCommand(
                int.Parse(commandParameterList[0]),    // X
                int.Parse(commandParameterList[1]),    // Y
                commandParameterList[2]                // CardinalPoint
            );
        }

        /// <summary>
        /// It makes it easier to validate and parse when there are no whitespaces and all characters are upper case.
        /// </summary>
        private string FormatCommand(string command)
        {
            var formattedCommand = RemoveWhitespace(command);

            formattedCommand = formattedCommand.ToUpper();

            return formattedCommand;
        }

        /// <summary>
        /// Remove whitespaces from command
        /// </summary>
        private static string RemoveWhitespace(string command)
        {
            return Regex.Replace(command, @"\s+", "");
        }
    }
}
