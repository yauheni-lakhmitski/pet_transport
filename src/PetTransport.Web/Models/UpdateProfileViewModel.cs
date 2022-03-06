using System.ComponentModel;

namespace PetTransport.Web.Models;

public class UpdateProfileViewModel
{
    public string ProfileImage { get; set; }
    [DisplayName("Имя")] public string FirstName { get; set; }
    [DisplayName("Фамилия")] public string LastName { get; set; }
    [DisplayName("Статус")] public string Status { get; set; }
    [DisplayName("Пол")] public string Sex { get; set; }

    [DisplayName("Местоположение")] public string Location { get; set; }
    public IFormFile File { get; set; }
}