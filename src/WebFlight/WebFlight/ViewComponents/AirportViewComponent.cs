using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using WebFlight.Models;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;

namespace WebFlight.ViewComponents;

public class AirportViewComponent : ViewComponent
{
    private readonly IAirportService _airportService;

    public AirportViewComponent(IAirportService airportService)
    {
        _airportService = airportService;
    }

    public IViewComponentResult Invoke()
    {
        var airports = _airportService.GetAll();
        List<AirportViewModel> airportsVm = new List<AirportViewModel>();
        foreach (var airport in airports)
        {
            airportsVm.Add(new AirportViewModel()
            {
                Id = airport.Id,
                Name = airport.Name,
                Latitude = airport.Coordinate.Latitude,
                Longitude = airport.Coordinate.Longitude,
            });
        }

        return View(airportsVm);
    }

    [HttpPost]
    public void AddAirport(AirportViewModel airport)
    {
        _airportService.Add(new Airport()
        {
            Name = airport.Name,
            Coordinate = new GpsCoordinate(airport.Latitude,airport.Longitude)
        });
    }

    [HttpPost]
    public void RemoveAirport(int id)
    {
        _airportService.Delete(id);
    }
}