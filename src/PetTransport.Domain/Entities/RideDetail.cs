namespace PetTransport.Domain.Entities;

public class RideDetail
{
    public Guid Id { get; set; }
    public int Mileage { get; set; }
    public int FuelUsed { get; set; }
    
    public Guid RideId { get; set; }
    public Ride Ride { get; set; }
}