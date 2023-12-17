using System.ComponentModel.DataAnnotations.Schema;

namespace WebFlightInfrastructure.Entities;

public sealed class FlightEntity : BaseEntity
{
    public string FlightName { get; private set; }
    public int Distance { get; private set; }
    public int FuelConsumption { get; private set; }
    public TimeOnly Duration { get; private set; }

    public AirportEntity Departure { get; private set; }
    public AirportEntity Destination { get; private set; }
    public PlaneEntity Plane { get; private set; }
}