using Microsoft.AspNetCore.Mvc;
using WebFlight.Components;
using WebFlight.Models;

namespace WebFlight.Controllers;

public class AirplanesController : Controller
{
    private readonly AirplaneComponent _airplaneComponent;

    public AirplanesController(AirplaneComponent airplaneComponent)
    {
        _airplaneComponent = airplaneComponent;
    }

    public IActionResult Index(int? id)
    {
        ViewData["id"] = id;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(AirplaneViewModel airplaneView)
    {
        _airplaneComponent.Add(airplaneView);
        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        _airplaneComponent.Remove(id);
        return RedirectToAction("Index");
    }
}