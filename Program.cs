using Mazaare3.Data;
using Mazaare3.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazaare3
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {
          var host =  CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try{
                var context  = services.GetRequiredService<AppDBContext>();
                await context.Database.MigrateAsync();
                await Seed.SeedAds(context);
                await Seed.SeedCategories(context);

            }catch (Exception ex){

             var logger = services.GetRequiredService<ILogger<Program>>();
             logger.LogError(ex,"Ann Error occurres While Migration");
            }
             await host.RunAsync() ;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                     webBuilder
                      .UseKestrel()
                      .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseUrls("http://192.168.1.107:8080");
                });
    }
}
