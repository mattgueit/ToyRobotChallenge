using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ToyRobotChallenge.Library.Positioning;

namespace ToyRobotChallenge.Commands
{
    public class CommandValidator
    {
        private readonly HashSet<string> _validCommands;
        private static readonly string _placeCommandString = "PLACE";

        public CommandValidator()
        {
            _validCommands = new HashSet<string>()
            {
                "PLACE",
                "MOVE",
                "LEFT",
                "RIGHT",
                "REPORT"
            };
        }

        /// <summary>
        /// Check if our command is valid.
        /// </summary>
        public bool IsValid(string command)
        {
            var sanitisedCommand = SanitiseCommandForValidation(command);

            if (_validCommands.Contains(sanitisedCommand))
            {
                if (sanitisedCommand == _placeCommandString)
                {
                    return IsPlaceCommandValid(command);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// The PLACE command requires a bit more validation. Method returns true if valid.
        /// </summary>
        private static bool IsPlaceCommandValid(string command)
        {
            var commaSeparatedCommand = command.Split(",");

            if (commaSeparatedCommand.Length != 4)
            {
                return false;
            }

            if (!int.TryParse(commaSeparatedCommand[1], out _))
            {
                return false;
            }

            if (!int.TryParse(commaSeparatedCommand[2], out _))
            {
                return false;
            }

            if (!Enum.IsDefined(typeof(CardinalPoint), commaSeparatedCommand[3]))
            {
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Get rid of unwanted characters from our command to check that it's valid
        /// </summary>
        private static string SanitiseCommandForValidation(string command)
        {
            string sanitised;

            sanitised = RemoveWhitespace(command);
            sanitised = GetSubstringBeforeFirstComma(sanitised);

            return sanitised;
        }

        /// <summary>
        /// Remove whitespaces from command
        /// </summary>
        private static string RemoveWhitespace(string command)
        {
            return Regex.Replace(command, @"\s+", "");
        }

        private static string GetSubstringBeforeFirstComma(string command)
        {
            var commaSeparatedCommand = command.Split(",");

            return commaSeparatedCommand.First();
        }
    }
}
