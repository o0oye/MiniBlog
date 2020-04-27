using System;
using System.Collections.Generic;
using System.Text;
using MiniBlog.Data.Entity;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;

namespace MiniBlog.Core.Service
{
    public class PostService : ServiceBase<PostEntity, long>, IPostService
    {
        public PostService(IUnitOfWork unitOfWork, IRepository<PostEntity, long> repository)
            : base(unitOfWork, repository) { }
    }
}
