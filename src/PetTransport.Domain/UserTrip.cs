namespace PetTransport.Domain;

public class UserTrip
{
    public Guid TripId { get; set; }
    public Trip Trip { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public Role RoleId { get; set; }
}