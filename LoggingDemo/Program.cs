using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace LoggingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            ILogger logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("The application has started");
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, loggingBuilder) => 
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddConfiguration(context.Configuration.GetSection("Logging"));
                    loggingBuilder.AddDebug();
                    loggingBuilder.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
