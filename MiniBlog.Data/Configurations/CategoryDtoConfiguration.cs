using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBlog.Data.Dto;

namespace MiniBlog.Data.Configurations
{
    public class CategoryDtoConfiguration : IEntityTypeConfiguration<CategoryDto>
    {
        public void Configure(EntityTypeBuilder<CategoryDto> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Category)
                .HasMaxLength(64)
                .IsRequired();
            builder.HasMany(m => m.Posts)
                .WithOne(o => o.Category)
                .HasForeignKey(k => k.CategoryId);
            builder.HasData(new List<CategoryDto>
            {
                new CategoryDto{ Id=1, Category="Category1", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryDto{ Id=2, Category="Category2", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryDto{ Id=3, Category="Category3", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryDto{ Id=4, Category="Category4", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryDto{ Id=5, Category="Category5", CreateTime=DateTime.Now, UpdateTime=DateTime.Now},
                new CategoryDto{ Id=6, Category="Category6", CreateTime=DateTime.Now, UpdateTime=DateTime.Now}
            });
        }
    }
}
