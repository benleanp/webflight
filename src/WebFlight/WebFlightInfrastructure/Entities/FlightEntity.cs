using System.ComponentModel.DataAnnotations.Schema;

namespace WebFlightInfrastructure.Entities;

public sealed class FlightEntity : BaseEntity
{
    public string Name { get; private set; }
    public int DepartureAirportId { get; set; }
    public int DestinationAirportId { get; set; }
    public int PlaneId { get; set; } 
    [ForeignKey("DepartureAirportId")] public AirportEntity Departure { get; set; }
    [ForeignKey("DestinationAirportId")] public AirportEntity Destination { get; set; }
    [ForeignKey("PlaneId")] public PlaneEntity Plane { get; set; }
}