namespace PetTransport.Domain.Entities;

public class AnimalType
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<ApplicationItem> ApplicationItems  { get; set; }
}