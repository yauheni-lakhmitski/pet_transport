using System.ComponentModel;

namespace PetTransport.Domain.Entities;

public class Car:DomainEntity
{
    [DisplayName("Марка")]
    public string Make { get; set; }
    [DisplayName("Модель")]
    public string Model { get; set; }
    [DisplayName("Регистрационный номер")]
    public string RegistrationNumber { get; set; }

    public List<Ride> Rides { get; set; }
}