using System;
using System.ComponentModel;

namespace MiniBlog.Core.ViewModels.ListView
{
    public class ListPostViewModel
    {
        public long Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }

        [DisplayName("分类")]
        public string Category { get; set; }
        
        [DisplayName("发布时间")]
        public DateTime CreateTime { get; set; }

        [DisplayName("缩略图")]
        public string Icon { get; set; }
    }
}
