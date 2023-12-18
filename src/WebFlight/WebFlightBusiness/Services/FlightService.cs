using WebFlightBusiness.Extensions;
using WebFlightBusiness.Models;
using WebFlightInfrastructure.Entities;
using WebFlightInfrastructure.Repositories;

namespace WebFlightBusiness.Services;

public class FlightService : IFlightService
{
    private readonly FlightRepository _flightRepository;

    public FlightService(FlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public Flight CreateFlight(Airport dept, Airport dest, Plane plane)
    {
        var flight = new FlightEntity()
        {
            Departure = dept.ToEntity(),
            Destination = dest.ToEntity(),
            Plane = plane.ToEntity()
        };
        var result = _flightRepository.Create(flight);
        _flightRepository.Commit();
        return new Flight()
        {
            Departure = result.Departure.ToBusiness(),
            Destination = result.Destination.ToBusiness(),
            Plane = result.Plane.ToBusiness(),
            FlightName = result.FlightName,
            FuelConsumption = result.FuelConsumption,
            Distance = result.Distance,
            Duration = result.Duration,
            Id = result.Id
        };
    }

    public List<Flight> GetAll()
    {
        var result = _flightRepository.GetAll();
        var flights = new List<Flight>();
        foreach (var item in result)
        {
            flights.Add(item.ToBusiness());
        }

        return flights;
    }

    public Flight Get(int id)
    {
        return _flightRepository.Get(new FlightEntity() { Id = id })?.ToBusiness()!;
    }
}