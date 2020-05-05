using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBlog.Data.Entity;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;
using MiniBlog.Core.ViewModels.PostView;
using MiniBlog.Core.ViewModels.ListView;
using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;

namespace MiniBlog.Core.Service
{
    public class PostService : ServiceBase<PostEntity, long>, IPostService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public PostService(IUnitOfWork unitOfWork, IRepository<PostEntity, long> repository, IMapper mapper,
            ICategoryService categoryService) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        //获取博文
        public async Task<EditPostViewModel> GetPost(long id)
        {
            var postEntity = await GetEntity(id);
            return _mapper.Map<EditPostViewModel>(postEntity);
        }

        //发博文
        public async Task<int> AddPost(EditPostViewModel editPostViewModel)
        {
            var postEntity = _mapper.Map<PostEntity>(editPostViewModel);
            postEntity.CreateTime = DateTime.Now;
            postEntity.UpdateTime = postEntity.CreateTime;
            await AddEntity(postEntity);
            return await _UnitOfWork.SaveChangesAsync();
        }

        //编辑博文
        public async Task<int> UpdatePost(EditPostViewModel editPostViewModel)
        {
            var postEntity = _mapper.Map<PostEntity>(editPostViewModel);
            postEntity.UpdateTime = DateTime.Now;
            var entity=UpdateEntity(postEntity);
            entity.Property("CreateTime").IsModified = false;
            return await _UnitOfWork.SaveChangesAsync();
        }

        //删除博文
        public async Task<int> DeletePost(long id)
        {
            await RemoveEntityAsync(id);
            return await _UnitOfWork.SaveChangesAsync();
        }

        //分页列表
        public async Task<(int total, List<ListPostViewModel> rows)> GetPagerAsync(int pageIndex, int rows)
        {
            var categoryQueryable = _categoryService._Queryable;
            var result = await _Queryable
                .AsNoTracking()
                .Join(categoryQueryable, p => p.CategoryId, c => c.Id, (p, c) => new ListPostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    CreateTime = p.CreateTime,
                    Category = c.Category
                })
                .ToPagerAsync(pageIndex, rows);
            return (result.total, result.rows);
        }
    }
}
