using System;
using System.ComponentModel;
using System.Text;

namespace MiniBlog.Core.ViewModels.ListView
{
    public class ListCategoryViewModel
    {
        [DisplayName("编号")]
        public int Id { get; set; }

        [DisplayName("分类")]
        public string Category { get; set; }
    }
}
