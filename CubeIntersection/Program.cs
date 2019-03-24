using System;
using CubeIntersection.Domain.Interfaces;
using CubeIntersection.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CubeIntersection.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = AppConfig.ServiceProvider();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogDebug("Starting application");
            try
            {
                // This is just a test
                var cubeService = serviceProvider.GetService<ICubeService>();
                var cubeA = new Cube(new Position(2, 2, 2), 2);
                var cubeB = new Cube(new Position(10, 10, 10), 2);
                cubeService.CollidesWith(cubeA, cubeB);
                logger.LogDebug("All done!");
            }
            catch (Exception ex)
            {
                logger.LogError("", ex.Message);
                throw;
            }
        }
    }
}
