using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBlog.Data.Dto
{
    public class DtoBase<TPrimaryKey> : IDtoBase<TPrimaryKey>
    {
       public TPrimaryKey ID { get; set; }
    }
}
