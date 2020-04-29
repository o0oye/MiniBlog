using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniBlog.Data.Entity;
using MiniBlog.Data.IData;
using MiniBlog.Core.IService;
using MiniBlog.Core.ViewModels.ListView;
using AutoMapper;


namespace MiniBlog.Core.Service
{
    public class PictureService : ServiceBase<PictureEntity, long>,IPictureService
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
            var result = await _Queryable.AsNoTracking().ToPagerAsync(pageIndex, rows);
            var listPictures = _mapper.Map<List<ListPictureViewModel>>(result.rows);
            return (result.total, listPictures);
        }
    }
}
