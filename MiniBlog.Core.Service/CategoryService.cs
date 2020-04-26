using System;
using System.Collections.Generic;
using System.Text;
using MiniBlog.Data.Dto;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;

namespace MiniBlog.Core.Service
{
    public class CategoryService : ServiceBase<CategoryDto, int>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<CategoryDto, int> repository)
            : base(unitOfWork, repository) { }
    }
}
