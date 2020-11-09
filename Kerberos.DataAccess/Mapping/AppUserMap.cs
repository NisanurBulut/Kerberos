using Kerberos.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.DataAccess.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("tAppUser", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.UserName).IsRequired().HasMaxLength(100);
            builder.HasIndex(a => a.UserName).IsUnique();
            builder.Property(a => a.FullName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Password).HasMaxLength(100);
            builder.HasMany(a => a.AppUserRoles).WithOne(a => a.AppUser)
                .HasForeignKey(a => a.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
