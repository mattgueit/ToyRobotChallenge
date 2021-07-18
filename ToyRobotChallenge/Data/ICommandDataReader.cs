namespace ToyRobotChallenge.Data
{
    public interface ICommandDataReader
    {
        string[] RetrieveCommands(string fileName);
    }
}
