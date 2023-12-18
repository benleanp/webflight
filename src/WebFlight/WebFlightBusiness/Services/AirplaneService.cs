using WebFlightBusiness.Extensions;
using WebFlightBusiness.Models;
using WebFlightInfrastructure.Entities;
using WebFlightInfrastructure.Repositories;

namespace WebFlightBusiness.Services;

public sealed class AirplaneService : IAirplaneService
{
    private readonly AirplaneRepository _airplaneRepository;

    public AirplaneService(AirplaneRepository airplaneRepository)
    {
        _airplaneRepository = airplaneRepository;
    }

    public List<Plane> GetAll()
    {
        var planes = new List<Plane>();

        foreach (var entity in _airplaneRepository.GetAll())
        {
            planes.Add(entity.ToBusiness());
        }

        return planes;
    }

    public Plane Get(int id)
    {
        var entity = _airplaneRepository.Get(new PlaneEntity() { Id = id });
        return entity.ToBusiness();
    }

    public Plane Update(Plane model)
    {
        var entity = _airplaneRepository.Update(model.ToEntity());
        return entity.ToBusiness();
    }

    public Plane Add(Plane model)
    {
        var entity = _airplaneRepository.Create(model.ToEntity());
        _airplaneRepository.Commit();
        return entity.ToBusiness();
    }

    public Plane Delete(int id)
    {
        var entity = _airplaneRepository.Delete(new PlaneEntity() { Id = id });
        return entity.ToBusiness();
    }
}