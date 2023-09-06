using Cleverbit.CodingTask.Data.Aggregates.ApplicationUserAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data.Core.Config
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.UserName)
              .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Password)
              .HasMaxLength(50)
                .IsRequired();
        }
    }

}
