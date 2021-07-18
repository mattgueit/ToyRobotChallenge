using System;
using System.Collections.Generic;
using ToyRobotChallenge.Library.Robot;
using ToyRobotChallenge.Commands;
using Microsoft.Extensions.Logging;

namespace ToyRobotChallenge.Simulation
{
    public class Simulator : ISimulator
    {
        private readonly ILogger<Simulator> _logger;
        private readonly IRobot _robot;

        public Simulator(ILogger<Simulator> logger, IRobot robot)
        {
            _logger = logger;
            _robot = robot;
        }

        public void ExecuteRobotCommands(List<Command> commands)
        {
            _logger.LogInformation("Starting Simulator...");

            foreach(var command in commands)
            {
                _logger.LogDebug("Executing command: {CommandName}", command.CommandName);

                if (command.GetType() == typeof(PlaceCommand))
                {
                    var placeCommand = (PlaceCommand)command;
                    _robot.Place(placeCommand.X, placeCommand.Y, placeCommand.Direction);
                }
                else if (command.CommandName == ValidCommands.MoveCommandName)
                {
                    _robot.Move();
                }
                else if (command.CommandName == ValidCommands.TurnLeftCommandName)
                {
                    _robot.TurnLeft();
                }
                else if (command.CommandName == ValidCommands.TurnRightCommandName)
                {
                    _robot.TurnRight();
                }
                else if (command.CommandName == ValidCommands.ReportCommandName)
                {
                    Console.WriteLine(_robot.Report());
                }
                else
                {
                    _logger.LogError("The command: {command} was deemed valid but is not supported by the application.", command.CommandName);
                }
            }
        }
    }
}
