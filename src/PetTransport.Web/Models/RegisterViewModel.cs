using System.ComponentModel.DataAnnotations;

namespace PetTransport.Web.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Поле имя обязательно к заполению")] 
    [Display(Name = "Имя")] public string FirstName { get; set; }
    [Required(ErrorMessage = "Отчество  обязательно к заполению")]
    [Display(Name = "Отчество")] public string PatronymicName { get; set; }

    [Required(ErrorMessage = "Поле фамилия обязательно к заполению")]
    [Display(Name = "Фамилия")] public string LastName { get; set; }

    [Required(ErrorMessage = "Email")] [Display(Name = "Email")] public string Email { get; set; }

    [Required(ErrorMessage = "Пароль обязателен к заполнению")] 
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Пароль обязателен к заполнению")] 
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    [Display(Name = "Подтвердить пароль")]
    public string PasswordConfirm { get; set; }

    [Required]
    [Range(typeof(bool), "true", "true", ErrorMessage = "Согласитесь с пользовательским соглашением.")]
    public bool IsPrivacyPolicyAccepted { get; set; }
}