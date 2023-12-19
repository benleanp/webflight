using WebFlightBusiness.Models;
using WebFlightInfrastructure.Entities;

namespace WebFlightBusiness.Extensions;

public static class AirportExtension
{
    public static Airport ToBusiness(this AirportEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var p = new Airport(entity.Name, new GpsCoordinate(entity.Latitude, entity.Longitude))
        {
            Id = entity.Id
        };

        return p;
    }

    public static AirportEntity ToEntity(this Airport model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));

        var entity = new AirportEntity
        {
            Id = model.Id,
            Latitude = model.Coordinate.Latitude,
            Longitude = model.Coordinate.Longitude,
            Name = model.Name
        };
        return entity;
    }
}