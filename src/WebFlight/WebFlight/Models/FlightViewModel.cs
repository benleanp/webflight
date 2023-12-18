namespace WebFlight.Models;

public class FlightViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Departure { get; set; }
    public string Destination { get; set; }
    public string Plane { get; set; }
    public int Distance { get; set; }
    public int FuelConsumption { get; set; }
    public TimeSpan Duration { get; set; }
}