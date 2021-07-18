using System;
using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Commands
{
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
