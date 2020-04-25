﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBlog.Data.Dto
{
    public interface IDtoBase<TPrimaryKey>
    {
        TPrimaryKey ID { get; set; }
    }
}