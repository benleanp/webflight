using WebFlightBusiness.Extensions;
using WebFlightBusiness.Models;
using WebFlightInfrastructure.Entities;
using WebFlightInfrastructure.Repositories;

namespace WebFlightBusiness.Services;

public class AirportService : IBusinessService<Airport>
{
    private readonly AirportRepository _airportRepository;

    public AirportService(AirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public List<Airport> GetAll()
    {
        var airports = new List<Airport>();

        foreach (var airportEntity in _airportRepository.GetAll())
        {
            airports.Add(airportEntity.ToBusiness());
        }

        return airports;
    }

    public Airport Get(int id)
    {
        var entity = _airportRepository.Get(new AirportEntity() { Id = id });
        return entity.ToBusiness();
    }

    public Airport Add(Airport model)
    {
        var entity = _airportRepository.Create(model.ToEntity());
        _airportRepository.Commit();
        return entity.ToBusiness();
    }
    public Airport Update(Airport model)
    {
        var entity = _airportRepository.Update(model.ToEntity());
        _airportRepository.Commit();
        return entity.ToBusiness();
    }

    public Airport Delete(int id)
    {
        var entity = _airportRepository.Delete(new AirportEntity() { Id = id });
        _airportRepository.Commit();
        return entity.ToBusiness();
    }
}