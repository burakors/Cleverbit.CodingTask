using Cleverbit.CodingTask.Data.Aggregates.ApplicationUserAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data.Core
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public virtual DbSet<ApplicationUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
            Users = Set<ApplicationUser>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
