namespace WebFlightBusiness.Models;

public class Plane
{
    public Plane()
    {
    }

    public Plane(string planeName)
    {
        Name = planeName;
        Speed = 200; // default minimum speed allowed for flights;
        FuelConsumption = 4; // Average fuel consumption per 100Km
        TakeoffEffort = 2; // Consume 2 times fuel on takeoff
        TakeoffDuration = new TimeOnly(0, 10);
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Speed { get; set; }
    public int FuelConsumption { get; set; }
    public int TakeoffEffort { get; set; }
    public TimeOnly TakeoffDuration { get; set; }
}