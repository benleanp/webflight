using Microsoft.AspNetCore.Mvc;
using WebFlight.Models;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;
using WebFlightInfrastructure.Entities;

namespace WebFlight.Controllers;

public class FlightsController : Controller
{
    public FlightsController()
    {
      
    }
    public IActionResult Index()
    {
        return View();
    }

}