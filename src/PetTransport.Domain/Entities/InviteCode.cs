namespace PetTransport.Domain.Entities;

public class InviteCode
{
    public Guid Id { get; set; }
    public Trip Trip { get; set; }
    public Guid TripId { get; set; }
    public string Text { get; set; }
}