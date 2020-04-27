using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniBlog.Core.ViewModels.PostView
{
    public class EditAdminViewModel
    {
        public int Id { get; set; }

        [DisplayName("用户")]
        [Required(ErrorMessage = "{0}名漏了喔")]
        [MaxLength(32, ErrorMessage = "{0}长度不能超过{1}喔")]
        public string User { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "{0}漏了喔")]
        [MaxLength(32, ErrorMessage = "{0}长度不能超过{1}喔")]
        public string Password { get; set; }
    }
}
