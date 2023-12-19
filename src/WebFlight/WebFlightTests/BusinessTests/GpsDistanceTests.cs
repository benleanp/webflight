using WebFlightBusiness.Models;

namespace WebFlightTests.BusinessTests;

[TestClass]
public class GpsDistanceTests
{
    [TestMethod]
    public void Gps_MustCalculate_DistanceBetween_TwoPoints()
    {
        var pointA = new GpsCoordinate(33.370105013882075, -7.584463116983734);
        var pointB = new GpsCoordinate(35.72626935970025, -5.912900916903573);
        var distance = GpsCoordinate.CalculateDistance(pointA, pointB);

        Assert.AreEqual(303, distance);
    }

    [TestMethod]
    public void Gps_DistanceMustBeZero()
    {
        var pointA = new GpsCoordinate(33.370105013882075, -7.584463116983734);
        var pointB = new GpsCoordinate(33.370105013882075, -7.584463116983734);
        var distance = GpsCoordinate.CalculateDistance(pointA, pointB);

        Assert.AreEqual(0, distance);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Gps_PointA_MustBeNonNull()
    {
        var pointB = new GpsCoordinate(33.370105013882075, -7.584463116983734);
        var distance = GpsCoordinate.CalculateDistance(null!, pointB);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Gps_PointB_MustBeNonNull()
    {
        var pointB = new GpsCoordinate(33.370105013882075, -7.584463116983734);
        var distance = GpsCoordinate.CalculateDistance(pointB, null!);
    }
}