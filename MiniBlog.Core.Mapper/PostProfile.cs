using System;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.ListView;
using MiniBlog.Core.ViewModels.PostView;
using AutoMapper;

namespace MiniBlog.Core.Mapper
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostEntity, EditPostViewModel>().ReverseMap();
            CreateMap<PostEntity, ListPostViewModel>().ReverseMap();
        }
    }
}
