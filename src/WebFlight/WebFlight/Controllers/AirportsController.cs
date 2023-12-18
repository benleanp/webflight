using Microsoft.AspNetCore.Mvc;
using WebFlight.Models;
using WebFlight.ViewComponents;

namespace WebFlight.Controllers;

public class AirportsController : Controller
{
    private readonly AirportViewComponent _airportComponent;

    public AirportsController(AirportViewComponent airportComponent)
    {
        _airportComponent = airportComponent;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(AirportViewModel airport)
    {
        _airportComponent.AddAirport(airport);
        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        _airportComponent.RemoveAirport(id);
        return RedirectToAction("Index");
    }
}