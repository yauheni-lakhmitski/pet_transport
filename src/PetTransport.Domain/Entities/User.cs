using Microsoft.AspNetCore.Identity;

namespace PetTransport.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string PatronymicName { get; set; }
    public string DriverLicence { get; set; }
    public string Location { get;  set; }
    public string ImageUrl { get;  set; }
    public bool IsBlocked { get;  set; }

    public List<Application> Applications { get; set; }
    public List<Message> Messages { get; set; }
   
    public void UpdateProfileInfo(string firstName, string lastName, string location)
    {
        FirstName = firstName;
        LastName = lastName;
        Location = location;
    }

    public void UpdateProfileImage(string imageUrl)
    {
        ImageUrl = imageUrl;
    }
    
    // public void DeleteUser()
    // {
    //     IsBlocked = true;
    //     FirstName = "Удаленный";
    //     LastName = "Пользователь";
    //     ImageUrl = "medium_male_default.png";
    // }
}