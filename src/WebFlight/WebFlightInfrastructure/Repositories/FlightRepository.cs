using Microsoft.EntityFrameworkCore;
using WebFlightInfrastructure.Entities;

namespace WebFlightInfrastructure.Repositories;

public sealed class FlightRepository : Repository<FlightEntity>
{
    public FlightRepository(DbContext dbContext) : base(dbContext)
    {
    }
}