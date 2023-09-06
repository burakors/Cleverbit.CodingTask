using Cleverbit.CodingTask.Data.Aggregates.ApplicationUserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data.Core
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any TODO items.
                if (dbContext.Users.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);


            }
        }
        public static void PopulateTestData(IApplicationDbContext dbContext)
        {
            dbContext.Users.RemoveRange(dbContext.Users);
            dbContext.SaveChanges();

            var users = new ApplicationUser[]
            {
                new ApplicationUser("User1","Password1"),
                new ApplicationUser("User2","Password2"),
                new ApplicationUser("User3","Password3"),
                new ApplicationUser("User4","Password4")
            };

            dbContext.Users.AddRange(users);

            dbContext.SaveChanges();
        }
    }
}
