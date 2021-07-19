using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ToyRobotChallenge.Commands;
using ToyRobotChallenge.Simulation;

namespace ToyRobotChallenge
{
    /// <summary>
    /// Main part of the application to retrieve commands and kick off simulation.
    /// </summary>
    public class Application
    {
        private readonly ILogger<Application> _logger;
        private readonly ISimulator _simulator;
        private readonly ICommandParser _commandParser;

        public Application(ILogger<Application> logger, ISimulator simulator, ICommandParser commandParser)
        {
            _logger = logger;
            _simulator = simulator;
            _commandParser = commandParser;
        }

        /// <summary>
        /// Retrieve commands and simulate.
        /// </summary>
        public void Run(string[] args)
        {
            var fileName = GetFileNameFromArgs(args);

            if (fileName == null)
            {
                _logger.LogInformation("No filename was specified. Please provide the filename as an argument: -f <filename>");
                return;
            }

            var validCommands = _commandParser.RetrieveValidCommands(fileName);

            if (!validCommands.Any())
            {
                _logger.LogInformation("No valid commands found");
                return;
            }

            try
            {
                _simulator.ExecuteRobotCommands(validCommands);
            }
            catch (Exception ex)
            {
                _logger.LogError("Encountered an error during simulation: {Message}", ex.Message);
            }
        }

        private static string GetFileNameFromArgs(string[] args)
        {
            if (args.Length < 2 || args[0] != "-f")
            {
                return null;
            }

            return args[1];
        }
    }
}
