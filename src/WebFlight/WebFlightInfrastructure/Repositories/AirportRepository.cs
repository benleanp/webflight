using Microsoft.EntityFrameworkCore;
using WebFlightInfrastructure.Entities;

namespace WebFlightInfrastructure.Repositories;

public sealed class AirportRepository : Repository<AirportEntity>
{
    public AirportRepository(FlightDatabase dbContext) : base(dbContext)
    {
    }
}