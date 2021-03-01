using System.ComponentModel.DataAnnotations;

namespace accessPsychology.Models
{
    public class AccountViewModel
    {
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 4)]
        [DataType(DataType.Date)]
        [Display(Name = "用户名：")]
        public string user_name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码：")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "确认密码：")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "头像：")]
        [StringLength(50)]
        public string UserPhoto { get; set; }

        [Required]
        [Display(Name = "电话号码：")]
        [DataType(DataType.PhoneNumber)]
        public string tel_phone { get; set; }

        [Required]
        [Display(Name ="性别：")]
        public string sex { get; set; }

        [Required]
        public string identity { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 10)]
        [Display(Name = "自我介绍：")]
        [DataType(DataType.Text)]
        public string introduce { get; set; }
    }
}