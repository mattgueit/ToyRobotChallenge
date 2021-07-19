using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ToyRobotChallenge.Data
{
    public class TextFileCommandReader : ICommandDataReader
    {
        private readonly ILogger<TextFileCommandReader> _logger;

        public TextFileCommandReader(ILogger<TextFileCommandReader> logger)
        {
            _logger = logger;
        }

        public List<string> RetrieveCommands(string fileName)
        {
            _logger.LogDebug("Retrieving commands from text file: {fileName}", fileName);
            var commands = new List<string>();

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (!File.Exists(path))
            {
                _logger.LogDebug("File not found for given path: {path}.", path);
                return commands;
            }

            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var commandsPerLine = line.Split(" ");

                foreach (var command in commandsPerLine)
                {
                    commands.Add(command);
                }
            }

            return commands;
        }
    }
}
