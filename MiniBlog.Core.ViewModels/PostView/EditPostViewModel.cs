using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniBlog.Core.ViewModels.PostView
{
    public class EditPostViewModel
    {
        public long Id { get; set; }

        [DisplayName("标题")]
        [Required(ErrorMessage = "漏掉{0}了喔")]
        [MaxLength(64, ErrorMessage = "{0}长度不能超过{1}喔")]
        public string Title { get; set; }

        [DisplayName("标题")]
        [Required(ErrorMessage = "漏掉{0}了喔")]
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }

        [DisplayName("分类")]
        [Required(ErrorMessage = "漏掉{0}了喔")]
        public int CategoryId { get; set; }
    }
}