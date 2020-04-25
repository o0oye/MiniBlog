using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBlog.Data.Dto;


namespace MiniBlog.Data.Configurations
{
    public class PostDtoConfiguration : IEntityTypeConfiguration<PostDto>
    {
        public void Configure(EntityTypeBuilder<PostDto> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title)
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(e => e.Summary)
                .HasMaxLength(256);
            builder.Property(e => e.Content)
                .IsRequired()
                .HasColumnType("text");
            builder.Property(m => m.Icon)
                 .HasMaxLength(256);
        }
    }
}
