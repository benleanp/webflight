using Microsoft.EntityFrameworkCore;
using WebFlightInfrastructure.Entities;

namespace WebFlightInfrastructure;

public sealed class FlightDatabase : DbContext
{
    public DbSet<AirportEntity> Airports { get; set; }
    public DbSet<PlaneEntity> Planes { get; set; }
    public DbSet<FlightEntity> Flights { get; set; }

    public FlightDatabase(DbContextOptions<FlightDatabase> options)
        : base(options)
    {
        Database.EnsureCreated();
        Seed(this);
    }

    private void Seed(FlightDatabase context)
    {
        var planeBoeing = new PlaneEntity()
        {
            Name = "Boeing X",
            Speed = 500,
            TakeoffDuration = new TimeOnly(0, 5),
            TakeoffEffort = 3,
            FuelConsumption = 5
        };
        var casaAirport = new AirportEntity()
        {
            Name = "Casablanca",
            Latitude = 33.370105013882075,
            Longitude = -7.584463116983734
        };
        var tangierAirport = new AirportEntity()
        {
            Name = "Tanger",
            Latitude = 35.7262693597002,
            Longitude = -5.912900916903573
        };

        context.Airports.Add(casaAirport);
        context.Airports.Add(tangierAirport);
        context.Planes.Add(planeBoeing);
        context.SaveChanges();
    }
}