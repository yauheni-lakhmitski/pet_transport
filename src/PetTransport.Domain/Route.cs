public class Route
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Source { get; set; }
    public string Destination { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}