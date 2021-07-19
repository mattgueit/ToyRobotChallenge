using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ToyRobotChallenge.Commands;
using ToyRobotChallenge.Simulation;

namespace ToyRobotChallenge
{
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

        public void Run(string[] args)
        {
            _logger.LogInformation("Starting Toy Robot Application...");

            var validCommands = _commandParser.RetrieveValidCommands("commands.txt");

            if (validCommands.Any())
            {
                _simulator.ExecuteRobotCommands(validCommands);
            }
            else
            {
                _logger.LogDebug("No valid commands found");
            }

            Console.ReadKey();
        }
    }
}
