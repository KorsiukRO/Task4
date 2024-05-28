using Task4.Models.Cars.Abstract;

namespace Task4.Models.Cars.Concrete;

public class Bolid : Car
{
    public required string Team { get; init; } 
    
    public required string CarNumber { get; init; }

    public required float WinRate { get; init; }
    
    public required float FailureRate { get; init; }

    public Bolid() { }
}