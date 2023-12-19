using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFlight.Controllers;
using WebFlight.Models;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;
using WebFlightInfrastructure;
using WebFlightInfrastructure.Repositories;

namespace WebFlightTests.WebTests.ControllersTests;

[TestClass]
public class HomeControllerTests
{
    private FlightDatabase _database;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<FlightDatabase>()
            .UseInMemoryDatabase("FlightDatabase6")
            .Options;

        _database = new FlightDatabase(options);
    }

    [TestCleanup]
    public void Clean()
    {
        _database.Dispose();
    }

    [TestMethod]
    public void Index_ReturnsViewWithModel()
    {
        IBusinessService<Flight> flightService = new FlightService(new FlightRepository(_database));
        IBusinessService<Airport> airportService = new AirportService(new AirportRepository(_database));
        IBusinessService<Plane> planeService = new AirplaneService(new AirplaneRepository(_database));

        var controller = new HomeController(flightService, airportService, planeService);


        var result = controller.Index(null) as ViewResult;


        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Model, typeof(HomeViewModel));
    }

    [TestMethod]
    public void Add_RedirectsToIndex()
    {
        IBusinessService<Flight> flightService = new FlightService(new FlightRepository(_database));
        IBusinessService<Airport> airportService = new AirportService(new AirportRepository(_database));
        IBusinessService<Plane> planeService = new AirplaneService(new AirplaneRepository(_database));


        var planeBoeing = new Plane("Boeing X");
        var casaAirport = new Airport("Casablanca", new GpsCoordinate(33.370105013882075, -7.584463116983734));
        var tangerAirport = new Airport("Tanger", new GpsCoordinate(35.72626935970025, -5.912900916903573));
        var cmnFlight = new Flight(casaAirport, tangerAirport, planeBoeing);
        planeService.Add(planeBoeing);
        airportService.Add(casaAirport);
        airportService.Add(tangerAirport);
        var controller = new HomeController(flightService, airportService, planeService);
        var model = new HomeViewModel
        {
            Flight = cmnFlight, Mode = 0, SelectedDepartureFlightId = 1, SelectedPlaneId = 1,
            SelectedDestinationFlightId = 2
        };
        controller.Add(model);

        Assert.AreEqual(1, flightService.GetAll().Count);
    }

    [TestMethod]
    public void Remove_RedirectsToIndex()
    {
        IBusinessService<Flight> flightService = new FlightService(new FlightRepository(_database));
        IBusinessService<Airport> airportService = new AirportService(new AirportRepository(_database));
        IBusinessService<Plane> planeService = new AirplaneService(new AirplaneRepository(_database));

        var controller = new HomeController(flightService, airportService, planeService);
        controller.Remove(1);

        Assert.AreEqual(0, flightService.GetAll().Count);
    }
}