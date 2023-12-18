using Microsoft.EntityFrameworkCore;
using WebFlightInfrastructure.Entities;

namespace WebFlightInfrastructure.Repositories;

public sealed class FlightRepository : Repository<FlightEntity>
{
    public FlightRepository(FlightDatabase dbContext) : base(dbContext)
    {
    }

    public override FlightEntity Get(BaseEntity entity)
    {
        var db = DbContext as FlightDatabase;
        var flightEntities = db?.Flights.Include(x => x.Departure)
            .Include(x => x.Destination)
            .Include(x => x.Plane)
            .SingleOrDefault(x => x.Id == entity.Id);
        return flightEntities;
    }

    public override List<FlightEntity> GetAll()
    {
        var db = DbContext as FlightDatabase;
        var flightEntities = db?.Flights.Include(x => x.Departure)
            .Include(x => x.Destination)
            .Include(x => x.Plane)
            .ToList();
        return flightEntities;
    }
}