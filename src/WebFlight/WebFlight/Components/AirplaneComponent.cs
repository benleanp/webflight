using Microsoft.AspNetCore.Mvc;
using WebFlight.Models;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;

namespace WebFlight.Components;

public class AirplaneComponent : ViewComponent
{
    private readonly IBusinessService<Plane> _airplaneService;

    public AirplaneComponent(IBusinessService<Plane> airplaneService)
    {
        _airplaneService = airplaneService;
    }

    public IViewComponentResult Invoke(int? id)
    {
        var model = new AirplaneViewModel();
        foreach (var airplane in _airplaneService.GetAll()) model.Planes.Add(airplane);

        if (id.HasValue)
        {
            model.Plane = _airplaneService.Get(id.Value);
            model.Mode = 1;
        }

        return View(model);
    }

    public void Add(AirplaneViewModel model)
    {
        if (model.Mode == 0)
            _airplaneService.Add(model.Plane);
        else if (model.Mode == 1) _airplaneService.Update(model.Plane);
    }

    [HttpPost]
    public void Remove(int id)
    {
        _airplaneService.Delete(id);
    }
}