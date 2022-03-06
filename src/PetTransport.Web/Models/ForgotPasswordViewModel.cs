using System.ComponentModel.DataAnnotations;

namespace PetTransport.Web.Models;

public class ForgotPasswordViewModel
{
    [Required] [EmailAddress] public string Email { get; set; }
}