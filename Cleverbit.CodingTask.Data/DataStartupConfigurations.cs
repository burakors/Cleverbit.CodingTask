using Cleverbit.CodingTask.Data.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data
{
    public static class DataStartupConfigurations
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString"));
            });
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void UseCreateDatabase(this IApplicationBuilder app)
        {
            // Seed Database
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.EnsureCreated();

                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred seeding the DB. {ex.Message}");
                }
            }
        }
    }
}
