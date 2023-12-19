using WebFlightBusiness.Extensions;
using WebFlightBusiness.Models;
using WebFlightInfrastructure.Entities;
using WebFlightInfrastructure.Repositories;

namespace WebFlightBusiness.Services;

public class FlightService : IBusinessService<Flight>
{
    private readonly FlightRepository _flightRepository;

    public FlightService(FlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public Flight Add(Flight model)
    {
        var result = _flightRepository.Create(model.ToEntity());
        _flightRepository.Commit();
        return result.ToBusiness();
    }

    public List<Flight> GetAll()
    {
        var result = _flightRepository.GetAll();
        var flights = new List<Flight>();
        foreach (var item in result) flights.Add(item.ToBusiness());

        return flights;
    }

    public Flight Get(int id)
    {
        return _flightRepository.Get(new FlightEntity { Id = id })?.ToBusiness()!;
    }

    public Flight Update(Flight model)
    {
        var entity = _flightRepository.Update(model.ToEntity());
        _flightRepository.Commit();
        return entity.ToBusiness();
    }


    public Flight Delete(int id)
    {
        var entity = _flightRepository.Delete(new FlightEntity { Id = id });
        _flightRepository.Commit();
        return entity.ToBusiness();
    }
}