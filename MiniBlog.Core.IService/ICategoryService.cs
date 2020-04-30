using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.ListView;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.IService
{
    public interface ICategoryService : IServiceBase<AdminEntity, int>
    {
        Task<List<ListCategoryViewModel>> GetAllCategories();

        Task<EditCategoryViewModel> GetCategory(int Id);

        Task<int> UpdateCategory(EditCategoryViewModel editCategoryViewModel);
    }
}
;