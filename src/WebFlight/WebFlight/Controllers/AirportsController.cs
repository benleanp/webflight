using Microsoft.AspNetCore.Mvc;
using WebFlight.Components;
using WebFlight.Models; 

namespace WebFlight.Controllers;

public class AirportsController : Controller
{
    private readonly AirportComponent _airportComponent;

    public AirportsController(AirportComponent airportComponent)
    {
        _airportComponent = airportComponent;
    }

    public IActionResult Index(int? id)
    {
        ViewData["id"] = id;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(AirportViewModel airportView)
    {
        _airportComponent.Add(airportView);
        return RedirectToAction("Index");
    } 

    [HttpGet]
    public IActionResult Remove(int id)
    {
        _airportComponent.Remove(id);
        return RedirectToAction("Index");
    }
}