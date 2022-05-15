using System.ComponentModel;
using PetTransport.Domain.Entities.Enums;

namespace PetTransport.Domain.Entities;

public class Application
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
    public string SourcePoint { get; set; }
    public string DestinationPoint { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? FinishedAt { get; set; }
    public Customer? Customer { get; set; }
    public Guid? CustomerId { get; set; }
    public List<ApplicationItem> OrderItems { get; set; } = new List<ApplicationItem>();
    public Guid? RideId { get; set; }
    public Ride Ride { get; set; }

    public User Manager { get; set; }
    public string ManagerId { get; set; }



    public void AddItems(IEnumerable<ApplicationItem> applicationItems)
    {
        OrderItems.AddRange(applicationItems);
    }
}


public class ApplicationItem
{
    public Guid Id { get; set; }
    public string ChipNumber { get; set; }
    public AnimalType AnimalType { get; set; }
    public Guid AnimalTypeId { get; set; }

    public string AnimalName { get; set; }
    public int Weight { get; set; }

    public decimal Price { get; set; }

}

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}