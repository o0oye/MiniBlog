using MiniBlog.Data.Dto;

namespace MiniBlog.Core.IService
{
    public interface IServiceBase<TEntity, TPrimaryKey>
        where TEntity : class, IDtoBase<TPrimaryKey>
    {
    }
}
