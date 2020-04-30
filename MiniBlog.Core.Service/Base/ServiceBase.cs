using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MiniBlog.Data.Entity;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;
using System.Collections.Generic;

namespace MiniBlog.Core.Service
{
    public class ServiceBase<TEntity, TPrimaryKey> : IServiceBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntityBase<TPrimaryKey>
    {
        //注入工作单元
        public IUnitOfWork _UnitOfWork { get; set; }

        //注入仓储
        public IRepository<TEntity, TPrimaryKey> _Repository { get; set; }

        //返回可远程查询
        public IQueryable<TEntity> _Queryable { get => _Repository.GetQueryable(); }

        public ServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity, TPrimaryKey> repository)
        {
            _UnitOfWork = unitOfWork;
            _Repository = repository;
        }

        //获取实体
        protected async ValueTask<TEntity> GetEntity(TPrimaryKey primaryKey)
        {
            return await _Repository.GetEntity(primaryKey);
        }

        //更新实体
        protected TEntity UpdateEntity(TEntity entity)
        {
            return _Repository.UpdateEntity(entity).Entity;
        }

        //删除实体
        protected async Task RemoveEntityAsync(TPrimaryKey primaryKey)
        {
            var entity = await GetEntity(primaryKey);
            if (entity != null)
            {
                _Repository.RemoveEntity(entity);
            }
        }
    }

    //分页类
    public static class Pager
    {
        public static async Task<(int total, List<TSource> rows)> ToPagerAsync<TSource>
            (this IQueryable<TSource> source, int pageIndex, int pageRows)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageRows < 1)
            {
                pageRows = 1;
            }
            var total = await source.CountAsync();
            var rows = await source.Skip(pageRows * (pageIndex - 1)).Take(pageRows).ToListAsync();
            return (total, rows);
        }
    }
}
