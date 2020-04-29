using AutoMapper;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.ListView;

namespace MiniBlog.Core.Mapper
{
    public class Picture : Profile
    {
        public Picture()
        {
            CreateMap<PictureEntity, ListPictureViewModel>().ReverseMap();
        }
    }
}
