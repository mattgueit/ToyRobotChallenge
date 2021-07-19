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
        private static readonly string _defaultFileName = "commands.txt";

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
            _logger.LogInformation("Starting Toy Robot Application...");

            var validCommands = _commandParser.RetrieveValidCommands(_defaultFileName);

            if (!validCommands.Any())
            {
                _logger.LogDebug("No valid commands found");
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

            Console.ReadKey();
        }
    }
}
