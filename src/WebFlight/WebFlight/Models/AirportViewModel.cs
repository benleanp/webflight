using WebFlightBusiness.Models;

namespace WebFlight.Models;

public class AirportViewModel
{
    public List<Airport> Airports { get; set; } = new();
    public Airport Airport { get; set; } = new();
    public int Mode { get; set; }
}