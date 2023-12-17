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
    }
}