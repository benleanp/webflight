using Microsoft.EntityFrameworkCore;
using WebFlightBusiness.Models;
using WebFlightInfrastructure;

namespace WebFlightTests.InfrastructureTests;

[TestClass]
public class InfrastructureTests
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
            .UseInMemoryDatabase("FlightDatabase5")
            .Options;
        database = new FlightDatabase(options);
    }

    [TestCleanup]
    public void Clean()
    {
        database.Dispose();
    }
}