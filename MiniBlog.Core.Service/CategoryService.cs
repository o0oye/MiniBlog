using System;
using System.Collections.Generic;
using System.Text;
using MiniBlog.Data.Entity;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;

namespace MiniBlog.Core.Service
{
    public class CategoryService : ServiceBase<CategoryEntity, int>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<CategoryEntity, int> repository)
            : base(unitOfWork, repository) { }
    }
}
