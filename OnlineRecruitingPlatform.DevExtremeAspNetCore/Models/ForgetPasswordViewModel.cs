using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [Display(Name = "Электронная почта")]
        public  string Email { get; set; }
    }
}
