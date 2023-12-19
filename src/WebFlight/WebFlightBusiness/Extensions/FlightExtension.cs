using WebFlightBusiness.Models;
using WebFlightInfrastructure.Entities;

namespace WebFlightBusiness.Extensions;

public static class FlightExtension
{
    public static Flight ToBusiness(this FlightEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var model = new Flight
        {
            Departure = entity.Departure?.ToBusiness()!,
            Destination = entity.Destination?.ToBusiness()!,
            Plane = entity.Plane?.ToBusiness()!,
            PlaneId = entity.PlaneId,
            DepartureAirportId = entity.DepartureAirportId,
            DestinationAirportId = entity.DestinationAirportId,
            Name = entity.Name,
            Id = entity.Id
        };

        return model;
    }

    public static FlightEntity ToEntity(this Flight model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));

        var entity = new FlightEntity
        {
            PlaneId = model.PlaneId,
            DepartureAirportId = model.DepartureAirportId,
            DestinationAirportId = model.DestinationAirportId,
            Id = model.Id,
            Name = model.Name
        };

        return entity;
    }
}