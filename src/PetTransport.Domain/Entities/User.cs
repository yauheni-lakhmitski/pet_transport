using Microsoft.AspNetCore.Identity;

namespace PetTransport.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Location { get;  set; }
    public string ImageUrl { get;  set; }
    public bool IsDeleted { get;  set; }
   
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
    
    public void DeleteUser()
    {
        IsDeleted = true;
        FirstName = "Удаленный";
        LastName = "Пользователь";
        ImageUrl = "medium_male_default.png";
    }
}