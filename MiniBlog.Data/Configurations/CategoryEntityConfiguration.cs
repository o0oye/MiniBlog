using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBlog.Data.Entity;

namespace MiniBlog.Data.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Category)
                .HasMaxLength(64)
                .IsRequired();
            builder.HasMany(m => m.Posts)
                .WithOne(o => o.Category)
                .HasForeignKey(k => k.CategoryId);
            builder.HasData(new List<CategoryEntity>
            {
                new CategoryEntity{ Id=1, Category="Category1", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryEntity{ Id=2, Category="Category2", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryEntity{ Id=3, Category="Category3", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryEntity{ Id=4, Category="Category4", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryEntity{ Id=5, Category="Category5", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryEntity{ Id=6, Category="Category6", CreateTime=DateTime.Now, UpdateTime=DateTime.Now}
            });
        }
    }
}
