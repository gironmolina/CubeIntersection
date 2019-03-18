using CubeIntersection.Domain.Interfaces;
using CubeIntersection.Domain.Services;
using CubeIntersection.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CubeIntersection.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = AppConfig.ServiceProvider();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogDebug("Starting application");

            var cubeService = serviceProvider.GetService<ICube>();

            var cubeA = new Cube(new Position(2, 2, 2), 2);
            var cubeB = new Cube(new Position(10, 10, 10), 2);
            var result = cubeA.CollidesWith(cubeB);


            logger.LogDebug("All done!");
        }
    }
}
