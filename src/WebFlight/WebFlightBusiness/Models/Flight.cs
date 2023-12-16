namespace WebFlightBusiness.Models;

public class Flight
{
    public string FlightName { get; private set; }
    public Airport Departure { get; private set; }
    public Airport Destination { get; private set; }
    public Plane Plane { get; private set; }
    public int Distance { get; private set; }
    public int FuelConsumption { get; private set; }
    public TimeOnly Duration { get; private set; }

    public Flight(Airport dept, Airport dest, Plane plane)
    {
        Departure = dept ?? throw new ArgumentNullException(nameof(dept));
        Destination = dest ?? throw new ArgumentNullException(nameof(dest));
        Plane = plane ?? throw new ArgumentNullException(nameof(plane));
        FlightName = $"Flight {dept.Name}-{dest.Name}";
    }

    public int CalculateDistance()
    {
        Distance = GpsCoordinate.CalculateDistance(Departure.Coordinate, Destination.Coordinate);
        return Distance;
    }

    public int CalculateFuelConsumption()
    {
        if (Plane.FuelConsumption <= 0)
            throw new ApplicationException("Plane fuel consumption cannot be equal or below 0!");
        CalculateDistance();
        if (Distance <= 0)
            throw new ApplicationException("Distance must not be equal or below 0");

        FuelConsumption = (Distance / 100) * Plane.FuelConsumption;
        return FuelConsumption;
    }

    public TimeOnly CalculateFlightDuration()
    {
        if (Plane.Speed == 0)
            throw new DivideByZeroException("Plane Speed cannot be 0!");
        CalculateDistance();
        if (Distance <= 0)
            throw new ApplicationException("Distance must not be equal or below 0");

        Duration = TimeOnly.FromTimeSpan(TimeSpan.FromHours(((double)Distance / Plane.Speed)) +
                                         Plane.TakeoffDuration.ToTimeSpan());

        return Duration;
    }
}