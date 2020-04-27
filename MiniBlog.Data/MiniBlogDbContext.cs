using Microsoft.EntityFrameworkCore;
using MiniBlog.Data.Entity;
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
            modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PictureEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AdminEntity> Admin { get; set; }
        public DbSet<PostEntity> Post { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<PictureEntity> Picture { get; set; }
    }
}
