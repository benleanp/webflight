namespace WebFlightBusiness.Models;

public class Flight
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartureAirportId { get; set; }
    public int DestinationAirportId { get; set; }
    public int PlaneId { get; set; }
    public Airport Departure { get; set; }
    public Airport Destination { get; set; }
    public Plane Plane { get; set; }
    public int Distance { get; set; }
    public int FuelConsumption { get; set; }
    public TimeOnly Duration { get; set; }


    public Flight()
    {
        Departure = new Airport();
        Destination = new Airport();
        Plane = new Plane();
    }

    public Flight(Airport dept, Airport dest, Plane plane)
    {
        Departure = dept ?? throw new ArgumentNullException(nameof(dept));
        Destination = dest ?? throw new ArgumentNullException(nameof(dest));
        Plane = plane ?? throw new ArgumentNullException(nameof(plane));
        PlaneId = plane.Id;
        DestinationAirportId = Destination.Id;
        DepartureAirportId = Departure.Id;
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