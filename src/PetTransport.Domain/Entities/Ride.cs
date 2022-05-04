using System.ComponentModel;

namespace PetTransport.Domain.Entities;

public class Ride
{
    public Guid Id { get; set; }
    [DisplayName("Название поездки")]
    public string Name { get; set; }
    
    [DisplayName("Описание")]
    public string Description { get; set; }

    public string From { get; set; }
    public string To { get; set; }

    public Car Car { get; set; }
    public Guid CarId { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }
    
    [DisplayName("Дата создания")]
    public DateTime CreatedAt { get; set; }
    [DisplayName("Время обновления")]
    public DateTime UpdatedAt { get; set; }
    
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }

    public List<Application> Applications { get; set; } = new List<Application>();
    
    
    public void AddApplications(List<Application> applications)
    {
        Applications.AddRange(applications);
    }
}