using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace GameStore.API
{
    public class Program
    {
        private const string JSON_CONFIG_FILE = "appsettings.json";

        public static void Main(string[] args)
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile(JSON_CONFIG_FILE)
                    .Build();
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(config)
                    .CreateLogger();

                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
