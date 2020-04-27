using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.IService
{
    public interface IAdminService : IServiceBase<AdminEntity, int>
    {
        bool Login(LoginViewModel loginViewModel);
    }
}
