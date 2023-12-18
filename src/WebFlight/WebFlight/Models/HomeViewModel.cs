using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebFlightBusiness.Models;

namespace WebFlight.Models;

public class HomeViewModel
{ 
    public string FlightName { get; set; } 
    public List<SelectListItem> DepartureAirports { get; private set; }
    public List<SelectListItem> DestinationAirports { get; private set; }
    public List<Plane> Planes { get; private set; }
    
    public HomeViewModel()
    {
        FlightName = "";
        DepartureAirports = new List<SelectListItem>();
        DestinationAirports = new List<SelectListItem>();
        Planes = new List<Plane>();
    }
}