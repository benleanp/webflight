namespace WebFlightBusiness.Models;

public class Airport
{
    public int Id { get; set; }
    public string Name { get; set; }

    public GpsCoordinate Coordinate { get; set; }

    public Airport()
    {
        Coordinate = new GpsCoordinate();
    }
    public Airport(string name, GpsCoordinate coordinate)
    {
        Name = name;
        Coordinate = coordinate;
    }
}