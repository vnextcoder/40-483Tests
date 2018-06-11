﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace myappwithlogging {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.Configure<CookiePolicyOptions> (options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc (

                opt => {
                    opt.Filters.Add<LogResultFilter> ();
                }
            ).SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
             var eventHubConfig = Configuration.GetSection ("Logging").GetSection ("eventHub");
             //Log.Logger = new LoggerConfiguration ()
            // .ReadFrom.Configuration(configuration)
            //     .MinimumLevel.Information ()
            //     //.WriteTo.Console (LogEventLevel.Information)
            //     // .WriteTo.RollingFile("myapplog-{Date}.log",LogEventLevel.Information,"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                //  .WriteTo.AzureEventHub (new JsonFormatter (),
                //      eventHubConfig.GetValue<string> ("connectionString"),
                //      eventHubConfig.GetValue<string> ("entityName"))
                //  .CreateLogger ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseCookiePolicy ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}