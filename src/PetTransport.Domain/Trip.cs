using PetTransport.Domain;

public class Trip
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<UserTrip> UserTrips { get; set; } = default;
    public IEnumerable<TaskList> TaskLists { get; set; }
    public List<Message> Messages { get; set; } = default;
    public List<InviteCode> Invites { get; set; } = new List<InviteCode>();
}