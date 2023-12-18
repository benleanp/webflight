﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebFlight.Models;
using WebFlight.ViewComponents;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;

namespace WebFlight.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
     
    }

    public IActionResult Index()
    {
        return View();
    } 
}