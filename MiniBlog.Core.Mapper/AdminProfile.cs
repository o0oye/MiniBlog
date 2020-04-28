using AutoMapper;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.Mapper
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminEntity, EditAdminViewModel>().ReverseMap();
        }
    }
}
