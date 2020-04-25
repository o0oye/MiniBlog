using Microsoft.EntityFrameworkCore;
using MiniBlog.Data.Dto;
using MiniBlog.Data.Configurations;

namespace MiniBlog.Data
{
    public class MiniBlogDbContext : DbContext
    {
        public MiniBlogDbContext(DbContextOptions<MiniBlogDbContext> option) : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminDtoConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryDtoConfiguration());
            modelBuilder.ApplyConfiguration(new PostDtoConfiguration());
            modelBuilder.ApplyConfiguration(new PictureDtoConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AdminDto> Admin { get; set; }
        public DbSet<PostDto> Post { get; set; }
        public DbSet<CategoryDto> Category { get; set; }
        public DbSet<PictureDto> Picture { get; set; }
    }
}
