using Microsoft.EntityFrameworkCore;
using WebFlightInfrastructure.Entities;

namespace WebFlightInfrastructure.Repositories;

public sealed class PlaneRepository : Repository<PlaneEntity>
{
    public PlaneRepository(DbContext dbContext) : base(dbContext)
    {
    }
}