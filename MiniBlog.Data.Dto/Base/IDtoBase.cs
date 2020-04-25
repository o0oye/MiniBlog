using System;

namespace MiniBlog.Data.Dto
{
    public interface IDtoBase<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        DateTime CreateTime { get; set; }
        DateTime UpdateTime { get; set; }
    }
}
