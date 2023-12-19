using WebFlightBusiness.Models;

namespace WebFlightBusiness.Services;

public interface IAirplaneService
{
    List<Plane> GetAll();
    Plane Get(int id);
    Plane Update(Plane model);
    Plane Delete(int id); 
    Plane Add(Plane model);
}