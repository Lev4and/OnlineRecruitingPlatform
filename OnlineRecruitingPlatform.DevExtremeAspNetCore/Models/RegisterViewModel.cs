using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Укажите роль пользователя")]
        [Display(Name = "Идентификационный номер роли")]
        public string RoleId { get; set; }

        [Required(ErrorMessage = "Введите логин пользователя")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
