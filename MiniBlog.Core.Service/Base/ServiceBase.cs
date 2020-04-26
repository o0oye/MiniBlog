using System;
using MiniBlog.Data.Dto;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;

namespace MiniBlog.Core.Service
{
    public class ServiceBase<TEntity, TPrimaryKey> : IServiceBase<TEntity, TPrimaryKey>
        where TEntity : class, IDtoBase<TPrimaryKey>
    {
        //注入工作单元
        private readonly IUnitOfWork _unitOfWork;
        //注入仓储
        private readonly IRepository<TEntity, TPrimaryKey> _repository;
        public ServiceBase(IUnitOfWork unitOfWork, IRepository<TEntity, TPrimaryKey> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
    }
}
