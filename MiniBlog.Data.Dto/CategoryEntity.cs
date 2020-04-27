using System.Collections.Generic;

namespace MiniBlog.Data.Entity
{
    public class CategoryEntity : EntityBase<int>
    {
        public string Category { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
    }
}