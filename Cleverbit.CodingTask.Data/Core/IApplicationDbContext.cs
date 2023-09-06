using Cleverbit.CodingTask.Data.Aggregates.ApplicationUserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data.Core
{
    public interface IApplicationDbContext : IDisposable
    {
        public DbSet<ApplicationUser> Users { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
