namespace WebFlightBusiness.Models;

public class Airport
{
    public int Id { get; set; }
    public string Name { get; set; }

    public GpsCoordinate Coordinate { get; private set; }

    public Airport(string name, GpsCoordinate coordinate)
    {
        Name = name;
        Coordinate = coordinate;
    }
}