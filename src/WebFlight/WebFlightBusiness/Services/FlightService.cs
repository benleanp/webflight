using WebFlightBusiness.Models;

namespace WebFlightBusiness.Services;

public class FlightService : IFlightService
{
    public FlightService()
    {
        //todo : inject FlightRepository
    }

    public Flight CreateFlight(Airport dept, Airport dest, Plane plane)
    {
        var flight = new Flight(dept, dest, plane);
        //TODO CALL repository to persist the flight 
        return flight;
    }
}