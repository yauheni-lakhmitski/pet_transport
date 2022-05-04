namespace PetTransport.Domain.Entities;

public class RideDetail
{
    public int Mileage { get; set; }
    public int FuelUsed { get; set; }

    public Ride Ride { get; set; }
}