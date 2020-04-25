using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBlog.Data.Dto;

namespace MiniBlog.Data.Configurations
{
    public class PictureDtoConfiguration : IEntityTypeConfiguration<PictureDto>
    {
        public void Configure(EntityTypeBuilder<PictureDto> builder)
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
