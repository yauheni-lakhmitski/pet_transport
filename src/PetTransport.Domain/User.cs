using Microsoft.AspNetCore.Identity;

namespace PetTransport.Domain;

public class User : IdentityUser
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Location { get; private set; }
    public List<UserTrip> UserTrips { get; set; }
    public string ImageUrl { get; private set; }
    public bool IsDeleted { get; private set; }

    private User() { }


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