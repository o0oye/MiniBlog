using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBlog.Data.Entity;


namespace MiniBlog.Data.Configurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title)
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(e => e.Summary)
                .HasMaxLength(256);
            builder.Property(e => e.Content)
                .HasColumnType("text");
            builder.Property(m => m.Icon)
                 .HasMaxLength(256);
            builder.Property(m => m.IsShow)
                .IsRequired();
        }
    }
}
