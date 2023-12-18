using Microsoft.AspNetCore.Mvc.RazorPages;
using WebFlightBusiness.Models;

namespace WebFlight.Models;

public class FlightsViewModel
{
    public List<Flight> Flights { get; set; }

    public FlightsViewModel()
    {
        Flights = new List<Flight>();
    }
}