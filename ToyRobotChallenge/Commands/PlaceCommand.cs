using System;
using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Commands
{
    /// <summary>
    /// Command data specific to the PLACE command which has parameters (X, Y, F)
    /// X: point on x-axis.
    /// Y: point on y-axis.
    /// Direction: cardinal point which the robot is facing.
    /// </summary>
    public class PlaceCommand : Command
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CardinalPoint Direction { get; set; }

        public PlaceCommand(int x, int y, string directionString) 
            : base(ValidCommands.PlaceCommandName)
        {
            X = x;
            Y = y;

            CardinalPoint direction;
            if (Enum.TryParse(directionString, out direction))
            {
                Direction = direction;
            }
        }
    }
}
