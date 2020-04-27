using System;

namespace MiniBlog.Data.Entity
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        DateTime CreateTime { get; set; }
        DateTime UpdateTime { get; set; }
    }
}
