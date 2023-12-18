using WebFlightBusiness.Models;

namespace WebFlightBusiness.Services;

public interface IFlightService
{
    Flight CreateFlight(Airport src, Airport dest, Plane plane);
    List<Flight> GetAll();
    Flight Get(int id);
}