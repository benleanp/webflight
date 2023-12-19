using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebFlightBusiness.Models;

namespace WebFlight.Models;

public class HomeViewModel
{
    public List<Flight> Flights { get; set; } = new();
    public List<SelectListItem> DepartureAirports { get; private set; } = new();
    public List<SelectListItem> DestinationAirports { get; private set; } = new();
    public List<SelectListItem> Planes { get; private set; } = new();
    public Flight Flight { get; set; } = new();
    public int SelectedPlaneId { get; set; }
    public int SelectedDepartureFlightId { get; set; }
    public int SelectedDestinationFlightId { get; set; }
    public int Mode { get; set; }
}