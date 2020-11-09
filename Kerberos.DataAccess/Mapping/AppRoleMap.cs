using Kerberos.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.DataAccess.Mapping
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("tAppRole", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(a => a.AppUserRoles).WithOne(a => a.AppRole)
                .HasForeignKey(a => a.AppRoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
