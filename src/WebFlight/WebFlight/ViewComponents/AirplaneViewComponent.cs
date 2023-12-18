using Microsoft.AspNetCore.Mvc;
using WebFlight.Models;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;

namespace WebFlight.ViewComponents;

public class AirplaneViewComponent : ViewComponent
{
    private readonly IAirplaneService _airplaneService;

    public AirplaneViewComponent(IAirplaneService airplaneService)
    {
        _airplaneService = airplaneService;
    }

    public IViewComponentResult Invoke()
    {
        var airports = _airplaneService.GetAll();
        var airplanesVm = new List<AirplaneViewModel>();
        foreach (var airplane in airplanesVm)
        {
            airplanesVm.Add(new AirplaneViewModel()
            {
                Id = airplane.Id,
                Name = airplane.Name,
                Speed = airplane.Speed,
                FuelConsumption = airplane.FuelConsumption,
                TakeoffDuration = airplane.TakeoffDuration,
                TakeoffEffort = airplane.TakeoffEffort
            });
        }

        return View(airplanesVm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public void Add(AirplaneViewModel airplane)
    {
        _airplaneService.Add(new Plane()
        {
            Id = airplane.Id,
            Name = airplane.Name,
            Speed = airplane.Speed,
            FuelConsumption = airplane.FuelConsumption,
            TakeoffDuration = new TimeOnly(0, airplane.TakeoffDuration),
            TakeoffEffort = airplane.TakeoffEffort
        });
    }

    [HttpPost]
    public void Remove(int id)
    {
        _airplaneService.Delete(id);
    }
}