using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.ListView;

namespace MiniBlog.Core.IService
{
    public interface IPictureService : IServiceBase<PictureEntity, long>
    {
        Task<(int total, List<ListPictureViewModel> rows)> GetPagerAsync(int pageIndex, int rows);
    }
}
