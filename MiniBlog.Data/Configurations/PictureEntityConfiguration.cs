using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBlog.Data.Entity;

namespace MiniBlog.Data.Configurations
{
    public class PictureEntityConfiguration : IEntityTypeConfiguration<PictureEntity>
    {
        public void Configure(EntityTypeBuilder<PictureEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Origin)
                .HasMaxLength(256);
            builder.Property(m => m.Big)
                .HasMaxLength(256);
            builder.Property(m => m.Small)
                .HasMaxLength(256);
        }
    }
}
