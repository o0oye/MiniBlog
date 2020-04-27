using System;

namespace MiniBlog.Data.Entity
{
    public class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
