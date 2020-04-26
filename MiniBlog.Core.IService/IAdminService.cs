using MiniBlog.Data.Dto;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.IService
{
    public interface IAdminService : IServiceBase<AdminDto, int>
    {
        bool Login(LoginViewModel loginViewModel);
    }
}
