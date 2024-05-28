namespace Task4.Models.Cars.Abstract;

public abstract class Car
{
    public required string CarName { get; init; }
    
    public required string DriverName { get; init; }

    protected Car() { }

    protected Car( string carName, string driverName)
    {
        CarName = carName;
        DriverName = driverName;
    }
}