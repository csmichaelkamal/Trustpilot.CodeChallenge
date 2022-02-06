using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TrustPilot.CodeChallenge.API
{
    /// <summary>
    /// Application Main Entry
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The method that will be called by the runtime as the entry point to the application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create the host that will serve the entire app.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
