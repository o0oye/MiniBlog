using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBlog.Data.Entity;

namespace MiniBlog.Data.Configurations
{
    public class AdminEntityConfiguration : IEntityTypeConfiguration<AdminEntity>
    {
        public void Configure(EntityTypeBuilder<AdminEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.User)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasData(new AdminEntity
            {
                Id = 1,
                User = "admin",
                Password = "123456",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            });
        }
    }
}
