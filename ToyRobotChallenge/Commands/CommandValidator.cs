using System;
using System.Linq;
using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Commands
{
    public static class CommandValidator
    {
        /// <summary>
        /// Check if our command is valid.
        /// </summary>
        public static bool IsCommandValid(string command)
        {
            if (ValidCommands.Contains(command))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The PLACE command requires a bit more validation. Method returns true if valid.
        /// </summary>
        public static bool PlaceParametersAreValid(string placeCommand)
        {
            var placeParameters = placeCommand.Substring(5);

            var commaSeparatedParameters = placeParameters.Split(",");

            if (commaSeparatedParameters.Length != 3)
            {
                return false;
            }

            // X
            if (!int.TryParse(commaSeparatedParameters[0], out _))
            {
                return false;
            }

            // Y
            if (!int.TryParse(commaSeparatedParameters[1], out _))
            {
                return false;
            }

            // NORTH, SOUTH, EAST, or WEST
            if (!Enum.IsDefined(typeof(CardinalPoint), commaSeparatedParameters[2]))
            {
                return false;
            }
            
            return true;
        }
    }
}
