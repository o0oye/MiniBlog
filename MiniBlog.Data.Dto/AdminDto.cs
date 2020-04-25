using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBlog.Data.Dto
{
    public class AdminDto : DtoBase<int>
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
