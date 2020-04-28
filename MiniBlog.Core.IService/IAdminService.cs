using System.Threading.Tasks;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.IService
{
    public interface IAdminService : IServiceBase<AdminEntity, int>
    {
        Task<bool> Login(LoginViewModel loginViewModel);

        Task<int> UpdateAdmin(EditAdminViewModel editAdminViewModel);

        Task<EditAdminViewModel> GetAdmin();
    }
}
