using WebFlightBusiness.Models;
using WebFlightBusiness.Services;

namespace WebFlightTests.BusinessTests;

[TestClass]
public class FlightServiceTests
{
    private Airport casaAirport;
    private Airport tangerAirport;
    private Plane planeBoeing;

    [TestInitialize]
    public void Setup()
    {
        planeBoeing = new Plane("Boeing X");
        casaAirport = new Airport("Casablanca", new GpsCoordinate(33.370105013882075, -7.584463116983734));
        tangerAirport = new Airport("Tanger", new GpsCoordinate(35.72626935970025, -5.912900916903573));
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
        /*IFlightService flightService = new FlightService();

        var flight = flightService.CreateFlight(casaAirport, tangerAirport, planeBoeing);

        Assert.IsNotNull(flight);
        Assert.IsNotNull(flight.FlightName);
        Assert.IsNotNull(flight.Departure);
        Assert.IsNotNull(flight.Destination);
        Assert.IsNotNull(flight.Plane);

        Assert.AreEqual(0, flight.Distance);
        Assert.AreEqual(0, flight.FuelConsumption);
        Assert.AreEqual(TimeOnly.MinValue, flight.Duration);*/
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
}