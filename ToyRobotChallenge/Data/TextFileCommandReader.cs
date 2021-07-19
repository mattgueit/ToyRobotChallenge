using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace ToyRobotChallenge.Data
{
    /// <summary>
    /// Reads commands from text files.
    /// </summary>
    public class TextFileCommandReader : ICommandDataReader
    {
        private readonly ILogger<TextFileCommandReader> _logger;

        public TextFileCommandReader(ILogger<TextFileCommandReader> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retrieve all words (commands) found in a text file.
        /// </summary>
        public List<string> RetrieveCommands(string fileName)
        {
            _logger.LogDebug("Retrieving commands from text file: {fileName}", fileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (!File.Exists(path))
            {
                _logger.LogInformation("File not found for given path: {path}.", path);
                return new List<string>();
            }

            var fileText = File.ReadAllText(path);

            // split by spaces, tabs and new lines
            return Regex.Split(fileText, @"[\s\t\n]+").ToList();
        }
    }
}
