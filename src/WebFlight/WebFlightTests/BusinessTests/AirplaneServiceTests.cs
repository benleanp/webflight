using Microsoft.EntityFrameworkCore;
using WebFlightBusiness.Models;
using WebFlightBusiness.Services;
using WebFlightInfrastructure;
using WebFlightInfrastructure.Entities;
using WebFlightInfrastructure.Repositories;

namespace WebFlightTests.BusinessTests;

[TestClass]
public class AirplaneServiceTests
{
    private FlightDatabase _database;
    private AirplaneRepository _repository;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<FlightDatabase>()
            .UseInMemoryDatabase(databaseName: "FlightDatabase1")
            .Options;

        _database = new FlightDatabase(options);
        _repository = new AirplaneRepository(_database);
        _database.Planes.Add(new PlaneEntity()
        {
            Name = "Plane 1",
        });
        _database.SaveChanges();
    }

    [TestCleanup]
    public void Clean()
    {
        _database.Dispose();
    }

    [TestMethod]
    public void GetAll_ReturnsAllPlanes()
    {
        IBusinessService<Plane> airplaneService = new AirplaneService(new AirplaneRepository(_database));
        var result = airplaneService.GetAll();
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
    }

    [TestMethod]
    public void Get_ReturnsSpecificPlane()
    {
        IBusinessService<Plane> airplaneService = new AirplaneService(_repository);
        int planeId = 1;

        var result = airplaneService.Get(planeId);

        Assert.IsNotNull(result);
        Assert.AreEqual(planeId, result.Id);
        Assert.AreEqual("Plane 1", result.Name);
    }

    [TestMethod]
    public void Update_ReturnsUpdatedPlane()
    {
        IBusinessService<Plane> airplaneService = new AirplaneService(_repository);
        var updatedPlane = new Plane
        {
            Id = 1,
            Name = "Plane 2",
            FuelConsumption = 10,
            TakeoffDuration = new TimeOnly(0, 5),
            TakeoffEffort = 5,
            Speed = 500
        };

        var result = airplaneService.Update(updatedPlane);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("Plane 2", result.Name);
        Assert.AreEqual(500, result.Speed);
        Assert.AreEqual(5, result.TakeoffEffort);
        Assert.AreEqual(new TimeOnly(0, 5), result.TakeoffDuration);
        Assert.AreEqual(10, result.FuelConsumption);
    }

    [TestMethod]
    public void Add_ReturnsAddedPlane()
    {
        IBusinessService<Plane> airplaneService = new AirplaneService(_repository);
        var newPlane = new Plane
        {
            Name = "Plane 3"
        };

        var result = airplaneService.Add(newPlane);
        Assert.IsNotNull(result);
        Assert.AreEqual("Plane 3", result.Name);
    }

    [TestMethod]
    public void Delete_ReturnsDeletedPlane()
    {
        IBusinessService<Plane> airplaneService = new AirplaneService(_repository);

        var result = airplaneService.Delete(1);
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }
}