using CubeIntersection.Domain.Interfaces;
using CubeIntersection.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CubeIntersection.ConsoleApp
{
    public class AppConfig
    {
        public static ServiceProvider ServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<ICubeService, CubeService>()
                .AddSingleton<IBorderService, BorderService>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            return serviceProvider;
        }
    }
}
