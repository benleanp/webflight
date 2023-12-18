using WebFlightBusiness.Models;
using WebFlightInfrastructure.Entities;

namespace WebFlightBusiness.Extensions;

public static class FlightExtension
{
    public static Flight ToBusiness(this FlightEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var model = new Flight()
        {
            Departure = entity.Departure?.ToBusiness()!,
            Destination = entity.Destination?.ToBusiness()!,
            Plane = entity.Plane?.ToBusiness()!,
            FlightName = entity.FlightName,
            FuelConsumption = entity.FuelConsumption,
            Distance = entity.Distance,
            Duration = entity.Duration,
            Id = entity.Id
        };

        return model;
    }

    public static FlightEntity ToEntity(this Flight model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));

        var entity = new FlightEntity()
        {
            Departure = model.Departure.ToEntity(),
            Destination = model.Destination.ToEntity(),
            Plane = model.Plane.ToEntity(),
            Id = model.Id
        };

        return entity;
    }
}