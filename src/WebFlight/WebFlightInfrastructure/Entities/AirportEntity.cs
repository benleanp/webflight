using System.ComponentModel.DataAnnotations;

namespace WebFlightInfrastructure.Entities;

public sealed class AirportEntity : BaseEntity
{
    [MaxLength(64)] public string Name { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}