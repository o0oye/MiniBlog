using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MiniBlog.Data.Entity;
using MiniBlog.Data.IData;

namespace MiniBlog.Data
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntityBase<TPrimaryKey>
    {
        private readonly MiniBlogDbContext _miniBlogDbContext;
        private DbSet<TEntity> _dbSet => _miniBlogDbContext.Set<TEntity>();
        public Repository(MiniBlogDbContext miniBlogDbContext)
        {
            _miniBlogDbContext = miniBlogDbContext;
        }

        //返回可以远程查询
        public virtual IQueryable<TEntity> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        //返回实体
        public virtual async ValueTask<TEntity> GetEntity(TPrimaryKey key)
        {
            return await _dbSet.FindAsync(key);
        }

        //添加实体
        public virtual async ValueTask<EntityEntry<TEntity>> AddEntity(TEntity entity)
        {
            return await _dbSet.AddAsync(entity);
        }

        //批量添加实体
        public virtual async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        //更新实体
        public virtual EntityEntry<TEntity> UpdateEntity(TEntity entity)
        {
            return _dbSet.Update(entity);
        }

        //批量更新实体
        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        //删除实体
        public EntityEntry<TEntity> RemoveEntity(TEntity entity)
        {
            return _dbSet.Remove(entity);
        }

        //批量删除实体
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
