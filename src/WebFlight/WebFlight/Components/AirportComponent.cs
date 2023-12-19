using Microsoft.AspNetCore.Mvc;
using WebFlight.Models;
using WebFlightBusiness.Services;

namespace WebFlight.Components;

public class AirportComponent : ViewComponent
{
    private readonly IAirportService _airportService;

    public AirportComponent(IAirportService airportService)
    {
        _airportService = airportService;
    }

    public IViewComponentResult Invoke(int? id)
    {
        var model = new AirportViewModel();
        foreach (var airport in _airportService.GetAll())
        {
            model.Airports.Add(airport);
        }

        if (id.HasValue)
        {
            model.Airport = _airportService.Get(id.Value);
            model.Mode = 1;
        }

        return View(model);
    }

    public void Add(AirportViewModel model)
    {
        if (model.Mode == 0)
        {
            _airportService.Add(model.Airport);
        }
        else if (model.Mode == 1)
        {
            _airportService.Update(model.Airport);
        }
    }

    public void Remove(int id)
    {
        _airportService.Delete(id);
    }
}