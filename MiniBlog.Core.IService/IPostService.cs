using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBlog.Core.ViewModels.ListView;
using MiniBlog.Core.ViewModels.PostView;
using MiniBlog.Data.Entity;

namespace MiniBlog.Core.IService
{
    public interface IPostService : IServiceBase<PostEntity, long>
    {
        Task<EditPostViewModel> GetPost(long id);
        Task<int> AddPost(EditPostViewModel editPostViewModel);
        Task<int> DeletePost(long id);
        Task<int> UpdatePost(EditPostViewModel editPostViewModel);
        Task<(int total, List<ListPostViewModel> rows)> GetPagerAsync(int pageIndex, int rows);

    }
}
