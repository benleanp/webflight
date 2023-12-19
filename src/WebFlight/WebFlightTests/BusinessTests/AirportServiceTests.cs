using Microsoft.EntityFrameworkCore;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;
using WebFlightInfrastructure;
using WebFlightInfrastructure.Entities;
using WebFlightInfrastructure.Repositories;

namespace WebFlightTests.BusinessTests;

[TestClass]
public class AirportServiceTests
{
    private FlightDatabase _database;
    private AirportRepository _repository;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<FlightDatabase>()
            .UseInMemoryDatabase(databaseName: "FlightDatabase2")
            .Options;

        _database = new FlightDatabase(options);
        _repository = new AirportRepository(_database);
        _database.Airports.Add(new AirportEntity()
        {
            Name = "Airport 1",
        });
        _database.SaveChanges();
    }

    [TestCleanup]
    public void Clean()
    {
        _database.Dispose();
    }

    [TestMethod]
    public void GetAll_ReturnsAllAirports()
    {
        IBusinessService<Airport> airportService = new AirportService(new AirportRepository(_database));
        var result = airportService.GetAll();
        Assert.IsNotNull(result); 
    }

    [TestMethod]
    public void Get_ReturnsSpecificAirports()
    {
        IBusinessService<Airport> airportService = new AirportService(_repository);

        var result = airportService.Get(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }

    [TestMethod]
    public void Update_ReturnsUpdatedAirports()
    {
        IBusinessService<Airport> airportService = new AirportService(_repository);
        var updatedAirports = new Airport()
        {
            Id = 1,
            Name = "Airport 2",
            Coordinate = new GpsCoordinate(1.0, 12.5)
        };

        var result = airportService.Update(updatedAirports);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("Airport 2", result.Name);
    }

    [TestMethod]
    public void Add_ReturnsAddedAirports()
    {
        IBusinessService<Airport> airportService = new AirportService(_repository);
        var newAirports = new Airport
        {
            Name = "Airport 3"
        };

        var result = airportService.Add(newAirports);
        Assert.IsNotNull(result);
        Assert.AreEqual("Airport 3", result.Name);
    }

    [TestMethod]
    public void Delete_ReturnsDeletedAirports()
    {
        IBusinessService<Airport> airportService = new AirportService(_repository);

        var result = airportService.Delete(1);
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }
}