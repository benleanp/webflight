using WebFlightBusiness.Models;

namespace WebFlight.Models;

public class AirplaneViewModel
{
    public List<Plane> Planes { get; set; } = new();
    public Plane Plane { get; set; } = new();
    public int Mode { get; set; }
}