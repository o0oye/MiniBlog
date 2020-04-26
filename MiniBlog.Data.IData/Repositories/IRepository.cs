using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MiniBlog.Data.Dto;

namespace MiniBlog.Data.IData.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IDtoBase<TPrimaryKey>
    {
        //返回可以远程查询
        IQueryable<TEntity> GetQueryable();

        //返回实体
        ValueTask<TEntity> GetEntity(TPrimaryKey key);

        //添加实体
        ValueTask<EntityEntry<TEntity>> AddEntity(TEntity entity);

        //批量添加实体
        Task AddRange(IEnumerable<TEntity> entities);

        //更新实体
        EntityEntry<TEntity> UpdateEntity(TEntity entity);

        //批量更新实体
        void UpdateRange(IEnumerable<TEntity> entities);

        //删除实体
        EntityEntry<TEntity> RemoveEntity(TEntity entity);

        //批量删除实体
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
