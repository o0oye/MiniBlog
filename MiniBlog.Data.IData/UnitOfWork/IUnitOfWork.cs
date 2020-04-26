using System.Threading.Tasks;

namespace MiniBlog.Data.IData
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
