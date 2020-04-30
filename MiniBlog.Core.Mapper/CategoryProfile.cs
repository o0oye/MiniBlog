using AutoMapper;
using MiniBlog.Data.Entity;
using MiniBlog.Core.ViewModels.ListView;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, ListCategoryViewModel>().ReverseMap();
            CreateMap<CategoryEntity,EditCategoryViewModel>().ReverseMap();
        }
    }
}
