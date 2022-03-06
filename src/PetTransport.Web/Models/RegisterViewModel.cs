using System.ComponentModel.DataAnnotations;

namespace PetTransport.Web.Models;

public class RegisterViewModel
{
    [Required] [Display(Name = "Имя")] public string FirstName { get; set; }

    [Required] [Display(Name = "Фамилия")] public string LastName { get; set; }

    [Required] [Display(Name = "Email")] public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    [Display(Name = "Подтвердить пароль")]
    public string PasswordConfirm { get; set; }

    [Required]
    [Range(typeof(bool), "true", "true", ErrorMessage = "Прими прайваси полиси.")]
    public bool IsPrivacyPolicyAccepted { get; set; }
}