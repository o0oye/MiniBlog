using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBlog.Data.Dto
{
    public class PostDto : DtoBase<long>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
