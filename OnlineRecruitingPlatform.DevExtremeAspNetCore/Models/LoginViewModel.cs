using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
