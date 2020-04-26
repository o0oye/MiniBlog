using System;
using System.Collections.Generic;
using System.Text;
using MiniBlog.Data.Dto;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;

namespace MiniBlog.Core.Service
{
    public class PostService : ServiceBase<PostDto, long>, IPostService
    {
        public PostService(IUnitOfWork unitOfWork, IRepository<PostDto, long> repository)
            : base(unitOfWork, repository) { }
    }
}
