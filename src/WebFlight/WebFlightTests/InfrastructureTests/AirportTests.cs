using Microsoft.EntityFrameworkCore;
using WebFlightBusiness.Extensions;
using WebFlightBusiness.Models;
using WebFlightInfrastructure;
using WebFlightInfrastructure.Entities;
using WebFlightInfrastructure.Repositories;

namespace WebFlightTests.InfrastructureTests;

[TestClass]
public class AirportTests
{
    private Airport casaAirport;
    private Flight cmnFlight;
    private FlightDatabase database;
    private Plane planeBoeing;
    private Airport tangerAirport;

    [TestInitialize]
    public void Setup()
    {
        planeBoeing = new Plane("Boeing X");
        casaAirport = new Airport("Casablanca", new GpsCoordinate(33.370105013882075, -7.584463116983734));
        tangerAirport = new Airport("Tanger", new GpsCoordinate(35.72626935970025, -5.912900916903573));
        cmnFlight = new Flight(casaAirport, tangerAirport, planeBoeing);
        var options = new DbContextOptionsBuilder<FlightDatabase>()
            .UseInMemoryDatabase("FlightDatabase4")
            .Options;
        database = new FlightDatabase(options);
    }

    [TestCleanup]
    public void Clean()
    {
        database.Dispose();
    }

    [TestMethod]
    public void FlightDatabase_ShouldInsert_New_Airport()
    {
        var airportRepository = new AirportRepository(database);
        var airportEntity = casaAirport.ToEntity();
        var result = airportRepository.Create(airportEntity);
        database.SaveChanges();
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
        Assert.IsNotNull(airportRepository.Get(new AirportEntity { Id = 1 }));
    }

    [TestMethod]
    public void FlightDatabase_ShouldUpdate_Airport()
    {
        var airportRepository = new AirportRepository(database);
        var airportEntity = casaAirport.ToEntity();
        airportRepository.Create(airportEntity);
        database.SaveChanges();
        airportEntity.Name = "Updated";
        var result = airportRepository.Update(airportEntity);
        database.SaveChanges();
        Assert.IsNotNull(result);
        Assert.AreEqual("Updated", result.Name);
    }

    [TestMethod]
    public void FlightDatabase_ShouldDelete_Airport()
    {
        var airportRepository = new AirportRepository(database);
        var airportEntity = casaAirport.ToEntity();
        airportEntity = airportRepository.Create(airportEntity);
        database.SaveChanges();
        var result = airportRepository.Delete(airportEntity);
        database.SaveChanges();
        Assert.IsNull(airportRepository.Get(airportEntity));
    }
}