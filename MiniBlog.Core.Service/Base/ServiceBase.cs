using System;
using System.Linq;
using System.Threading.Tasks;
using MiniBlog.Data.Entity;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;

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
        public async ValueTask<TEntity> GetEntity(TPrimaryKey primaryKey)
        {
           return await _Repository.GetEntity(primaryKey);
        }
    }
}
