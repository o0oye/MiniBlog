using System;
using System.ComponentModel;

namespace MiniBlog.Core.ViewModels.ListView
{
    public class ListPictureViewModel
    {
        [DisplayName("编号")]
        public long Id { get; set; }

        [DisplayName("原图")]
        public string Origin { get; set; }

        [DisplayName("大图")]
        public string Big { get; set; }

        [DisplayName("小图")]
        public string Small { get; set; }

        [DisplayName("上传时间")]
        public DateTime CreateTime { get; set; }
    }
}
