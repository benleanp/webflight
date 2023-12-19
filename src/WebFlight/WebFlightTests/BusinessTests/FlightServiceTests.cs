using Microsoft.EntityFrameworkCore;
using WebFlightBusiness.Extensions;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;
using WebFlightInfrastructure;
using WebFlightInfrastructure.Repositories;

namespace WebFlightTests.BusinessTests;

[TestClass]
public class FlightServiceTests
{
    private FlightDatabase _database;
    private FlightRepository _repository;
    private Airport casaAirport;
    private Plane planeBoeing;
    private Airport tangerAirport;

    [TestInitialize]
    public void Setup()
    {
        planeBoeing = new Plane("Boeing X");
        casaAirport = new Airport("Casablanca", new GpsCoordinate(33.370105013882075, -7.584463116983734));
        tangerAirport = new Airport("Tanger", new GpsCoordinate(35.72626935970025, -5.912900916903573));
        var options = new DbContextOptionsBuilder<FlightDatabase>()
            .UseInMemoryDatabase("FlightDatabase3")
            .Options;

        _database = new FlightDatabase(options);
        _repository = new FlightRepository(_database);
        _database.Airports.Add(casaAirport.ToEntity());
        _database.Airports.Add(tangerAirport.ToEntity());
        _database.Planes.Add(planeBoeing.ToEntity());
        _database.SaveChanges();
    }

    [TestCleanup]
    public void Clean()
    {
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Flight_DepartureData_MustNotBeNull()
    {
        var flight = new Flight(null!, casaAirport, planeBoeing);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Flight_DestinationData_MustNotBeNull()
    {
        var flight = new Flight(casaAirport, null!, planeBoeing);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Flight_PlaneData_MustNotBeNull()
    {
        var flight = new Flight(casaAirport, tangerAirport, null!);
    }

    [TestMethod]
    public void FlightService_ShouldCreate_Flight()
    {
        IBusinessService<Flight> flightService = new FlightService(_repository);

        var flight = flightService.Add(new Flight
        {
            DepartureAirportId = 1,
            DestinationAirportId = 1,
            PlaneId = 1,
            Name = "Flight 1"
        });

        Assert.IsNotNull(flight);
        Assert.IsNotNull(flight.Name);
    }

    [TestMethod]
    public void Flight_ShouldCalculate_FuelConsumption()
    {
        var flight = new Flight(casaAirport, tangerAirport, planeBoeing);
        Assert.AreEqual(12, flight.CalculateFuelConsumption());
        Assert.AreEqual(12, flight.FuelConsumption);
    }

    [TestMethod]
    public void Flight_ShouldCalculate_Distance()
    {
        var flight = new Flight(casaAirport, tangerAirport, planeBoeing);
        Assert.AreEqual(303, flight.CalculateDistance());
        Assert.AreEqual(303, flight.Distance);
    }

    [TestMethod]
    public void Flight_ShouldCalculate_Duration()
    {
        var flight = new Flight(casaAirport, tangerAirport, planeBoeing);
        Assert.AreEqual(new TimeOnly(1, 40, 54), flight.CalculateFlightDuration());
        Assert.AreEqual(new TimeOnly(1, 40, 54), flight.Duration);
    }

    [TestMethod]
    public void GetAll_ReturnsAllFlight()
    {
        IBusinessService<Flight> airportService = new FlightService(_repository);
        var result = airportService.GetAll();
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
    }

    [TestMethod]
    public void Get_ReturnsSpecificFlight()
    {
        IBusinessService<Flight> service = new FlightService(_repository);
        var result = service.Get(1);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Update_ReturnsUpdatedFlight()
    {
        IBusinessService<Flight> service = new FlightService(_repository);
        var updatedAirports = new Flight
        {
            Id = 1,
            Name = "Airport 2 Updated"
        };

        var result = service.Update(updatedAirports);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("Airport 2 Updated", result.Name);
    }

    [TestMethod]
    public void Add_ReturnsAddedFlight()
    {
        IBusinessService<Flight> service = new FlightService(_repository);
        var flight = new Flight
        {
            Name = "Flight X"
        };

        var result = service.Add(flight);
        Assert.IsNotNull(result);
        Assert.AreEqual("Flight X", result.Name);
    }

    [TestMethod]
    public void Delete_ReturnsDeletedFlight()
    {
        IBusinessService<Flight> service = new FlightService(_repository);

        var result = service.Delete(1);
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }
}