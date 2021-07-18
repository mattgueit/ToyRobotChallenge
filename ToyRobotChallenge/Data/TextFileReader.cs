using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ToyRobotChallenge.Data
{
    public class TextFileReader : ICommandDataReader
    {
        private readonly ILogger<TextFileReader> _logger;

        public TextFileReader(ILogger<TextFileReader> logger)
        {
            _logger = logger;
        }

        public string[] RetrieveCommands(string fileName)
        {
            _logger.LogDebug("Retrieving commands from text file: {fileName}", fileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (!File.Exists(path))
            {
                _logger.LogDebug("File not found for given path: {path}.", path);
                return Array.Empty<string>();
            }

            return File.ReadAllLines(path);
        }
    }
}
