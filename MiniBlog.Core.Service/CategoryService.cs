using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MiniBlog.Data.Entity;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;
using MiniBlog.Core.ViewModels.ListView;
using MiniBlog.Core.ViewModels.PostView;
using AutoMapper;
using System;

namespace MiniBlog.Core.Service
{
    public class CategoryService : ServiceBase<CategoryEntity, int>, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IRepository<CategoryEntity, int> repository, IMapper mapper)
            : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        //获取全部分类
        public async Task<List<ListCategoryViewModel>> GetAllCategories()
        {
            var listCategory = await _Queryable.AsNoTracking().ToListAsync();
            return _mapper.Map<List<ListCategoryViewModel>>(listCategory);
        }

        //获取类别
        public async Task<EditCategoryViewModel> GetCategory(int Id)
        {
            var editCategoryViewModel = await GetEntity(Id);
            return _mapper.Map<EditCategoryViewModel>(editCategoryViewModel);
        }

        //修改类别
        public async Task<int> UpdateCategory(EditCategoryViewModel editCategoryViewModel)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(editCategoryViewModel);
            categoryEntity.UpdateTime = DateTime.Now;
            var entity = UpdateEntity(categoryEntity);
            entity.Property("CreateTime").IsModified = false;
            return await _UnitOfWork.SaveChangesAsync();
        }
    }
}
