namespace WebFlightInfrastructure.Entities;

public sealed class PlaneEntity : BaseEntity
{
    public string Name { get; set; }
    public int Speed { get; set; }
    public int FuelConsumption { get; set; }
    public int TakeoffEffort { get; set; }
    public TimeOnly TakeoffDuration { get; set; }
}