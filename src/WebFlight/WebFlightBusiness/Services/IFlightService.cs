using WebFlightBusiness.Models;

namespace WebFlightBusiness.Services;

public interface IFlightService
{
    Flight Add(Flight model);
    List<Flight> GetAll();
    Flight Get(int id);
    Flight Update(Flight model);
    Flight Delete(int id);
}