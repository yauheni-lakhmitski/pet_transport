using System.ComponentModel;

namespace PetTransport.Domain;

public class Car
{
    public Guid Id { get; set; }
    [DisplayName("Марка")]
    public string Make { get; set; }
    [DisplayName("Модель")]
    public string Model { get; set; }
    [DisplayName("Регистрационный номер")]
    public string RegistrationNumber { get; set; }

    public List<Car> Cars { get; set; }
}