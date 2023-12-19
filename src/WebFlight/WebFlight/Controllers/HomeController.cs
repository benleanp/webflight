using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebFlight.Models;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;

namespace WebFlight.Controllers;

public class HomeController : Controller
{
    private readonly IFlightService _flightService;
    private readonly IAirportService _airportService;
    private readonly IAirplaneService _airplaneService;

    public HomeController(IFlightService flightService, IAirportService airportService,
        IAirplaneService airplaneService)
    {
        _flightService = flightService;
        _airportService = airportService;
        _airplaneService = airplaneService;
    }

    public IActionResult Index(int? id)
    {
        var model = new HomeViewModel();
        foreach (var flight in _flightService.GetAll())
        {
            model.Flights.Add(flight);
        }

        foreach (var plane in _airplaneService.GetAll())
        {
            var item = new SelectListItem(plane.Name, plane.Id.ToString());
            model.Planes.Add(item);
        }

        foreach (var airport in _airportService.GetAll())
        {
            var item = new SelectListItem(airport.Name, airport.Id.ToString());
            model.DestinationAirports.Add(item);
            model.DepartureAirports.Add(item);
        }

        if (id.HasValue)
        {
            model.Flight = _flightService.Get(id.Value);
            model.Mode = 1;
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(HomeViewModel model)
    {
        model.Flight.PlaneId = model.SelectedPlaneId;
        model.Flight.DepartureAirportId = model.SelectedDepartureFlightId;
        model.Flight.DestinationAirportId = model.SelectedDestinationFlightId;
        if (model.Mode == 0)
        {
            _flightService.Add(model.Flight);
        }
        else if (model.Mode == 1)
        {
            _flightService.Update(model.Flight);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        _flightService.Delete(id);
        return RedirectToAction("Index");
    }
}