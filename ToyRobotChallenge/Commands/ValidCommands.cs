using System.Collections.Generic;

namespace ToyRobotChallenge.Commands
{
    /// <summary>
    /// Single and central place to store valid command names.
    /// </summary>
    public static class ValidCommands
    {
        public static string PlaceCommandName = "PLACE";
        public static string MoveCommandName = "MOVE";
        public static string TurnLeftCommandName = "LEFT";
        public static string TurnRightCommandName = "RIGHT";
        public static string ReportCommandName = "REPORT";

        private static HashSet<string> _validCommandSet = new HashSet<string>()
        {
            PlaceCommandName,
            MoveCommandName,
            TurnLeftCommandName,
            TurnRightCommandName,
            ReportCommandName
        };

        /// <summary>
        /// Is my command valid?
        /// </summary>
        public static bool Contains(string commandString)
        {
            return _validCommandSet.Contains(commandString);
        }
    }
}
