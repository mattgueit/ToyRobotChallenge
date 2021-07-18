using System.Collections.Generic;

namespace ToyRobotChallenge.Commands
{
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

        public static bool Contains(string commandString)
        {
            var upperCommandString = commandString.ToUpper();

            return _validCommandSet.Contains(upperCommandString);
        }
    }
}
