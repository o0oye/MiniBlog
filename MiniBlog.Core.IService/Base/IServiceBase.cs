using MiniBlog.Data.Entity;
using System.Linq;

namespace MiniBlog.Core.IService
{
    public interface IServiceBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntityBase<TPrimaryKey>
    {
        IQueryable<TEntity> _Queryable { get; }
    }
}
