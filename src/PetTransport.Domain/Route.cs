using System.ComponentModel;
using PetTransport.Domain;

public class Route
{
    public Guid Id { get; set; }
    [DisplayName("Название маршрута")]
    public string Name { get; set; }

    [DisplayName("Город отправления")]
    public string Source { get; set; }
    [DisplayName("Город прибытия")]
    public string Destination { get; set; }


    public Guid CarId { get; set; }
    [DisplayName("Машина")]
    public Car Car { get; set; }

    public Guid TransportationId { get; set; }
    public Transportation Transportation { get; set; }
    [DisplayName("Ориентировочное время отправления")]
    public DateTime StartTime { get; set; }

    [DisplayName("Ориентировочное время прибытия")]
    public DateTime EndTime { get; set; }
}