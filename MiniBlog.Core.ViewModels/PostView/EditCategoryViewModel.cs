using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniBlog.Core.ViewModels.PostView
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("分类")]
        [Required(ErrorMessage = "漏掉{0}了哦")]
        [MaxLength(64,ErrorMessage ="{0}最大长度不超过{1}")]
        public string Category { get; set; }
    }
}
