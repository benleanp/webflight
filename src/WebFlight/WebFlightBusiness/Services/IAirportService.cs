using WebFlightBusiness.Models;

namespace WebFlightBusiness.Services;

public interface IAirportService
{
    List<Airport> GetAll();
    Airport Get(int id);
    Airport Update(Airport model);
    Airport Delete(int id); 
    Airport Add(Airport model);
}