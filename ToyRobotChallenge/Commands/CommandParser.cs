using System.Collections.Generic;
using System.Linq;
using ToyRobotChallenge.Data;
using Microsoft.Extensions.Logging;

namespace ToyRobotChallenge.Commands
{
    public class CommandParser : ICommandParser
    {
        private readonly ILogger<CommandParser> _logger;
        private readonly ICommandDataReader _commandDataReader;
        private readonly CommandValidator _commandValidator;

        public CommandParser(ILogger<CommandParser> logger, ICommandDataReader commandDataReader)
        {
            _logger = logger;
            _commandDataReader = commandDataReader;
            _commandValidator = new CommandValidator();
        }

        public List<string> RetrieveValidCommands(string fileName)
        {
            var validCommands = new List<string>();
            var commands = _commandDataReader.RetrieveCommands(fileName);

            if (!commands.Any())
            {
                _logger.LogDebug("No commands found for file {fileName}.", fileName);
                return validCommands;
            }

            foreach (var command in commands)
            {
                var upperCaseCommand = command.ToUpper();

                if (_commandValidator.IsValid(upperCaseCommand))
                {
                    validCommands.Add(upperCaseCommand);
                }
            }

            return validCommands;

        }
    }
}
