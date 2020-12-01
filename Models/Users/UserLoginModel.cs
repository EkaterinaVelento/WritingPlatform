using System.ComponentModel.DataAnnotations;


namespace Models.Users
{
    public class UserLoginModel : IdentityModel
    {
        [Display(Name = "Логин")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите логин")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}