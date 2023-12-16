namespace WebFlightBusiness.Models;

public class GpsCoordinate
{
    private const int EarthRadius = 6371;
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public GpsCoordinate(double lat, double lon)
    {
        Latitude = lat;
        Longitude = lon;
    }

    public static int CalculateDistance(GpsCoordinate p1, GpsCoordinate p2)
    {
        if (p1 == null)
            throw new ArgumentNullException(nameof(p1));
        if (p2 == null)
            throw new ArgumentNullException(nameof(p2));

        var dLat = (p2.Latitude - p1.Latitude) * (Math.PI / 180);
        var dLon = (p2.Longitude - p1.Longitude) * (Math.PI / 180);
        var a =
            Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
            Math.Cos((p1.Latitude) * (Math.PI / 180)) * Math.Cos((p2.Latitude) * (Math.PI / 180)) *
            Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        var distance = EarthRadius * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return (int)Math.Floor(distance);
    }
}