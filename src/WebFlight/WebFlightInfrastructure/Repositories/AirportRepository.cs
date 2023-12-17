using Microsoft.EntityFrameworkCore;
using WebFlightInfrastructure.Entities;

namespace WebFlightInfrastructure.Repositories;

public sealed class AirportRepository : Repository<AirportEntity>
{
    public AirportRepository(DbContext dbContext) : base(dbContext)
    {
    }
}