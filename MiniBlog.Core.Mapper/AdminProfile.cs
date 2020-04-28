using AutoMapper;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.Mapper
{
    public class AdminMapperProfile : Profile
    {
        public AdminMapperProfile()
        {
            CreateMap<AdminEntity, EditAdminViewModel>().ReverseMap();
        }
    }
}
