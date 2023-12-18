using Microsoft.AspNetCore.Mvc;
using WebFlight.Models;
using WebFlight.ViewComponents;

namespace WebFlight.Controllers;

public class AirplanesController : Controller
{
    private readonly AirplaneViewComponent _airplaneComponent;

    public AirplanesController(AirplaneViewComponent airplaneComponent)
    {
        _airplaneComponent = airplaneComponent;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(AirplaneViewModel airplane)
    {
        _airplaneComponent.Add(airplane);
        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        _airplaneComponent.Remove(id);
        return RedirectToAction("Index");
    }
}