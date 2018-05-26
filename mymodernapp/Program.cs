using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace mymodernapp
{
    public class Program
    {
        public static void Main(string[] args)
        {

    //         var configuration = new ConfigurationBuilder()
    // .SetBasePath(env.ContentRootPath)
    // .AddJsonFile("appsettings.json")
    // .Build();
    
            // BuildWebHost(args).Run();
    //        Log.Logger = new LoggerConfiguration()
  
            var Log = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                // .MinimumLevel.Debug()
                // .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                // .Enrich.FromLogContext()
                //.WriteTo.ColoredConsole()
                // .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200") ){
                //     AutoRegisterTemplate = true,
                //     AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
                // })
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                BuildWebHost(args).Run();
                return ;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return ;
            }
            finally
            {
                //Log.CloseAndFlush();
            }




        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
              //.UseElectron(args)
                .UseStartup<Startup>()
                
                .UseSerilog() // <-- Add this line
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .Build();
    }
}
