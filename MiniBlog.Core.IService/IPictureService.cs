using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.ListView;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.IService
{
    public interface IPictureService : IServiceBase<PictureEntity, long>
    {
        Task<(int total, List<ListPictureViewModel> rows)> GetPagerAsync(int pageIndex, int rows);
        Task<int> DeletePicture(long id);
        Task<int> AddPicture(EditPictureViewModel editPictureViewModel);
    }
}
