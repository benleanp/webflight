using WebFlightBusiness.Models;
using WebFlightInfrastructure.Entities;

namespace WebFlightBusiness.Extensions;

public static class PlaneExtension
{
    public static Plane ToBusiness(this PlaneEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var model = new Plane(entity.Name)
        {
            Id = entity.Id,
            FuelConsumption = entity.FuelConsumption,
            Speed = entity.Speed,
            TakeoffDuration = entity.TakeoffDuration,
            TakeoffEffort = entity.TakeoffEffort
        };

        return model;
    }

    public static PlaneEntity ToEntity(this Plane model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));

        var entity = new PlaneEntity
        {
            Id = model.Id,
            Name = model.Name,
            FuelConsumption = model.FuelConsumption,
            Speed = model.Speed,
            TakeoffDuration = model.TakeoffDuration,
            TakeoffEffort = model.TakeoffEffort
        };

        return entity;
    }
}