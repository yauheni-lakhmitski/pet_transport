using System.ComponentModel;

namespace PetTransport.Domain.Entities;

public class Application
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public DateTime PickUpDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
    public string SourcePoint { get; set; }
    public string DestinationPoint { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Customer? Customer { get; set; }
    public Guid? CustomerId { get; set; }
    public List<ApplicationItem> OrderItems { get; set; } = new List<ApplicationItem>();
    public Guid? RideId { get; set; }
    public Ride? Ride { get; set; }



    public void AddItems(IEnumerable<ApplicationItem> applicationItems)
    {
        OrderItems.AddRange(applicationItems);
    }
}

public enum ApplicationStatus
{
    [Description("В обработке")]
    Pending,
    [Description("Ожидает оплаты")]
    NotPaid,
    [Description("Оплачен")]
    Paid,
    [Description("В работе")]
    InProgress,
    [Description("Завершен")]
    Completed
}

public class ApplicationItem
{
    public Guid Id { get; set; }
    public string ChipNumber { get; set; }
    public AnimalType AnimalType { get; set; }
    public Guid AnimalTypeId { get; set; }

    public string AnimalName { get; set; }

    public decimal Price { get; set; }

}

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}