namespace PetTransport.Domain.Entities; 

public class Message
{
    public Guid Id { get; set; }
    public Guid RideId { get; set; }
    public Ride Ride { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
}