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
            builder.HasMany(m=>m.Posts)
                .WithOne(o => o.Category)
                .HasForeignKey(k => k.CategoryId);
        }
    }
}
