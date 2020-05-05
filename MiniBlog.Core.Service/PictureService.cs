using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniBlog.Data.Entity;
using MiniBlog.Data.IData;
using MiniBlog.Core.IService;
using MiniBlog.Core.ViewModels.ListView;
using AutoMapper;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.Service
{
    public class PictureService : ServiceBase<PictureEntity, long>, IPictureService
    {
        private readonly IMapper _mapper;
        public PictureService(IUnitOfWork unitOfWork, IRepository<PictureEntity, long> repository, IMapper mapper)
            : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        //获取分页图片列表
        public async Task<(int total, List<ListPictureViewModel> rows)> GetPagerAsync(int pageIndex, int rows)
        {
            var result = await _Queryable
                .AsNoTracking()
                .OrderByDescending(o => o.Id)
                .ToPagerAsync(pageIndex, rows);
            var listPictures = _mapper.Map<List<ListPictureViewModel>>(result.rows);
            return (result.total, listPictures);
        }

        //添加图片
        public async Task<int> AddPicture(EditPictureViewModel editPictureViewModel)
        {
            var pictureEntity = _mapper.Map<PictureEntity>(editPictureViewModel);
            pictureEntity.CreateTime = DateTime.Now;
            pictureEntity.UpdateTime = pictureEntity.CreateTime;
            await AddEntity(pictureEntity);
            return await _UnitOfWork.SaveChangesAsync();
        }

        //删除图片
        public async Task<int> DeletePicture(long id)
        {
            var entity = await GetEntity(id);
            if (entity == null)
            {
                return 0;
            }
            var big = entity.Big;
            var small = entity.Small;  
            //删除图片文件
            if(File.Exists(big))
            {
                //设置文件的属性为正常，这是为了防止文件是仅仅读
                File.SetAttributes(big, FileAttributes.Normal);
                File.Delete(big);
            }
            if (File.Exists(small))
            {
                File.SetAttributes(small, FileAttributes.Normal);
                File.Delete(small);
            }
            _Repository.RemoveEntity(entity);
            return await _UnitOfWork.SaveChangesAsync();
        }
    }
}
