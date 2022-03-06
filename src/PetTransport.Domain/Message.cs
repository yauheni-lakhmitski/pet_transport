namespace PetTransport.Domain; 

public class Message
{
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public Trip Trip { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
}