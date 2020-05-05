using AutoMapper;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.ListView;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.Mapper
{
    public class Picture : Profile
    {
        public Picture()
        {
            CreateMap<PictureEntity, ListPictureViewModel>().ReverseMap();
            CreateMap<PictureEntity, EditPictureViewModel>().ReverseMap();
        }
    }
}
