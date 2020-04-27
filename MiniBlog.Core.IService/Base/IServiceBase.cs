using MiniBlog.Data.Entity;

namespace MiniBlog.Core.IService
{
    public interface IServiceBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntityBase<TPrimaryKey>
    {
    }
}
