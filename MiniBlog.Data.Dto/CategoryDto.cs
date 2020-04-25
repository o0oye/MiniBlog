using System.Collections.Generic;

namespace MiniBlog.Data.Dto
{
    public class CategoryDto : DtoBase<int>
    {
        public string Category { get; set; }
        public ICollection<PostDto> Posts { get; set; }
    }
}