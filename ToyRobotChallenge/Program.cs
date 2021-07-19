using System.IO;
using ToyRobotChallenge.Commands;
using ToyRobotChallenge.Data;
using ToyRobotChallenge.Library.Environment;
using ToyRobotChallenge.Library.Robot;
using ToyRobotChallenge.Simulation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;


namespace ToyRobotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = StartupConfiguration();

            var application = ActivatorUtilities.CreateInstance<Application>(host.Services);

            application.Run(args);
        }

        /// <summary>
        /// Set up Dependency Injection and Serilog before the application starts.
        /// </summary>
        static IHost StartupConfiguration()
        {
            var builder = new ConfigurationBuilder();
            ConfigurationSetup(builder);

            // configure Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .CreateLogger();

            // instantiate DI container
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((services) =>
                {
                    services.AddSingleton<ISimulator, Simulator>();
                    services.AddSingleton<ICommandDataReader, TextFileCommandReader>();
                    services.AddSingleton<ICommandParser, CommandParser>();

                    services.AddSingleton<IRobot, Robot>();
                    services.AddSingleton<ITable, Table>();
                })
                .UseSerilog()
                .Build();

            return host;
        }

        /// <summary>
        /// This is needed to read from appsettings.json.
        /// </summary>
        static void ConfigurationSetup(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }
}
