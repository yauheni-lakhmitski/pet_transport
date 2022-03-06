namespace PetTransport.Domain;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public TaskList TaskList { get; set; }
    public Guid TaskListId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsCompleted { get; set; }
}


public class TaskList
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid TripId { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<Task> Tasks { get; set; }
    public Trip Trip { get; set; }
}