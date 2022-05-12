using System.ComponentModel.DataAnnotations;

namespace PetTransport.Web.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Введите Email")] [Display(Name = "Email")] public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Введите пароль")]
    public string Password { get; set; }

    [Display(Name = "Запомнить?")] public bool RememberMe { get; set; }

    public string ReturnUrl { get; set; }
}