using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var Host = CreateHostBuilder(args).Build();
            /*============================
             * do database update each time
             =============================*/
            using var scope = Host.Services.CreateScope();
            var services = scope.ServiceProvider;             // get services
            try
            {
                // check if can create a Db initializer like "aspNetCore Rocky project"
                var context = services.GetRequiredService<DataContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                //context.Database.Migrate();
                await context.Database.MigrateAsync();
                await Seed.SeedData(context, userManager);  // Seeding as well 
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during migration");
            }

            //Host.Run();
            await Host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
