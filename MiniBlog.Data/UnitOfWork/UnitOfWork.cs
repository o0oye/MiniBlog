using System.Threading.Tasks;
using MiniBlog.Data.IData;

namespace MiniBlog.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiniBlogDbContext _miniBlogDbContext;
        public UnitOfWork(MiniBlogDbContext dbContext)
        {
            _miniBlogDbContext = dbContext;
        }
        public int SaveChanges()
        {
            return _miniBlogDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _miniBlogDbContext.SaveChangesAsync();
        }
    }
}
