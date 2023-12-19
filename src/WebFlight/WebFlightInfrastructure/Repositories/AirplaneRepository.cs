using WebFlightInfrastructure.Entities;

namespace WebFlightInfrastructure.Repositories;

public sealed class AirplaneRepository : Repository<PlaneEntity>
{
    public AirplaneRepository(FlightDatabase dbContext) : base(dbContext)
    {
    }
}