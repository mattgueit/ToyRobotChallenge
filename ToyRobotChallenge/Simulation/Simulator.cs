using System.Collections.Generic;
using ToyRobotChallenge.Library.Robot;
using Microsoft.Extensions.Logging;

namespace ToyRobotChallenge.Simulation
{
    public class Simulator : ISimulator
    {
        private readonly ILogger<Simulator> _logger;
        private readonly IRobot _robot;

        private static readonly string _placeCommandString = "PLACE";
        private static readonly string _moveCommandString = "MOVE";
        private static readonly string _leftCommandString = "LEFT";
        private static readonly string _rightCommandString = "RIGHT";
        private static readonly string _reportCommandString = "REPORT";

        public Simulator(ILogger<Simulator> logger, IRobot robot)
        {
            _logger = logger;
            _robot = robot;
        }

        public void ExecuteRobotCommands(List<string> commands)
        {
            _logger.LogInformation("Starting Simulator...");

            foreach(var command in commands)
            {
                _logger.LogDebug("Executing command: {command}", command);

                if (command == _placeCommandString)
                {
                    //_robot.Place();
                }
            }
        }
    }
}
