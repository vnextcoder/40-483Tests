using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mysecureapp.Areas.Identity.Data;

[assembly: HostingStartup(typeof(mysecureapp.Areas.Identity.IdentityHostingStartup))]
namespace mysecureapp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                // services.AddDbContext<mysecureappIdentityDbContext>(options =>
                //     options.UseSqlServer(
                //         context.Configuration.GetConnectionString("mysecureappIdentityDbContextConnection")));
                Console.WriteLine("===================================  I AM in IdentityHostingStartup.ConfigureServices=================================");
                Console.WriteLine("==== " + Environment.StackTrace);
                services.AddDbContext<mysecureappIdentityDbContext>(options =>
                options.UseSqlite(
                    context.Configuration.GetConnectionString("DefaultConnection")));
                services.AddDefaultIdentity<Areas.Identity.Data.mySecureAppUser>()
                    .AddEntityFrameworkStores<mysecureappIdentityDbContext>();
            });

            Console.WriteLine();
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(" InsideIdentityHostingStartup.Configure ");
            Console.WriteLine(Environment.StackTrace);
        }
    }
}