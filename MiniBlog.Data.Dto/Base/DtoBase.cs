using System;

namespace MiniBlog.Data.Dto
{
    public class DtoBase<TPrimaryKey> : IDtoBase<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
